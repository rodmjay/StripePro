﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TranslationPro.Base.Common.Validation.Attributes;

[ExcludeFromCodeCoverage]
public class MaxValueAttribute : ValidationAttribute
{
    private readonly int _maxValue;

    public MaxValueAttribute(int maxValue)
    {
        _maxValue = maxValue;
    }

    public override bool IsValid(object value)
    {
        var val = Convert.ToDecimal(value);
        return val <= _maxValue;
    }
}