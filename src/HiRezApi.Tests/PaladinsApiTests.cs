namespace HiRezApi.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using HiRezApi.Common;
    using HiRezApi.Paladins;
    using Microsoft.Rest.TransientFaultHandling;
    using NUnit.Framework;

    [TestFixture(Platform.Pc, 273921, 2205, 226145337)]
    [TestFixture(Platform.Xbox, 1062067, 2205, 29280439)]
    [TestFixture(Platform.Ps4, 3364709, 2205, 66763093)]
    public class PaladinsApiTests
    {
        // TODO: This will break if the provided match is older than 30 days (HiRez API restriction)
        private readonly int _matchId;

        private readonly Platform _platform;
        private readonly int _playerId;
        private readonly int _championId;
        private PaladinsApiClient _client;

        public PaladinsApiTests(Platform platform, int playerId, int championId, int matchId)
        {
            this._platform = platform;
            this._playerId = playerId;
            this._championId = championId;
            this._matchId = matchId;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var retryPolicy = new RetryPolicy<HiRezApiRetryStrategy>(new ExponentialBackoffRetryStrategy());
            var timestampProvider = new DateTimeUtcTimeStampProvider();
            var fileSessionRepository = new JsonFileSessionRepository(Environment.CurrentDirectory, timestampProvider); // Session storage is optional
            var credentials = new HiRezApiCredentials("YourDeveloperId", "YourAuthKey", timestampProvider,
                new DefaultSessionProvider(timestampProvider, fileSessionRepository));

            this._client = new PaladinsApiClient(this._platform, credentials);
            this._client.SetRetryPolicy(retryPolicy);
        }

        private static void AssertDefaultApiListResponseHasResults<T>(IList<T> list)
        {
            Assert.IsNotEmpty(list);
            Assert.That(list, Has.None.Null);
        }

        [Test]
        public async Task TestGetChampionRanks()
        {
            var championRanks = await this._client.GetChampionRanksAsync(this._playerId);
            AssertDefaultApiListResponseHasResults(championRanks);
        }

        [Test]
        public async Task TestGetChampions()
        {
            var champions = await this._client.GetChampionsAsync(LanguageCode.English);
            AssertDefaultApiListResponseHasResults(champions);
        }

        [Test]
        public async Task TestGetChampionSkins()
        {
            var champions = await this._client.GetChampionSkinsAsync(this._championId, LanguageCode.English);
            AssertDefaultApiListResponseHasResults(champions);
        }

        [Test]
        public async Task TestGetDataUsed()
        {
            var dataUsed = await this._client.GetDataUsedAsync();
            Assert.NotNull(dataUsed);
            Assert.Greater(dataUsed.RequestLimitDaily, 0);
        }

        [Test]
        public void TestGetDataUsedSync()
        {
            var dataUsed = this._client.GetDataUsed();
            Assert.NotNull(dataUsed);
            Assert.Greater(dataUsed.RequestLimitDaily, 0);
        }

        [Test]
        public async Task TestGetDemoDetails()
        {
            var demoDetails = await this._client.GetDemoDetailsAsync(this._matchId);
            AssertDefaultApiListResponseHasResults(demoDetails);
        }

        [Test]
        public async Task TestGetFriends()
        {
            var friends = await this._client.GetFriendsAsync(this._playerId);
            Assert.NotNull(friends);
        }

        [Test]
        public async Task TestGetItems()
        {
            var items = await this._client.GetItemsAsync(LanguageCode.English);
            AssertDefaultApiListResponseHasResults(items);
            Assert.IsTrue(items.Any(i => i.Description.Contains("Weapon")));
        }

        [Test]
        public async Task TestGetItemsGerman()
        {
            var items = await this._client.GetItemsAsync(LanguageCode.German);
            AssertDefaultApiListResponseHasResults(items);
            Assert.IsTrue(items.Any(i => i.Description.Contains("Waffe")));
        }

        [Test]
        public async Task TestGetLeagueLeaderBoard()
        {
            var leaderBoard = await this._client.GetLeagueLeaderBoardAsync(Queue.Competitive, LeagueTier.Bronze1, Season.Season1);
            AssertDefaultApiListResponseHasResults(leaderBoard);
        }

        [Test]
        public async Task TestGetMatchDetails()
        {
            var matchDetails = await this._client.GetMatchDetailsAsync(this._matchId);
            AssertDefaultApiListResponseHasResults(matchDetails);
            Assert.AreEqual(10, matchDetails.Count);
        }

        [Test]
        public async Task TestGetMatchDetailsBatch()
        {
            var matchDetailsBatch = await this._client.GetMatchDetailsBatchAsync(new[] { this._matchId });
            AssertDefaultApiListResponseHasResults(matchDetailsBatch);
        }

        [Test]
        public async Task TestGetMatchHistory()
        {
            var matchHistory = await this._client.GetMatchHistoryAsync(this._playerId);
            AssertDefaultApiListResponseHasResults(matchHistory);
        }

        [Test]
        public async Task TestGetMatchIdsByQueue()
        {
            var date = DateTime.UtcNow.AddDays(-1);
            var hourSpan = new TimeSpan(12, 0, 0);
            var matchIds = await this._client.GetMatchIdsByQueueAsync(Queue.ShootingRange, date, hourSpan);
            Assert.NotNull(matchIds);
        }

        [Test]
        public async Task TestGetMatchIdsByQueueSliced()
        {
            var date = DateTime.UtcNow.AddDays(-1);
            var hourSpan = new TimeSpan(12, 0, 0);
            var minuteSpan = new TimeSpan(0, 10, 0);
            var matchIds = await this._client.GetMatchIdsByQueueAsync(Queue.ShootingRange, date, hourSpan, minuteSpan);
            Assert.NotNull(matchIds);
        }

        [Test]
        public async Task TestGetMatchPlayerDetails()
        {
            var matchPlayerDetails = await this._client.GetMatchPlayerDetailsAsync(this._matchId);
            AssertDefaultApiListResponseHasResults(matchPlayerDetails);
        }

        [Test]
        public async Task TestGetPatchInfo()
        {
            var patchInfo = await this._client.GetPatchInfoAsync();
            Assert.NotNull(patchInfo);
        }

        [Test]
        public async Task TestGetPlayer()
        {
            var player = await this._client.GetPlayerAsync(this._playerId);
            Assert.NotNull(player);
        }

        [Test]
        public async Task TestGetPlayerAchievements()
        {
            var playerAchievements = await this._client.GetPlayerAchievementsAsync(this._playerId);
            Assert.NotNull(playerAchievements);
        }

        [Test]
        public async Task TestGetPlayerStatus()
        {
            var playerStatus = await this._client.GetPlayerStatusAsync(this._playerId);
            Assert.NotNull(playerStatus);
        }

        [Test]
        public async Task TestGetQueueStats()
        {
            var queueStats = await this._client.GetQueueStatsAsync(this._playerId, Queue.Siege);
            AssertDefaultApiListResponseHasResults(queueStats);
        }

        [Test]
        public async Task TestGetServerStatus()
        {
            var serverStatus = await this._client.GetHirezServerStatusAsync();
            Assert.NotNull(serverStatus);
        }

        [Test]
        public async Task TestPing()
        {
            var ping = await this._client.PingAsync();
            Assert.IsNotEmpty(ping);
        }

        [Test]
        public async Task TestTestSession()
        {
            var session = await this._client.TestSessionAsync();
            Assert.IsNotEmpty(session);
        }
    }
}