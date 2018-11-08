using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MalCrawler.Profile
{
    public static class Statistics
    {
        private static HttpClient _client = new HttpClient();
        private static readonly HtmlDocument Doc = new HtmlDocument();

        private static readonly Regex RegexMeanScore = new Regex("(?<=Mean Score: )[0-9].[0-9]");

        static Statistics()
        {

        }

        public static void LoadCredentials(ICredentials credentials)
        {
            HttpClientHandler handler = new HttpClientHandler() {Credentials = credentials};
            _client = new HttpClient(handler);
        }

        private static async Task<string> GetResponseAsync(string url)
        {
            string response = "";
            try
            {
                response = await _client.GetStringAsync(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

            return response;
        } 

        public static async Task<double> GetAnimeCompletedMeanAsync(string username)
        {
            string url = $"https://myanimelist.net/animelist/{username}?status=2&tag=";
            string xpath = @"//td[@class='category_totals']";

            string response = await GetResponseAsync(url);
            if(response == null) return 0.0;
            Doc.LoadHtml(response);

            var meanNode = Doc.DocumentNode.SelectSingleNode(xpath).ChildNodes[2].InnerText;
            if (meanNode == null)
                throw new Exception();
            var match = RegexMeanScore.Match(meanNode);
            if (!match.Success)
                throw new Exception();

            return double.Parse(match.Value);
        }

        public static async Task<double> GetAnimeMeanAsync(string username)
        {
            string url = $"https://myanimelist.net/profile/{username}";
            //string xpath =@"//*[@id=""statistics""]/div[1]/div[1]/div[1]/div[2]";
            string xpath = @"//*[@id=""statistics""]/div[1]/div[1]/div[1]/div[2]/text()";
            
            string response = await GetResponseAsync(url);
            if (response == null) return 0.0;
            Doc.LoadHtml(response);

            var meanNode = Doc.DocumentNode.SelectSingleNode(xpath);
            var mean = double.Parse(meanNode.InnerText);

            return mean;
        }
    }
}
