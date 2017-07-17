using System.Collections.Generic;
using IdentityServer4.Models;

public static class Config {
    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new ApiResource("Narwahl-api", "Narwahl API")
        };
    }

    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>
        {
            new Client
            {
                ClientId = "ben@gdsestimating.com",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                // secret for authentication
                ClientSecrets =
                {
                    new Secret("167466fc-de0b-4a68-a7b4-4869873d0136".Sha256())
                },

                // scopes that client has access to
                AllowedScopes = new List<string>
                {
                    "Narwahl-api"
                }
            }
        };
    }
}