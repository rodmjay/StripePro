﻿using Microsoft.AspNetCore.Components;
using TranslationPro.App.Pages.Bases;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class PhrasesList : ApplicationDetailsBase
    {
        [Inject]
        public IPhrasesController PhrasesController { get; set; }

        private PagedList<PhraseDto> Phrases { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Phrases = await PhrasesController.GetPhrasesAsync(ApplicationId, new PagingQuery(), new PhraseFilters());
        }
    }
}
