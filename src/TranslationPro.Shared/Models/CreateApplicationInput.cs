﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion


namespace TranslationPro.Shared.Models;

public class CreateApplicationInput : ApplicationInput
{
    public string[] Languages { get; set; }
}