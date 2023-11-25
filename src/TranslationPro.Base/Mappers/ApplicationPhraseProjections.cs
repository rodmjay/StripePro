﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Linq;
using AutoMapper;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Mappers;

public class ApplicationPhraseProjections : Profile
{
    public ApplicationPhraseProjections()
    {
        CreateMap<ApplicationPhrase, ApplicationPhraseOutput>()
            .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Text))
            .ForMember(x => x.TranslationCount, opt => opt.MapFrom(x => x.Translations.Count(t => !t.IsDeleted && !string.IsNullOrWhiteSpace(t.Text))))
            .ForMember(x => x.PendingTranslationCount, opt => opt.MapFrom(x => x.Translations.Count(t => !t.IsDeleted && string.IsNullOrWhiteSpace(t.Text))))
            .IncludeAllDerived();

        CreateMap<ApplicationPhrase, ApplicationPhraseDetails>()
            .ForMember(x => x.Translations, opt => opt.MapFrom(x => x.Translations));


    }
}