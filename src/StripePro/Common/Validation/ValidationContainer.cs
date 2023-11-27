﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StripePro.Common.Validation.Interfaces;

namespace StripePro.Common.Validation;

[ExcludeFromCodeCoverage]
public class ValidationContainer : IValidationContainer
{
    public ValidationContainer(IDictionary<string, IList<string>> validationErrors)
    {
        ValidationErrors = validationErrors;
    }

    public IDictionary<string, IList<string>> ValidationErrors { get; }
    public bool IsValid { get; }
}

[ExcludeFromCodeCoverage]
public class ValidationContainer<T> : IValidationContainer<T>
{
    public ValidationContainer(IDictionary<string, IList<string>> validationErrors, T entity)
    {
        ValidationErrors = validationErrors;
        Entity = entity;
    }

    public IDictionary<string, IList<string>> ValidationErrors { get; }
    public T Entity { get; }

    public bool IsValid => ValidationErrors.Count == 0;
}