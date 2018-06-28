namespace HiRezApi.RealmRoyale
{
    using System;
    using System.Net.Http;
    using HiRezApi.Common;
    using Microsoft.Rest;

    // Extend the AutoRest generated class
    public partial class RealmRoyaleApiClient
    {
        public RealmRoyaleApiClient(Platform platform, ServiceClientCredentials credentials, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : this(credentials, rootHandler, handlers)
        {
            this.Platform = platform;

            if (platform == Platform.Pc)
                this.BaseUri = new Uri("http://api.realmroyale.com/RealmApi.svc");
            else if (platform == Platform.Xbox)
                throw new NotSupportedException("Platform not supported.");
            else if (platform == Platform.Ps4)
                throw new NotSupportedException("Platform not supported.");
            else
                throw new ArgumentException(nameof(platform));
        }

        public RealmRoyaleApiClient(Platform platform, ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(platform, credentials, null, handlers)
        {
        }

        public Platform Platform { get; }

        partial void CustomInitialize()
        {
            this.HttpClient.Timeout = TimeSpan.FromSeconds(90);
        }
    }
}