using System;
using System.Threading.Tasks;
using RiotNet;
using RiotNet.Models;

namespace RiotAPI
{
    class Program
    {
        static string API_KEY_PATH = System.IO.Directory.GetCurrentDirectory() + "/key.txt";

        static void Main(string[] args)
        {
            Get();
            Console.ReadKey();
        }
        static async void Get()
        {
            string account;
            Console.Write("Enter an account: ");
            account = Console.ReadLine();
            await GetSummonerData(account);
        }
        static async Task GetSummonerData(string summonerName)
        {
            try
            {
                IRiotClient client = new RiotClient(new RiotClientSettings
                {
                    ApiKey = System.IO.File.ReadAllText(API_KEY_PATH)
                });

                Summoner summoner = await client.GetSummonerBySummonerNameAsync(summonerName, PlatformId.EUW1).ConfigureAwait(false);
                Console.WriteLine($"Summoner Name: {summoner.Name}");
                Console.WriteLine($"Summoner Platform ID: {PlatformId.EUW1}");
                Console.WriteLine($"Summoner ID: {summoner.Id}");
                Console.WriteLine($"Summoner Level: {summoner.SummonerLevel}");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Invalid account");
            }
        }
    }
}
