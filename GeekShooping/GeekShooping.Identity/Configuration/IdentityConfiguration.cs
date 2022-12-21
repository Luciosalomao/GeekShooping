﻿using IdentityServer4;
using IdentityServer4.Models;

namespace GeekShooping.Identity.Configuration
{
    public class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Cliente = "Cliente";

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("geek_shopping", "GeekShopping Server"),
                new ApiScope(name: "read", "Read data."),
                new ApiScope(name: "write", "Write data."),
                new ApiScope(name: "delete", "Delete data."),
            };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("minha_super_senha_123*".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"read", "write", "profile"},
            },
            new Client
            {
                ClientId = "geek_shopping",
                ClientSecrets = { new Secret("minha_super_senha_123*".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = {"http://localhost:39012/signin-oidc"},
                PostLogoutRedirectUris = {"http://localhost:39012/signout-callback-oidc"},
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "geek_shopping"
                }
            }


        };
    }
}
