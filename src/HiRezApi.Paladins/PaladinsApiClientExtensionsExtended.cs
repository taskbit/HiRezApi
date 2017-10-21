namespace HiRezApi.Paladins
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using HiRezApi.Common;
    using HiRezApi.Common.Models;
    using HiRezApi.Paladins.Models;

    // Type-Safe extensions for the generated API methods
    public static partial class PaladinsApiClientExtensions
    {
        public static IList<ChampionRanks> GetChampionRanks(this IPaladinsApiClient operations, int playerId)
        {
            return operations.GetChampionRanks(playerId.ToString());
        }

        public static Task<IList<ChampionRanks>> GetChampionRanksAsync(this IPaladinsApiClient operations, int playerId, CancellationToken cancellationToken = default)
        {
            return operations.GetChampionRanksAsync(playerId.ToString(), cancellationToken);
        }

        public static IList<Champions> GetChampions(this IPaladinsApiClient operations, LanguageCode languageCode)
        {
            return operations.GetChampions(((int)languageCode).ToString());
        }

        public static Task<IList<Champions>> GetChampionsAsync(this IPaladinsApiClient operations, LanguageCode languageCode, CancellationToken cancellationToken = default)
        {
            return operations.GetChampionsAsync(((int)languageCode).ToString(), cancellationToken);
        }

        public static IList<ChampionSkins> GetChampionSkins(this IPaladinsApiClient operations, int championId, LanguageCode languageCode)
        {
            return operations.GetChampionSkins(championId.ToString(), ((int)languageCode).ToString());
        }

        public static Task<IList<ChampionSkins>> GetChampionSkinsAsync(this IPaladinsApiClient operations, int championId, LanguageCode languageCode,
            CancellationToken cancellationToken = default)
        {
            return operations.GetChampionSkinsAsync(championId.ToString(), ((int)languageCode).ToString(), cancellationToken);
        }

        public static Task<IList<DemoDetails>> GetDemoDetailsAsync(this IPaladinsApiClient operations, int matchId, CancellationToken cancellationToken = default)
        {
            return operations.GetDemoDetailsAsync(matchId.ToString(), cancellationToken);
        }

        public static IList<Friends> GetFriends(this IPaladinsApiClient operations, int playerId)
        {
            return operations.GetFriends(playerId.ToString());
        }

        public static Task<IList<Friends>> GetFriendsAsync(this IPaladinsApiClient operations, int playerId, CancellationToken cancellationToken = default)
        {
            return operations.GetFriendsAsync(playerId.ToString(), cancellationToken);
        }

        public static IList<Items> GetItems(this IPaladinsApiClient operations, LanguageCode languageCode)
        {
            return operations.GetItems(((int)languageCode).ToString());
        }

        public static Task<IList<Items>> GetItemsAsync(this IPaladinsApiClient operations, LanguageCode languageCode, CancellationToken cancellationToken = default)
        {
            return operations.GetItemsAsync(((int)languageCode).ToString(), cancellationToken);
        }

        public static IList<LeagueLeaderBoard> GetLeagueLeaderBoard(this IPaladinsApiClient operations, Queue queue, LeagueTier tier, Season season)
        {
            return operations.GetLeagueLeaderBoard(((int)queue).ToString(), ((int)tier).ToString(), ((int)season).ToString());
        }

        public static Task<IList<LeagueLeaderBoard>> GetLeagueLeaderBoardAsync(this IPaladinsApiClient operations, Queue queue, LeagueTier tier, Season season,
            CancellationToken cancellationToken = default)
        {
            return operations.GetLeagueLeaderBoardAsync(((int)queue).ToString(), ((int)tier).ToString(), ((int)season).ToString(), cancellationToken);
        }

        public static IList<MatchDetails> GetMatchDetails(this IPaladinsApiClient operations, int matchId)
        {
            return operations.GetMatchDetails(matchId.ToString());
        }

        public static Task<IList<MatchDetails>> GetMatchDetailsAsync(this IPaladinsApiClient operations, int matchId, CancellationToken cancellationToken = default)
        {
            return operations.GetMatchDetailsAsync(matchId.ToString(), cancellationToken);
        }

        public static IList<MatchDetails> GetMatchDetailsBatch(this IPaladinsApiClient operations, IEnumerable<int> matchIds)
        {
            return operations.GetMatchDetailsBatch(string.Join(",", matchIds));
        }

        public static Task<IList<MatchDetails>> GetMatchDetailsBatchAsync(this IPaladinsApiClient operations, IEnumerable<int> matchIds,
            CancellationToken cancellationToken = default)
        {
            return operations.GetMatchDetailsBatchAsync(string.Join(",", matchIds), cancellationToken);
        }

        public static IList<MatchHistory> GetMatchHistory(this IPaladinsApiClient operations, int playerId)
        {
            return operations.GetMatchHistory(playerId.ToString());
        }

        public static Task<IList<MatchHistory>> GetMatchHistoryAsync(this IPaladinsApiClient operations, int playerId, CancellationToken cancellationToken = default)
        {
            return operations.GetMatchHistoryAsync(playerId.ToString(), cancellationToken);
        }

        public static IList<MatchIdsByQueue> GetMatchIdsByQueue(this IPaladinsApiClient operations, Queue queue, DateTime date, TimeSpan hour, TimeSpan? minute = null)
        {
            return operations.GetMatchIdsByQueue(((int)queue).ToString(), date.ToApiParameterDate(), hour.ToApiParameterHourAndMinTime(minute));
        }

        public static Task<IList<MatchIdsByQueue>> GetMatchIdsByQueueAsync(this IPaladinsApiClient operations, Queue queue, DateTime date, TimeSpan hour, TimeSpan? minute = null,
            CancellationToken cancellationToken = default)
        {
            return operations.GetMatchIdsByQueueAsync(((int)queue).ToString(), date.ToApiParameterDate(), hour.ToApiParameterHourAndMinTime(minute), cancellationToken);
        }

        public static IList<MatchPlayerDetails> GetMatchPlayerDetails(this IPaladinsApiClient operations, int matchId)
        {
            return operations.GetMatchPlayerDetails(matchId.ToString());
        }

        public static Task<IList<MatchPlayerDetails>> GetMatchPlayerDetailsAsync(this IPaladinsApiClient operations, int matchId, CancellationToken cancellationToken = default)
        {
            return operations.GetMatchPlayerDetailsAsync(matchId.ToString(), cancellationToken);
        }

        public static Player GetPlayer(this IPaladinsApiClient operations, int playerId)
        {
            return operations.GetPlayer(playerId.ToString());
        }

        public static PlayerAchievements GetPlayerAchievements(this IPaladinsApiClient operations, int playerId)
        {
            return operations.GetPlayerAchievements(playerId.ToString());
        }

        public static Task<PlayerAchievements> GetPlayerAchievementsAsync(this IPaladinsApiClient operations, int playerId, CancellationToken cancellationToken = default)
        {
            return operations.GetPlayerAchievementsAsync(playerId.ToString(), cancellationToken);
        }

        public static async Task<Player> GetPlayerAsync(this IPaladinsApiClient operations, int playerId, CancellationToken cancellationToken = default)
        {
            return await operations.GetPlayerAsync(playerId.ToString(), cancellationToken);
        }

        public static IList<PlayerLoadouts> GetPlayerLoadouts(this IPaladinsApiClient operations, int playerId, LanguageCode languageCode)
        {
            return operations.GetPlayerLoadouts(playerId.ToString(), ((int)languageCode).ToString());
        }

        public static Task<IList<PlayerLoadouts>> GetPlayerLoadoutsAsync(this IPaladinsApiClient operations, int playerId, LanguageCode languageCode,
            CancellationToken cancellationToken = default)
        {
            return operations.GetPlayerLoadoutsAsync(playerId.ToString(), ((int)languageCode).ToString(), cancellationToken);
        }

        public static PlayerStatus GetPlayerStatus(this IPaladinsApiClient operations, int playerId)
        {
            return operations.GetPlayerStatus(playerId.ToString());
        }

        public static async Task<PlayerStatus> GetPlayerStatusAsync(this IPaladinsApiClient operations, int playerId, CancellationToken cancellationToken = default)
        {
            return await operations.GetPlayerStatusAsync(playerId.ToString(), cancellationToken);
        }

        public static IList<QueueStats> GetQueueStats(this IPaladinsApiClient operations, string player, Queue queue)
        {
            return operations.GetQueueStats(player, ((int)queue).ToString());
        }

        public static IList<QueueStats> GetQueueStats(this IPaladinsApiClient operations, int playerId, Queue queue)
        {
            return operations.GetQueueStats(playerId.ToString(), queue);
        }

        public static Task<IList<QueueStats>> GetQueueStatsAsync(this IPaladinsApiClient operations, string player, Queue queue, CancellationToken cancellationToken = default)
        {
            return operations.GetQueueStatsAsync(player, ((int)queue).ToString(), cancellationToken);
        }

        public static Task<IList<QueueStats>> GetQueueStatsAsync(this IPaladinsApiClient operations, int playerId, Queue queue, CancellationToken cancellationToken = default)
        {
            return operations.GetQueueStatsAsync(playerId.ToString(), queue, cancellationToken);
        }
    }
}