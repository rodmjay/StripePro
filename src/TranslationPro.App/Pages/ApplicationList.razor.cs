﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Applications;
using TranslationPro.Shared.Controllers;

namespace TranslationPro.App.Pages
{
    public partial class ApplicationList
    {
        [CascadingParameter]
        Task<AuthenticationState> authenticationStateTask { get; set; }

        public IEnumerable<ApplicationDto>? Applications { get; set; }

        [Inject]
        public IApplicationsController? ApplicationService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Applications = (await ApplicationService!.GetApplicationsAsync()).ToList();
        }
    }
}
