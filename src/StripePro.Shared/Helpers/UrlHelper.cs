﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Web;

namespace StripePro.Shared.Helpers;

public class UrlHelper
{
    public static string CombineObjectsToUrl(params object[] dataObjects)
    {
        var queryParams = new List<string>();

        foreach (var obj in dataObjects)
        {
            var properties = obj.GetType().GetProperties();
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                if (value != null)
                {
                    query[property.Name] = value.ToString();
                }
            }

            queryParams.Add(query.ToString());

            return string.Join("&", queryParams);

        }

        return string.Join("&", queryParams);

    }
}