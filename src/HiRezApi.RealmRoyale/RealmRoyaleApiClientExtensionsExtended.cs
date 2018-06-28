namespace HiRezApi.RealmRoyale
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using HiRezApi.Common;
    using HiRezApi.RealmRoyale.Models;

    // Type-Safe extensions for the generated API methods
    public static class RealmRoyaleApiClientExtensionsExtended
    {
        public static Task<Leaderboard> GetLeaderboardAsync(this IRealmRoyaleApiClient operations, Queue queue, RankingCriteria rankingCriteria,
            CancellationToken cancellationToken = default)
        {
            return operations.GetLeaderboardAsync(((int) queue).ToString(), ((int) rankingCriteria).ToString(), cancellationToken);
        }

        public static Task<MatchDetails> GetMatchDetailsAsync(this IRealmRoyaleApiClient operations, int matchId,
            CancellationToken cancellationToken = default)
        {
            return operations.GetMatchDetailsAsync(matchId.ToString(), cancellationToken);
        }

        public static Task<IList<MatchIdsByQueue>> GetMatchIdsByQueueAsync(this IRealmRoyaleApiClient operations, Queue queue, DateTime date, TimeSpan hour,
            TimeSpan? minute = null,
            CancellationToken cancellationToken = default)
        {
            return operations.GetMatchIdsByQueueAsync(((int) queue).ToString(), date.ToApiParameterDate(), hour.ToApiParameterHourAndMinTime(minute), cancellationToken);
        }

        public static Task<IList<MatchIdsByQueue>> GetMatchIdsByQueueAsync(this IRealmRoyaleApiClient operations, Queue queue, string date, string hour,
            CancellationToken cancellationToken = default)
        {
            return operations.GetMatchIdsByQueueAsync(((int) queue).ToString(), date, hour, cancellationToken);
        }

        public static Task<Player> GetPlayerAsync(this IRealmRoyaleApiClient operations, string player, PlayerIdentifier identifier,
            CancellationToken cancellationToken = default)
        {
            return operations.GetPlayerAsync(player, ((int) identifier).ToString(), cancellationToken);
        }

        public static Task<PlayerMatchHistory> GetPlayerMatchHistoryAsync(this IRealmRoyaleApiClient operations, int playerId,
            CancellationToken cancellationToken = default)
        {
            return operations.GetPlayerMatchHistoryAsync(playerId.ToString(), cancellationToken);
        }

        public static Task<PlayerStats> GetPlayerStatsAsync(this IRealmRoyaleApiClient operations, int playerId,
            CancellationToken cancellationToken = default)
        {
            return operations.GetPlayerStatsAsync(playerId.ToString(), cancellationToken);
        }
    }
}