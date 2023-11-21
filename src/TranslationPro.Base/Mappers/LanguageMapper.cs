﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using AutoMapper;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Mappers;

public class LanguageMapper : Profile
{
    public LanguageMapper()
    {
        CreateMap<Language, LanguageOutput>().IncludeAllDerived();
    }
}