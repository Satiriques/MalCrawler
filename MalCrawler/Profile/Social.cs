using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MalCrawler.Profile
{
    public static class Social
    {
        static HttpClient Client = new HttpClient();
        public static async Task<string[]> GetFriendsAsync(string username)
        {
            string[] friends = null;

            return friends;
        }

        private static async Task<string[]> GetFriendsPages(string username)
        {
            string[] urls = null;

            return urls;
        }

        private static async Task<string[]> GetFriendsFromPage(string pageUrl)
        {
            string[] friends = null;

            return friends;
        }
    }
}
