using FameBot.Core;
using FameBot.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using FameBot.Data.Events;
using FameBot.Data.Models;
using Lib_K_Relay.Networking;

namespace FameBot.UserInterface
{
    public partial class FameBotGUI : Form
    {
        public List<Player> managedClients;
        private const uint WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;

        public FameBotGUI()
        {
            InitializeComponent();
            managedClients = new List<Player>();
            eventLog.Text += "\n";
            FormClosed += (s, e) =>
            {
                Plugin.InvokeGuiEvent(GuiEvent.GuiClosed, null);
            };
            Plugin.logEvent += (s, e) =>
            {
                UpdateEventLog(s, e);
            };
        }

        public void AddClient(Player player)
        {
            if (!managedClients.Contains(player))
            {
                managedClients.Add(player);
            }
            clientBox.DataSource = managedClients.Select(p => p.Client.PlayerData.Name).ToList();
        }

        private void UpdateEventLog(object sender, LogEventArgs args)
        {
            if (this.eventLog.InvokeRequired)
            {
                this.eventLog.BeginInvoke(new MethodInvoker(() =>
                {
                    eventLog.Text += (args.MessageWithTimestamp + "\n");
                    Plugin.SendMessage(eventLog.Handle, WM_VSCROLL, new IntPtr(SB_PAGEBOTTOM), IntPtr.Zero);
                }));
                return;
            }

            eventLog.Text += (args.MessageWithTimestamp + "\n");
            Plugin.SendMessage(eventLog.Handle, WM_VSCROLL, new IntPtr(SB_PAGEBOTTOM), IntPtr.Zero);
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            var name = clientBox.SelectedItem as string;
            var player = managedClients.Single(c => c.Client.PlayerData.Name == name);
            Plugin.InvokeGuiEvent(GuiEvent.StartBot, player);
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            var name = clientBox.SelectedItem as string;
            var player = managedClients.Single(c => c.Client.PlayerData.Name == name);
            Plugin.InvokeGuiEvent(GuiEvent.StopBot, player);
        }

        private void windowOnTopBox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = windowOnTopBox.Checked;
        }

        private void showHealthBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HealthBarGUI healthBarGUI = new HealthBarGUI();
            healthBarGUI.Show();
        }

        private void showKeyPressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyPressGUI keyPressGUI = new KeyPressGUI();
            keyPressGUI.Show();
        }

        private void openConfigManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsGUI settingsGUI = new SettingsGUI();
            settingsGUI.Show();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            eventLog.Text = "";
        }

        private void showGraphicsOverlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OverlayGUI overlayGUI = new OverlayGUI(flashPtr);
            //overlayGUI.Show();
        }

        private void inGameChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxGUI messageBoxGui = new MessageBoxGUI();
            messageBoxGui.Show();
        }

        private void showFameBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FameBarGUI fameBarGui = new FameBarGUI();
            fameBarGui.Show();
        }
    }
}
