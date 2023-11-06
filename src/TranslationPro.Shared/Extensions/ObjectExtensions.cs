﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace TranslationPro.Shared.Extensions;

public static class ObjectExtensions
{
    public static StringContent SerializeToUTF8Json(this object model)
    {
        var str = JsonConvert.SerializeObject(model);

        return new StringContent(str,
            Encoding.UTF8, "application/json");
    }
}