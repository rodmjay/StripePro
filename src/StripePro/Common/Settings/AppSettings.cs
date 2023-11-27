#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using StripePro.Common.Caching;
using StripePro.Common.Data;
using StripePro.Email.Settings;

namespace StripePro.Common.Settings;

public partial class AppSettings
{
    public string ApiUrl { get; set; }
    public string AppUrl { get; set; }
    public string TranslationsUrl { get; set; }
    public string Name { get; set; }
    public string Authority { get; set; }
    public string Audience { get; set; }
    public DatabaseSettings Database { get; set; }
    public CacheSettings Cache { get; set; }
    public SendGridSettings SendGrid { get; set; }
    public string CodeSigningThumbprint { get; set; }
    public bool IsUnderTest { get; set; }

}