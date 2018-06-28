namespace HiRezApi.Examples.App
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Linq;
    using HiRezApi.Common;
    using HiRezApi.RealmRoyale;
    using HiRezApi.RealmRoyale.Models;
    using Microsoft.Rest.TransientFaultHandling;

    using Match = HiRezApi.RealmRoyale.Models.Match;

    internal class RealmRoyale
    {
        public static void Execute()
        {
            Console.WriteLine("Executing RealmRoyale...");

            var retryPolicy = new RetryPolicy<HiRezApiRetryStrategy>(new ExponentialBackoffRetryStrategy());
            var timestampProvider = new DateTimeUtcTimeStampProvider();
            var fileSessionRepository = new JsonFileSessionRepository(Environment.CurrentDirectory, timestampProvider); // Session storage is optional
            var credentials = new HiRezApiCredentials("YourDeveloperId", "YourAuthKey", timestampProvider,
                new DefaultSessionProvider(timestampProvider, fileSessionRepository));

            var client = new RealmRoyaleApiClient(Platform.Pc, credentials);
            client.SetRetryPolicy(retryPolicy);

            ExecuteApiDataStats(client).GetAwaiter().GetResult();
            ExecuteQueuedMatches(client).GetAwaiter().GetResult();
            ExecutePlayerStats(client).GetAwaiter().GetResult();

            Console.WriteLine("Finished");
        }

        private static async Task ExecuteApiDataStats(IRealmRoyaleApiClient client)
        {
            // Example contacting the API and getting a raw response from the client

            Console.WriteLine("Pinging API...");
            var ping = await client.PingAsync();
            Console.WriteLine(ping);
            Console.WriteLine();

            var dataUsed = await client.GetDataUsedWithHttpMessagesAsync();
            var rawResponseContent = await dataUsed.Response.Content.ReadAsStringAsync();
            Console.WriteLine(rawResponseContent);
            Console.WriteLine();
        }

        private static async Task ExecutePlayerStats(IRealmRoyaleApiClient client)
        {
            // Example fetching a player and his match history

            Player player = await client.GetPlayerAsync("overpowered", PlayerIdentifier.HiRez);
            Console.WriteLine($"{player.Name}, level: {player.Level}");

            Console.WriteLine("Last matches:");
            var matchHistory = await client.GetPlayerMatchHistoryAsync(player.Id);
            foreach (Match match in matchHistory.Matches.Take(5))
                Console.WriteLine($"{match.Id}: {match.MapGame} ({match.ClassName})");
        }

        private static async Task ExecuteQueuedMatches(IRealmRoyaleApiClient client)
        {
            // Example fetching siege matches played yesterday at noon

            // To reduce response times the HiRez API introduces time slices to fetch matches from a specific queue
            // An hour is divided into 6 parts (00, 10, 20, 30, 40, 50)

            DateTime date = DateTime.UtcNow.AddDays(-1);
            var hourSpan = new TimeSpan(12, 0, 0);
            var matchCount = 0;

            for (var min = 0; min < 60; min += 10)
            {
                var minSpan = new TimeSpan(0, min, 0);
                var queueData = await client.GetMatchIdsByQueueAsync(Queue.Solo, date, hourSpan, minSpan);
                matchCount += queueData.Count;
                Console.WriteLine($"Found {queueData.Count} matches in queue for slice {hourSpan},{minSpan}.");
            }

            // Or simply fetch the data from a whole hour
            var queueDataWholeHour = await client.GetMatchIdsByQueueAsync(Queue.Solo, date, hourSpan);
            Console.WriteLine($"Found {queueDataWholeHour.Count} matches in queue for {hourSpan}");

            Debug.Assert(queueDataWholeHour.Count == matchCount);
        }
    }
}