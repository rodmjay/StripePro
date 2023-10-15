﻿#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityServer4.Contrib.AspNetCore.Testing.Builder;
using IdentityServer4.Contrib.AspNetCore.Testing.Configuration;
using IdentityServer4.Contrib.AspNetCore.Testing.Services;
using IdentityServer4.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TranslationPro.Base.IntegrationTests.Extensions;
using TranslationPro.Base.IntegrationTests.Services;
using TranslationPro.Base.Common.Data.Contexts;

namespace TranslationPro.Base.IntegrationTests.Bases
{
    public abstract class IntegrationTest<TFixture, TStartup> where TStartup : class
    {
        private ClientConfiguration _clientConfiguration;
        private DbContextOptions<ApplicationContext> _context;
        private IdentityServerWebHostProxy _identityServerWebHostProxy;

        protected IntegrationTest()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            InitializeIdentityServerProxy();
            InitializeAPI();
        }

        protected IServiceProvider ServiceProvider { get; private set; }
        protected HttpClient ApiClient { get; private set; }


        private void InitializeIdentityServerProxy()
        {
            _clientConfiguration = new ClientConfiguration("postman", "secret");

            var client = new Client
            {
                ClientId = _clientConfiguration.Id,
                ClientSecrets = new List<Secret>
                {
                    new(_clientConfiguration.Secret.Sha256())
                },
                AllowedScopes = new[] {"api1", "profile", "openid"},
                AllowedGrantTypes = new[] {GrantType.ClientCredentials, GrantType.ResourceOwnerPassword},
                AccessTokenType = AccessTokenType.Jwt,
                AccessTokenLifetime = 7200,
                AllowOfflineAccess = true
            };

            var webHostBuilder = new IdentityServerTestWebHostBuilder()
                .AddClients(client)
                .AddApiScopes(new ApiScope("api1"))
                .AddIdentityResources(new IdentityResources.OpenId(), new IdentityResources.Profile())
                .UseResourceOwnerPasswordValidator(typeof(SimpleResourceOwnerPasswordValidator))
                .UseProfileService(typeof(SimpleProfileService))
                .CreateWebHostBuider();

            _identityServerWebHostProxy = new IdentityServerWebHostProxy(webHostBuilder);
        }

        private void InitializeAPI()
        {
            var apiWebHostBuilder = WebHost.CreateDefaultBuilder()
                .ConfigureAppConfiguration(CustomWebHostBuilderExtensions.Configure<TFixture>)
                .ConfigureServices(services =>
                    services.AddSingleton(_identityServerWebHostProxy.IdentityServer.CreateHandler()))
                .UseStartup<TStartup>();

            var apiServer = new TestServer(apiWebHostBuilder);

            ServiceProvider = apiServer.Services;

            _context = ServiceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>();

            ApiClient = apiServer.CreateClient();
        }

        protected async Task<string> GetAccessToken(string username, string password)
        {
            var userLogin = new UserLoginConfiguration(username, password);

            var tokenResponse = await _identityServerWebHostProxy
                .GetResourceOwnerPasswordAccessTokenAsync(_clientConfiguration, userLogin, "api1", "profile",
                    "openid");

            return tokenResponse.AccessToken;
        }

        protected async Task ResetDatabase()
        {
            await using var context = new ApplicationContext(_context);
            await context.Database.EnsureDeletedAsync();
            await context.Database.MigrateAsync();
        }

        protected async Task DeleteDatabase()
        {
            await using var context = new ApplicationContext(_context);
            await context.Database.EnsureDeletedAsync();
        }
    }
}