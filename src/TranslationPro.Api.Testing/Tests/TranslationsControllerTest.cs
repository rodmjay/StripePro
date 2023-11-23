﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class TranslationsControllerTest : BaseApiTest
{

    [TestFixture]
    public class TheReplaceTranslationMethod : PhrasesControllerTest
    {
        [Test]
        public async Task CanReplaceTranslation()
        {
            var input = new ApplicationPhrasesCreateOptions()
            {
                Texts = new List<string>() {"hello"}
            };
            var createResult = await ApplicationPhrasesProxy.CreatePhrasesAsync(ApplicationId, input);

            input.Texts = new List<string>() {"goodbye"};

            var replacementInput = new TranslationReplacementOptions()
            {
                LanguageId = "es",
                Text = "hola mae"
            };

            var updateResult = await ApplicationTranslationsProxy.ReplaceTranslation(ApplicationId, int.Parse(createResult[0].Id.ToString()), replacementInput);

            Assert.IsTrue(updateResult.Succeeded);
        }
    }
}