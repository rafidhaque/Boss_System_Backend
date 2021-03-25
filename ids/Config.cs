// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;

namespace ids
{
    public static class Config
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69784,
                    country = "germany"
                };
                return new List<TestUser>
                { new TestUser{
                    SubjectId="812458",
                    Username="alice",
                    Password="alice",
                    Claims={
                    new Claim(JwtClaimTypes.Name,"Alice Smith"),
                    new Claim(JwtClaimTypes.GivenName,"Alice"),
                    new Claim(JwtClaimTypes.Email,"alicesmith@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified,"true",ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.Role,"admin"),
                    new Claim(JwtClaimTypes.Address,JsonSerializer.Serialize(address),IdentityServerConstants.ClaimValueTypes.Json
                    )
                    }
                },
                new TestUser{
                    SubjectId="8854525",
                    Username="bob",
                    Password="bob",
                    Claims={
                    new Claim(JwtClaimTypes.Name,"Bob Smith"),
                    new Claim(JwtClaimTypes.GivenName,"Bob"),
                    new Claim(JwtClaimTypes.Email,"Bob@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified,"true",ClaimValueTypes.Boolean), 
                    new Claim(JwtClaimTypes.Role,"user"),
                    new Claim(JwtClaimTypes.Address,JsonSerializer.Serialize(address),IdentityServerConstants.ClaimValueTypes.Json
                    )
                    }
                }
                };
            }
        }
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource{ 
                Name="role",
                UserClaims=new List<string>{ "role"}
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("weatherapi.read"),
                new ApiScope("weatherapi.write"),
            };
        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("weatherapi")
            {
                Scopes=new List<string>{ "weatherapi.read","weatherapi.write"},
                ApiSecrets=new List<Secret>{ new Secret("ScopeSecrete".Sha256())},
                UserClaims=new List<string>{ "role"}
            }
        };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("SuperSecretPassword".Sha256()) },

                    AllowedScopes = { "weatherapi.read","weatherapi.write" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("SuperSecretPassword".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:5444/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5444/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5444/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "weatherapi.read" }
                },
            };
    }
}