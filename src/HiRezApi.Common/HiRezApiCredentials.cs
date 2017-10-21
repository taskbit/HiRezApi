namespace HiRezApi.Common
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;

    public class HiRezApiCredentials : ServiceClientCredentials
    {
        private readonly ISessionProvider _sessionProvider;
        private readonly ITimeStampProvider _timeStampProvider;

        public HiRezApiCredentials(string developerId, string authKey, ITimeStampProvider timeStampProvider = default, ISessionProvider sessionProvider = default)
        {
            this.DeveloperId = developerId;
            this.AuthKey = authKey;
            this._timeStampProvider = timeStampProvider ?? new DateTimeUtcTimeStampProvider();
            this._sessionProvider = sessionProvider ?? new DefaultSessionProvider(this._timeStampProvider);
        }

        public string AuthKey { get; }

        public string DeveloperId { get; }

        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
            // SessionProvider needs to know the ApiClient to be able to fetch a session
            this._sessionProvider.ProvideClient((IHiRezApiClient)client);

            base.InitializeServiceClient(client);
        }

        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uriSegments = request.RequestUri.Segments;

            // Extract the method name from the path
            var methodName = uriSegments[2].Trim('/');

            // Calculate signature hash
            var timeStamp = this._timeStampProvider.ProvideTime().ToString("yyyyMMddHHmmss");
            var signatureContent = $"{this.DeveloperId}{methodName}{this.AuthKey}{timeStamp}";
            var signatureHash = signatureContent.ToMd5LowerInvariant();

            // Method name needs to be suffixed with the desired data format
            uriSegments[2] = $"{methodName}Json/";

            // Build the new path (including session information)
            string[] newSegments;
            if (methodName == "ping")
            {
                // Skip signature, ping is a public method
                newSegments = new string[0];
            }
            else if (methodName == "createsession")
            {
                newSegments = new string[3];
                newSegments[0] = this.DeveloperId;
                newSegments[1] = signatureHash;
                newSegments[2] = timeStamp;
            }
            else
            {
                var session = await this._sessionProvider.AcquireAsync();

                newSegments = new string[4];
                newSegments[0] = this.DeveloperId;
                newSegments[1] = signatureHash;
                newSegments[2] = session.SessionId;
                newSegments[3] = timeStamp;
            }

            // Take the origin base url, add the signature path, add the original method parameters
            var newPath = string.Join("", uriSegments.Take(3)) + string.Join("/", newSegments) + "/" + string.Join("/", uriSegments.Skip(3));
            var newUrlStr = $"{request.RequestUri.Scheme}://{request.RequestUri.Host}" + newPath.TrimEnd('/');
            var newUri = new Uri(newUrlStr);

            // Change the request URI to the assembled one
            request.RequestUri = newUri;

            await base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}