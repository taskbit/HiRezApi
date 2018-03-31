namespace HiRezApi.Paladins
{
    using System;
    using System.Net.Http;
    using HiRezApi.Common;
    using Microsoft.Rest;

    // Extend the AutoRest generated class
    public partial class PaladinsApiClient
    {
        public PaladinsApiClient(Platform platform, ServiceClientCredentials credentials, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : this(credentials, rootHandler, handlers)
        {
            this.Platform = platform;

            if (platform == Platform.Pc)
                this.BaseUri = new Uri("http://api.paladins.com/paladinsapi.svc");
            else if (platform == Platform.Xbox)
                this.BaseUri = new Uri("http://api.xbox.paladins.com/paladinsapi.svc");
            else if (platform == Platform.Ps4)
                this.BaseUri = new Uri("http://api.ps4.paladins.com/paladinsapi.svc");
            else
                throw new ArgumentException(nameof(platform));
        }

        public PaladinsApiClient(Platform platform, ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
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