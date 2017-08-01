using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using Lib_K_Relay.Utilities;

namespace FameBot.Services
{
    public static class UpdateChecker
    {
        private static readonly string VERSION = "1.0.0";
        private static readonly string verUrl = "https://raw.githubusercontent.com/thomas-crane/famebot/github-only/FameBot/Services/UpdateChecker.cs";
        public static void GetRemoteVersion(Action<string> callback)
        {
            HttpClient client = new HttpClient();
            Task.Factory.StartNew(async () =>
            {
                HttpResponseMessage response = await client.GetAsync(verUrl);
                string version = await response.Content.ReadAsStringAsync();
                client.Dispose();
                callback(version);
            });
        }
        public static void NeedsUpdateAsync(Action<bool, string>callback)
        {
            PluginUtils.Log("FameBot", "Checking FameBot version after small delay...");
            PluginUtils.Delay(2000, () =>
            {
                PluginUtils.Log("FameBot", "Checking FameBot version...");
                string pattern = @"(\d\.\d\.\d)";
                GetRemoteVersion((version) =>
                {
                    var matched = Regex.Match(version, pattern);
                    if (matched == null)
                    {
                        Console.WriteLine("Match was null");
                        callback.Invoke(true, "Couldn't get version info. Check the GitHub manually to check if you have the latest version.");
                    }
                    else
                    {
                        if (VERSION != matched.Value)
                        {
                            callback.Invoke(true, $"A new version is available on GitHub!\nYour version: {VERSION}, GitHub version: {matched.Value}");
                        }
                        else
                        {
                            callback.Invoke(false, null);
                        }
                    }
                });
            });
        }
    }
}
