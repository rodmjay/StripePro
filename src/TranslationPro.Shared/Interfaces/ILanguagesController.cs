﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Interfaces;

public interface ILanguagesController
{
    Task<List<LanguageOutput>> GetLanguagesAsync();
}