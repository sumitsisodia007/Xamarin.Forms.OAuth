﻿using Newtonsoft.Json.Linq;

namespace Xamarin.Forms.OAuth.Providers
{
    public sealed class InstagramOAuthProvider : OAuthProvider
    {
        // Does not support refresh token. Needs re-authentication
        // https://www.instagram.com/developer/authentication/
        internal InstagramOAuthProvider(string clientId, string clientSecret, string redirectUrl, params string[] scopes)
            : base(new OAuthProviderDefinition(
                "Instagram",
                "https://api.instagram.com/oauth/authorize",
                "https://api.instagram.com/oauth/access_token",
                "https://api.instagram.com/v1/users/self",
                clientId,
                clientSecret,
                redirectUrl,
                scopes)
            {
                IncludeRedirectUrlInTokenRequest = true
            })
        { }
          
        internal override AccountData ReadAccountData(string json)
        {
            var jObject = JObject.Parse(json);

            var data = jObject.GetValue("data") as JObject;

            return new AccountData(
                data.GetStringValue("id"),
                data.GetStringValue("full_name"));
        }
    }
}
