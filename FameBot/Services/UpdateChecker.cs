using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace FameBot.Services
{
    public static class UpdateChecker
    {
        private static readonly string VERSION = "1.0.0";
        private static readonly string verUrl = "https://raw.githubusercontent.com/thomas-crane/famebot/github-only/FameBot/Services/UpdateChecker.cs";
        public static void GetRemoteVersion(Action<string> callback)
        {
            using (HttpClient client = new HttpClient())
            {
                Task.Factory.StartNew(async () =>
                {
                    var response = await client.GetAsync(verUrl);
                    string version = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Version: " + version);
                    callback(version);
                });
            }
        }
        public static void NeedsUpdateAsync()
        {
            
        }
    }
}
