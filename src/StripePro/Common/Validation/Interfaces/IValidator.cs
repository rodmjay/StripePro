#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.ComponentModel.DataAnnotations;
using StripePro.Common.Data.Interfaces;
using StripePro.Common.Services.Interfaces;

namespace StripePro.Common.Validation.Interfaces;

public interface IValidator<T> where T : class, IObjectState
{
    ValidationResult Validate(IService<T> service, T account, string value);
}