namespace HiRezApi.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using HiRezApi.Common.Models;
    using Microsoft.Rest;
    using Newtonsoft.Json;

    public interface IHiRezApiClient
    {
        Uri BaseUri { get; set; }

        ServiceClientCredentials Credentials { get; }

        JsonSerializerSettings DeserializationSettings { get; }

        Platform Platform { get; }

        JsonSerializerSettings SerializationSettings { get; }

        Task<HttpOperationResponse<Session>> CreateSessionWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<DataUsed>>> GetDataUsedWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<HirezServerStatus>>> GetHirezServerStatusWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);
      
        Task<HttpOperationResponse<PatchInfo>> GetPatchInfoWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<string>> PingWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<string>> TestSessionWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default);
    }
}