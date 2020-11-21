using System;
using RiotNet;
using RiotNet.Models;

namespace RiotAPI
{
    class Program
    {
        static string API_KEY_PATH = System.IO.Directory.GetCurrentDirectory() + "/key.txt";

        static void Main(string[] args)
        {
            GetSummonerData();
            Console.ReadKey();
        }
        static async void GetSummonerData()
        {
            IRiotClient client = new RiotClient(new RiotClientSettings
            {
                ApiKey = System.IO.File.ReadAllText(API_KEY_PATH)
            });

            Summoner summoner = await client.GetSummonerBySummonerNameAsync("KDani99", PlatformId.EUW1).ConfigureAwait(false);
            Console.WriteLine($"Summoner Name: {summoner.Name}");
            Console.WriteLine($"Summoner Platform ID: {PlatformId.EUW1}");
            Console.WriteLine($"Summoner ID: {summoner.Id}");
            Console.WriteLine($"Summoner Level: {summoner.SummonerLevel}");
        }
    }
}
