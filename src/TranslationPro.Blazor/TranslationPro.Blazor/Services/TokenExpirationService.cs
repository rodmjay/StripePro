﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Newtonsoft.Json.Linq;

namespace TranslationPro.Blazor.Services
{
    public class TokenExpirationService
    {
        private readonly SignOutSessionStateManager SignOutManager;
        private readonly SessionStorageInterop _sessionStorage;
        private readonly NavigationManager _navigationManager;
        private Timer _timer;

        private readonly string AuthSessionKey = "";

        public TokenExpirationService(
            SignOutSessionStateManager signOutSessionStateManager,
            SessionStorageInterop sessionStorage,
            IConfiguration configuration,
            NavigationManager navigationManager)
        {
            SignOutManager = signOutSessionStateManager;
            AuthSessionKey = configuration["AuthSessionKey"];
            _sessionStorage = sessionStorage;
            _navigationManager = navigationManager;
        }

        public void StartTokenExpirationTimer()
        {
            // Set the timer interval to check for token expiration
            _timer = new Timer(CheckExpiration, null, 0, 10000);
        }

        private async void CheckExpiration(object state)
        {
            var authValue = await _sessionStorage.LoadFromSessionStorage<string>(AuthSessionKey);
            if (authValue != null)
            {
                var obj = JObject.Parse(authValue);

                var expiration = obj["expires_at"].Value<string>();

                if (expiration != null && long.TryParse(expiration, out var expirationTime))
                {
                    var currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    var timeUntilExpiration = expirationTime - currentTime;

                    if (timeUntilExpiration <= 300)
                    {
                        await SignOutManager.SetSignOutState();
                        _navigationManager.NavigateTo("authentication/logout");
                    }
                }
            }
        }
    }
}
