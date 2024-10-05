using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        ];

    public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ApiScope("financeApp", "finance full access"),
        ];

    public static IEnumerable<Client> Clients =>
        [
            // m2m client credentials flow client
            new Client
            {
                ClientId = "postman",
                ClientName = "Postman",
                AllowedGrantTypes = {GrantType.ResourceOwnerPassword},
                ClientSecrets = [ new Secret("Segredo".Sha256()) ],
                RedirectUris = {"https://www.google.com"},
                AllowedScopes = { "openid", "profile", "financeApp" }
            }
        ];
}
