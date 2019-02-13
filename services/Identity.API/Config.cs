// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity.API
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api1", "My API #1"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // SPA client using implicit flow
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris =
                    {
                        "http://localhost:4200/index.html",
                        "http://localhost:4200/user/auth-callback",
                        "http://localhost:4200/silent.html",
                        "http://localhost:4200/popup.html",
                    },

                    PostLogoutRedirectUris = { "http://localhost:4200/home" },
                    AllowedCorsOrigins = { "http://localhost:4200" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1",
                        "roles"
                    }
                }
            };
        }
    }
}