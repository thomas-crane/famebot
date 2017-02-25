using Lib_K_Relay.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_K_Relay;
using System.Diagnostics;

namespace FameBot.Core
{
    public class Plugin : IPlugin
    {
        #region IPlugin
        public string GetAuthor()
        {
            return "Chicken";
        }

        public string[] GetCommands()
        {
            return new string[]
            {
                "TODO: list commands"
            };
        }

        public string GetDescription()
        {
            return "TODO: add description";
        }

        public string GetName()
        {
            return "FameBot by Chicken";
        }
        #endregion

        private IntPtr flashPtr;


        public void Initialize(Proxy proxy)
        {
            Process[] processes = Process.GetProcessesByName("flash");
            if (processes.Length == 1)
            {
                Console.WriteLine("[FameBot] Flash process handle aquired automatically.");
                flashPtr = processes[0].MainWindowHandle;
            } else if(processes.Length > 1)
            {
                Console.WriteLine("[FameBot] Multiple instances of flash are open. Please use the /activate command on the instance you want to use the bot with.");
            } else
            {
                Console.WriteLine("[FameBot] Couldn't find any instances of flash player. Use the /activate command when you have opened flash.");
                Console.WriteLine("[FameBot] FameBot will only detect instances of flash player which are called \"flash.exe\"");
            }
        }
    }
}
