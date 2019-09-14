// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


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
                new ApiResource("mimir", "Mimir")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // OpenID Connect hybrid flow client (MVC)
                new Client
                {
                    ClientId = "loki",
                    ClientName = "Loki Client",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris           = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "mimir"
                    },

                    //AllowedCorsOrigins = new[]
                    //{
                    //    Settings.CorsUrls["Client"]
                    //}
                },
            };
        }
    }
}