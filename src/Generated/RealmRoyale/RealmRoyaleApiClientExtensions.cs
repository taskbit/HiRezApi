// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace HiRezApi.RealmRoyale
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using HiRezApi.Common.Models;
    using Models;
    using MatchDetails = HiRezApi.RealmRoyale.Models.MatchDetails;
    using MatchIdsByQueue = HiRezApi.RealmRoyale.Models.MatchIdsByQueue;
    using Player = HiRezApi.RealmRoyale.Models.Player;

    /// <summary>
    /// Extension methods for RealmRoyaleApiClient.
    /// </summary>
    public static partial class RealmRoyaleApiClientExtensions
    {
        /// <summary>
        /// createsession
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        public static Session CreateSession(this IRealmRoyaleApiClient operations)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(s => ((IRealmRoyaleApiClient)s).CreateSessionAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// createsession
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Session> CreateSessionAsync(this IRealmRoyaleApiClient operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.CreateSessionWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// getdataused
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        public static System.Collections.Generic.IList<DataUsed> GetDataUsed(this IRealmRoyaleApiClient operations)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(s => ((IRealmRoyaleApiClient)s).GetDataUsedAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// getdataused
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<System.Collections.Generic.IList<DataUsed>> GetDataUsedAsync(this IRealmRoyaleApiClient operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetDataUsedWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// getmatchdetails
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='matchId'>
        /// The matchId
        /// </param>
        public static MatchDetails GetMatchDetails(this IRealmRoyaleApiClient operations, string matchId)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(s => ((IRealmRoyaleApiClient)s).GetMatchDetailsAsync(matchId), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// getmatchdetails
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='matchId'>
        /// The matchId
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<MatchDetails> GetMatchDetailsAsync(this IRealmRoyaleApiClient operations, string matchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetMatchDetailsWithHttpMessagesAsync(matchId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// getmatchidsbyqueue
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='queue'>
        /// The queue
        /// </param>
        /// <param name='date'>
        /// The date
        /// </param>
        /// <param name='hour'>
        /// The hour
        /// </param>
        public static System.Collections.Generic.IList<MatchIdsByQueue> GetMatchIdsByQueue(this IRealmRoyaleApiClient operations, string queue, string date, string hour)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(s => ((IRealmRoyaleApiClient)s).GetMatchIdsByQueueAsync(queue, date, hour), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// getmatchidsbyqueue
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='queue'>
        /// The queue
        /// </param>
        /// <param name='date'>
        /// The date
        /// </param>
        /// <param name='hour'>
        /// The hour
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<System.Collections.Generic.IList<MatchIdsByQueue>> GetMatchIdsByQueueAsync(this IRealmRoyaleApiClient operations, string queue, string date, string hour, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetMatchIdsByQueueWithHttpMessagesAsync(queue, date, hour, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// getleaderboard
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='queue'>
        /// The queue
        /// </param>
        /// <param name='tier'>
        /// The tier
        /// </param>
        public static Leaderboard GetLeaderboard(this IRealmRoyaleApiClient operations, string queue, string tier)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(s => ((IRealmRoyaleApiClient)s).GetLeaderboardAsync(queue, tier), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// getleaderboard
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='queue'>
        /// The queue
        /// </param>
        /// <param name='tier'>
        /// The tier
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Leaderboard> GetLeaderboardAsync(this IRealmRoyaleApiClient operations, string queue, string tier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetLeaderboardWithHttpMessagesAsync(queue, tier, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// getplayermatchhistory
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='player'>
        /// The player
        /// </param>
        public static PlayerMatchHistory GetPlayerMatchHistory(this IRealmRoyaleApiClient operations, string player)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(s => ((IRealmRoyaleApiClient)s).GetPlayerMatchHistoryAsync(player), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// getplayermatchhistory
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='player'>
        /// The player
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<PlayerMatchHistory> GetPlayerMatchHistoryAsync(this IRealmRoyaleApiClient operations, string player, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetPlayerMatchHistoryWithHttpMessagesAsync(player, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// getplayer
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='player'>
        /// The player
        /// </param>
        /// <param name='platform'>
        /// The platform
        /// </param>
        public static Player GetPlayer(this IRealmRoyaleApiClient operations, string player, string platform)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(s => ((IRealmRoyaleApiClient)s).GetPlayerAsync(player, platform), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// getplayer
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='player'>
        /// The player
        /// </param>
        /// <param name='platform'>
        /// The platform
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Player> GetPlayerAsync(this IRealmRoyaleApiClient operations, string player, string platform, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetPlayerWithHttpMessagesAsync(player, platform, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// getplayerstats
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='player'>
        /// The player
        /// </param>
        public static PlayerStats GetPlayerStats(this IRealmRoyaleApiClient operations, string player)
        {
            return System.Threading.Tasks.Task.Factory.StartNew(s => ((IRealmRoyaleApiClient)s).GetPlayerStatsAsync(player), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// getplayerstats
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='player'>
        /// The player
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<PlayerStats> GetPlayerStatsAsync(this IRealmRoyaleApiClient operations, string player, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetPlayerStatsWithHttpMessagesAsync(player, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }



        /// <summary>
        /// getpatchinfo
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        public static PatchInfo GetPatchInfo(this IRealmRoyaleApiClient operations)
        {
            return operations.GetPatchInfoAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// getpatchinfo
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<PatchInfo> GetPatchInfoAsync(this IRealmRoyaleApiClient operations, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetPatchInfoWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// gethirezserverstatus
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        public static HirezServerStatus GetHirezServerStatus(this IRealmRoyaleApiClient operations)
        {
            return operations.GetHirezServerStatusAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// gethirezserverstatus
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<HirezServerStatus> GetHirezServerStatusAsync(this IRealmRoyaleApiClient operations, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetHirezServerStatusWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body?.FirstOrDefault();
            }
        }


        /// <summary>
        /// ping
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        public static string Ping(this IRealmRoyaleApiClient operations)
        {
            return operations.PingAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// ping
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> PingAsync(this IRealmRoyaleApiClient operations, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PingWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// testsession
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        public static string TestSession(this IRealmRoyaleApiClient operations)
        {
            return operations.TestSessionAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// testsession
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> TestSessionAsync(this IRealmRoyaleApiClient operations, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.TestSessionWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

    }
}
