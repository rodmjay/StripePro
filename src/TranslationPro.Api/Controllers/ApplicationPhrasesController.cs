﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Managers;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;
using TranslationPro.Shared.Results;

namespace TranslationPro.Api.Controllers;

[Route("v1.0/applications/{applicationId}/phrases")]
public class ApplicationPhrasesController : BaseController, IApplicationPhrasesController
{
   
    private readonly ApplicationPhraseManager _applicationPhraseManager;

    public ApplicationPhrasesController(IServiceProvider serviceProvider, 
        ApplicationPhraseManager applicationPhraseManager) : base(serviceProvider)
    {
        _applicationPhraseManager = applicationPhraseManager;
    }

    [HttpGet("{phraseId:int}")]
    public async Task<ApplicationPhraseDetails> GetPhraseAsync([FromRoute] Guid applicationId,
        [FromRoute] int phraseId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationPhraseManager.GetPhraseAsync<ApplicationPhraseDetails>(applicationId, phraseId);
    }
    

    [HttpPost]
    public async Task<ApplicationPhraseDetails> CreatePhraseAsync([FromRoute] Guid applicationId,
        [FromBody] PhraseOptions input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        var result = await _applicationPhraseManager
            .CreatePhrase<ApplicationPhraseDetails>(applicationId, input.Text);
        
        return result;
    }
    

    [HttpGet]
    public async Task<PagedList<ApplicationPhraseOutput>> GetPhrasesAsync([FromRoute] Guid applicationId,
        [FromQuery] PagingQuery paging,
        [FromQuery] PhraseFilters filters)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationPhraseManager.GetPhrasesForApplicationAsync<ApplicationPhraseOutput>(applicationId, paging, filters)
            .ConfigureAwait(false);
    }

    [HttpGet("{language}")]
    [AllowAnonymous]
    public async Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguageAsync([FromRoute] Guid applicationId,
        [FromRoute] string language)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationPhraseManager.GetApplicationPhraseList(applicationId, language).ConfigureAwait(false);
    }

    [HttpDelete("{phraseId}")]
    public async Task<Result> DeletePhraseAsync([FromRoute] Guid applicationId, [FromRoute] int phraseId)
    {
        await AssertUserHasAccessToApplication(applicationId);
        return await _applicationPhraseManager.DeletePhraseAsync(applicationId, phraseId);
    }

}