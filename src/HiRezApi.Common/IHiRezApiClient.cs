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

        Task<HttpOperationResponse<IList<DemoDetails>>> GetDemoDetailsWithHttpMessagesAsync(string matchId, Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<Friends>>> GetFriendsWithHttpMessagesAsync(string player, Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<HirezServerStatus>>> GetHirezServerStatusWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<Items>>> GetItemsWithHttpMessagesAsync(string languageCode, Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<LeagueLeaderBoard>>> GetLeagueLeaderBoardWithHttpMessagesAsync(string queue, string tier, string season,
            Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<MatchDetails>>> GetMatchDetailsBatchWithHttpMessagesAsync(string matchIds, Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<MatchDetails>>> GetMatchDetailsWithHttpMessagesAsync(string matchId, Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<MatchHistory>>> GetMatchHistoryWithHttpMessagesAsync(string player, Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<MatchIdsByQueue>>> GetMatchIdsByQueueWithHttpMessagesAsync(string queue, string date, string hour,
            Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<MatchPlayerDetails>>> GetMatchPlayerDetailsWithHttpMessagesAsync(string matchId, Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<PatchInfo>> GetPatchInfoWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<PlayerAchievements>> GetPlayerAchievementsWithHttpMessagesAsync(string player, Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<PlayerStatus>>> GetPlayerStatusWithHttpMessagesAsync(string player,
            Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<Player>>> GetPlayerWithHttpMessagesAsync(string player, Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<IList<QueueStats>>> GetQueueStatsWithHttpMessagesAsync(string player, string queue, Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<string>> PingWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default);

        Task<HttpOperationResponse<string>> TestSessionWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default);
    }
}