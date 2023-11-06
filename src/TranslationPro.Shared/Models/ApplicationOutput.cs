﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Shared.Models;

public class ApplicationOutput : IApplication
{
    public List<string> SupportedLanguages { get; set; }
    public int PhraseCount { get; set; }
    public int TranslationCount { get; set; }
    public int PendingTranslationCount { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<ApplicationLanguageOutput> Languages { get; set; }
    public List<ApplicationUserDto> Users { get; set; }
}