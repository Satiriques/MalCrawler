using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MalCrawler.Profile;
using MalCrawler.Utility;

namespace MalCrawler
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bar = Logger.StartProgressBar(10);

            for (int i = 0; i < 10; i++)
            {
                bar.Increment();
            }
            //int index = 0;
            //for (int i = 0; i < 300; i++)
            //{
            //    //index = (index + 100 - 1) % 100;
            //    index = (index + 1) % 100;
            //    Console.WriteLine(index);
            //}

            //var credentials = new CredentialCache();
            //var test2= credentials.GetCredential(new Uri("http://msdn.com/"), "Basic");
            //Statistics.LoadCredentials(credentials);

            //var completedMean = await Statistics.GetAnimeCompletedMeanAsync("satiriques");
            //var mean = await Statistics.GetAnimeMeanAsync("satiriques");

            //Console.WriteLine($"Satiriques Anime mean: {mean} Completed Anime mean: {completedMean}");

            Console.ReadKey();
        }
    }
}
