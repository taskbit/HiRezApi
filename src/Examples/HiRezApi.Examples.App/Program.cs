namespace HiRezApi.Examples.App
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using HiRezApi.Common;
    using HiRezApi.Paladins;
    using Microsoft.Rest.TransientFaultHandling;

    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Executing...");

            var retryPolicy = new RetryPolicy<HiRezApiRetryStrategy>(new ExponentialBackoffRetryStrategy());
            var credentials = new HiRezApiCredentials("YourDeveloperId", "YourAuthKey");
            var client = new PaladinsApiClient(Platform.Pc, credentials);
            client.SetRetryPolicy(retryPolicy);

            ExecutePaladinsApiDataStats(client).GetAwaiter().GetResult();
            ExecutePaladinsApiQueuedMatches(client).GetAwaiter().GetResult();
            ExecutePaladinsApiPlayerStats(client).GetAwaiter().GetResult();

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
        
        private static async Task ExecutePaladinsApiDataStats(IPaladinsApiClient client)
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

        private static async Task ExecutePaladinsApiPlayerStats(IPaladinsApiClient client)
        {
            // Example fetching a player and his match history

            var player = await client.GetPlayerAsync("bugzy");
            Console.WriteLine($"{player.Name}, matches played: {player.Wins + player.Losses}");

            Console.WriteLine("Last matches:");
            var matchHistory = await client.GetMatchHistoryAsync(player.Id);
            foreach (var match in matchHistory.Take(5))
                Console.WriteLine($"{match.Match}: {match.Champion} ({match.WinStatus})");
        }

        private static async Task ExecutePaladinsApiQueuedMatches(IPaladinsApiClient client)
        {
            // Example fetching siege matches played yesterday at noon

            // To reduce response times the HiRez API introduces time slices to fetch matches from a specific queue
            // An hour is divided into 6 parts (00, 10, 20, 30, 40, 50)

            var date = DateTime.UtcNow.AddDays(-1);
            var hourSpan = new TimeSpan(12, 0, 0);
            var matchCount = 0;

            for (var min = 0; min < 60; min += 10)
            {
                var minSpan = new TimeSpan(0, min, 0);
                var queueData = await client.GetMatchIdsByQueueAsync(Queue.Siege, date, hourSpan, minSpan);
                matchCount += queueData.Count;
                Console.WriteLine($"Found {queueData.Count} matches in queue for slice {hourSpan},{minSpan}.");
            }

            // Or simply fetch the data from a whole hour
            var queueDataWholeHour = await client.GetMatchIdsByQueueAsync(Queue.Siege, date, hourSpan);
            Console.WriteLine($"Found {queueDataWholeHour.Count} matches in queue for {hourSpan}");

            Debug.Assert(queueDataWholeHour.Count == matchCount);
        }
    }
}