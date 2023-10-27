﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityModel.Client;
using NUnit.Framework;
using TranslationPro.Api.Interfaces;
using TranslationPro.Base.ApplicationLanguages.Models;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.ApplicationUsers.Models;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Languages.Models;
using TranslationPro.Base.Phrases.Models;
using TranslationPro.Base.Translations.Models;
using TranslationPro.Testing.Bases;
using TranslationPro.Testing.Extensions;
using TranslationPro.Testing.TestCases;

namespace TranslationPro.Api.Testing;

public abstract class BaseApiTest : IntegrationTest<BaseApiTest, Startup>, 
    IApplicationsController, 
    IApplicationLanguagesController, 
    ILanguagesController,
    IApplicationUsersController,
    IPhrasesController,
    ITranslationsController
{
    protected Result ApplicationResult;

    protected Guid ApplicationId => Guid.Parse(ApplicationResult.Id.ToString());

    [OneTimeSetUp]
    public virtual async Task SetupFixture()
    {
        await ResetDatabase();
        var accessToken = await GetAccessToken("admin@admin.com", "ASDFasdf!");
        ApiClient.SetBearerToken(accessToken);
        ApplicationResult = await CreateDefaultApplication();
        Assert.IsTrue(ApplicationResult.Succeeded);
    }

    [OneTimeTearDown]
    public virtual async Task TeardownFixture()
    {
        await DeleteDatabase();
    }

    #region Languages

    protected string LanguageUrl = "/v1.0/languages";

    public async Task<List<LanguageDto>> GetLanguagesAsync()
    {
        var response = await ApiClient.GetAsync(LanguageUrl);

        return response.Content.DeserializeObject<List<LanguageDto>>();
    }

    #endregion

    #region Applications

    protected string ApplicationUrl = "/v1.0/applications";

    protected Task<Result> CreateDefaultApplication()
    {
        return CreateApplicationAsync(ApplicationTestCases.CreateApplication);
    }

    public Task<ApplicationDto> GetApplicationAsync(Guid applicationId)
    {
        return DoGet<ApplicationDto>($"{ApplicationUrl}/{applicationId}");
    }

    public Task<List<ApplicationDto>> GetApplicationsAsync()
    {
        return DoGet<List<ApplicationDto>>(ApplicationUrl);
    }

    public Task<Result> CreateApplicationAsync(CreateApplicationInput input)
    {
        return DoPost<CreateApplicationInput, Result>(ApplicationUrl, input);
    }

    public Task<Result> DeleteApplicationAsync(Guid applicationId)
    {
        return DoDelete<Result>($"{ApplicationUrl}/{applicationId}");
    }

    public Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationInput input)
    {
        return DoPut<ApplicationInput, Result>($"{ApplicationUrl}/{applicationId}", input);
    }

    #endregion

    #region Application Languages
    public Task<Result> AddLanguageToApplicationAsync(Guid applicationId, ApplicationLanguageInput input)
    {
        return DoPost<ApplicationLanguageInput, Result>($"{ApplicationUrl}/{applicationId}/languages", input);
    }

    public Task<Result> RemoveLanguageFromApplicationAsync(Guid applicationId, string languageId)
    {
        return DoDelete<Result>($"{ApplicationUrl}/{applicationId}/languages/{languageId}");
    }

    #endregion

    #region Application Users
    public Task<Result> InviteUserAsync(Guid applicationId, CreateApplicationUser input)
    {
        return DoPost<CreateApplicationUser, Result>($"{ApplicationUrl}/{applicationId}/users", input);
    }

    #endregion

    #region Phrases

    public Task<Result> BulkUploadAsync(Guid applicationId, List<string> input)
    {
        return DoPost<List<string>, Result>($"{ApplicationUrl}/{applicationId}/phrases/bulk", input);
    }

    public Task<Result> CreatePhraseAsync(Guid applicationId, PhraseInput input)
    {
        return DoPost<PhraseInput, Result>($"{ApplicationUrl}/{applicationId}/phrases", input);
    }

    public Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, PhraseInput input)
    {
        return DoPut<PhraseInput, Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}", input);
    }

    public Task<PagedList<PhraseDto>> GetPhrasesAsync(Guid applicationId, PagingQuery paging, PhraseFilters filters)
    {
        return DoGet<PagedList<PhraseDto>>($"{ApplicationUrl}/{applicationId}/phrases");
    }

    public Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguageAsync(Guid applicationId, string language)
    {
        return DoGet<Dictionary<int, string>>($"{ApplicationUrl}/{applicationId}/phrases/{language}");

    }

    public Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId)
    {
        return DoDelete<Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}");
    }

    #endregion

    #region Translations
    public Task<Result> SaveTranslation(Guid applicationId, int phraseId, TranslationInput input)
    {
        return DoPut<TranslationInput, Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}", input);

    }

    #endregion


}