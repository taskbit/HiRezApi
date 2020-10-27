using System;
using System.IO;
using System.Threading.Tasks;
using HiRezApi.Common;
using HiRezApi.Paladins;
using Microsoft.Rest.TransientFaultHandling;
using Newtonsoft.Json;

namespace HiRezApi.AutoRestGen.App
{
    internal class ApiResponseDownloader
    {
        private readonly PaladinsApiClient _client;
        private readonly string _outputDirectory;

        public ApiResponseDownloader(string outputDirectory, HiRezApiCredentials credentials)
        {
            _outputDirectory = outputDirectory;
            var retryPolicy = new RetryPolicy<HiRezApiRetryStrategy>(new ExponentialBackoffRetryStrategy());
            _client = new PaladinsApiClient(Platform.Pc, credentials);
            _client.SetRetryPolicy(retryPolicy);

            if (!Directory.Exists(_outputDirectory))
                Directory.CreateDirectory(_outputDirectory);
        }

        public async Task Download()
        { 
            await CallAndSave("createsession", "Session");
            await CallAndSave("testsession", "TestSession");
            await CallAndSave("ping", "Ping");

            await CallAndSave("getdataused", "DataUsed");
            await CallAndSave("getdemodetails/164858986", "DemoDetails");

            await CallAndSave("getleagueseasons/428", "LeagueSeasons");
            await CallAndSave("getleagueleaderboard/428/1/2", "LeagueLeaderBoard");

            await CallAndSave("getesportsproleaguedetails", "ESportsProLeagueDetails");
            await CallAndSave("getfriends/6541650", "Friends");

            await CallAndSave("getchampionranks/6541650", "ChampionRanks");
            await CallAndSave("getchampions/0", "Champions");
            await CallAndSave("getchampionskins/2205/0", "ChampionSkins");

            await CallAndSave("getchampionrecommendeditems/2205/0", "ChampionRecommendedItems");

            await CallAndSave("getitems/0", "Items");

            await CallAndSave("getmatchdetails/216457507", "MatchDetails");
            await CallAndSave("getmatchdetailsbatch/215881079,175962944", "MatchDetailsBatch");
            await CallAndSave("getmatchplayerdetails/216457507", "MatchPlayerDetails");

            await CallAndSave("getmatchidsbyqueue/424/20180202/3,00", "MatchIdsByQueue");
            await CallAndSave("getmatchhistory/273921", "MatchHistory");

            await CallAndSave("getteamdetails/99", "TeamDetails");
            await CallAndSave("getteamplayers/99", "TeamPlayers");
            await CallAndSave("searchteams/NiP", "SearchTeam");

            await CallAndSave("gettopmatches", "TopMatches");

            await CallAndSave("getplayerachievements/273921", "PlayerAchievements");

            await CallAndSave("getpatchinfo", "PatchInfo");
            await CallAndSave("gethirezserverstatus", "HirezServerStatus");

            await CallAndSave("getplayer/273921", "Player");
            await CallAndSave("getplayerstatus/273921", "PlayerStatus");
            await CallAndSave("getqueuestats/273921/424", "QueueStats");
            await CallAndSave("getplayerloadouts/273921/1", "PlayerLoadouts");

            await CallAndSave("getFriends/273921", "Friends");
            await CallAndSave("getPlayerIDInfoForXboxAndSwitch/273921", "XboxSwitchPlayerId");
            await CallAndSave("getChampionLeaderboard/2205/428", "Leaderboard");

            await CallAndSave("getChampionCards/2205/1", "ChampionCards");
        }

        private static string FormatJson(string json)
        {
            var parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        private async Task CallAndSave(string endpoint, string fileName)
        {
            Console.WriteLine($"Calling: {endpoint}");

            var response = await _client.CallEndpoint(endpoint);
            var rawResponseStr = await response.Response.Content.ReadAsStringAsync();
            var formattedResponseStr = FormatJson(rawResponseStr);
            File.WriteAllText(Path.Combine(_outputDirectory, fileName + ".json"), formattedResponseStr);
        }
    }
}