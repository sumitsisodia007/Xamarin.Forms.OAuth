﻿namespace Xamarin.Forms.OAuth.Providers
{
    public class DropboxOAuthProvider : OAuthProvider
    {
        internal DropboxOAuthProvider(string clientId, string redirectUrl, params string[] scopes)
            : base(clientId, redirectUrl, scopes)
        { }

        public override string Name
        {
            get
            {
                return "Dropbox";
            }
        }

        protected override string AuthoizationUrl
        {
            get
            {
                return "https://www.dropbox.com/1/oauth2/authorize";
            }
        }

        protected override string GraphUrl
        {
            get
            {
                return "https://api.dropbox.com/1/account/info";
            }
        }
    }
}