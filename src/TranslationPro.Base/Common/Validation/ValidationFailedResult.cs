﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TranslationPro.Base.Common.Validation;

public class ValidationFailedResult : ObjectResult
{
    public ValidationFailedResult(ModelStateDictionary modelState)
        : base(new ValidationResultModel(modelState))
    {
        StatusCode = StatusCodes.Status422UnprocessableEntity;
    }
}