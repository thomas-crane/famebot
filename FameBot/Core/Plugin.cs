using Lib_K_Relay.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_K_Relay;
using System.Diagnostics;
using FameBot.Data.Enums;
using FameBot.Data.Models;
using Lib_K_Relay.Networking;
using System.Runtime.InteropServices;

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
        private bool followTarget = false;
        private Queue<Target> targets;

        #region WINAPI
        // Get the focused window
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();
        #endregion

        public void Initialize(Proxy proxy)
        {
            targets = new Queue<Target>();

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

            proxy.ClientConnected += (client) =>
            {
                Stop();
            };
        }

        private void ReceiveCommand(Client client, string cmd, string[] args)
        {
            switch(cmd)
            {
                case "activate":
                    flashPtr = GetForegroundWindow();
                    break;
            }
        }

        private void GuiEventCallback(GuiEvent evt)
        {
            switch (evt)
            {
                case GuiEvent.StartBot:

                    break;
                case GuiEvent.StopBot:
                    Stop();
                    break;
            }
        }

        private void Stop()
        {
            followTarget = false;
            targets.Clear();
        }
    }
}
