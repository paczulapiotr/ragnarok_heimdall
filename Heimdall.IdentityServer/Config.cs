// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Heimdall.IdentityServer;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerAspNetIdentity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource(
                    name: "mimir",
                    displayName: "Mimir",
                    claimTypes: new [] { JwtClaimTypes.Name })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "loki",
                    ClientName = "Loki Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { $"{Settings.Security.ClientUrl}/oidc" },
                    PostLogoutRedirectUris = { $"{Settings.Security.ClientUrl}/signout-callback-oidc" },
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "mimir"
                    },

                    AllowedCorsOrigins = new[]
                    {
                        Settings.Security.ClientUrl
                    }
                },
            };
        }
    }
}