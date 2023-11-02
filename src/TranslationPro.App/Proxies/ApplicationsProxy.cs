﻿using System.Text.Json;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Proxies
{
    public class ApplicationsProxy : BaseProxy, IApplicationsController
    {
        protected string ApplicationUrl = "/v1.0/applications";


        public ApplicationsProxy(HttpClient httpClient) : base(httpClient)
        {
        }
        
        public Task<ApplicationDto> GetApplicationAsync(Guid applicationId)
        {
            return DoGet<ApplicationDto>($"{ApplicationUrl}/{applicationId}");
        }

        public async Task<List<ApplicationDto>> GetApplicationsAsync()
        {
            return await DoGet<List<ApplicationDto>>($"{ApplicationUrl}");
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
    }
}
