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
using FameBot.Services;

namespace FameBot.UserInterface
{
    public partial class FameBotGUI : Form
    {
        private IntPtr flashPtr;
        private string processName;
        private const uint WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;

        public FameBotGUI()
        {
            InitializeComponent();
            eventLog.Text += "\n";
            FormClosed += (s, e) =>
            {
                Plugin.InvokeGuiEvent(GuiEvent.GuiClosed);
            };
            Plugin.logEvent += (s, e) =>
            {
                UpdateEventLog(s, e);
            };
        }

        private void UpdateEventLog(object sender, LogEventArgs args)
        {
            if (this.eventLog.InvokeRequired)
            {
                this.eventLog.BeginInvoke(new MethodInvoker(() =>
                {
                    eventLog.Text += (args.MessageWithTimestamp + "\n");
                    WinApi.SendMessage(eventLog.Handle, WM_VSCROLL, new IntPtr(SB_PAGEBOTTOM), IntPtr.Zero);
                }));
                return;
            }

            eventLog.Text += (args.MessageWithTimestamp + "\n");
            WinApi.SendMessage(eventLog.Handle, WM_VSCROLL, new IntPtr(SB_PAGEBOTTOM), IntPtr.Zero);
        }

        public void SetHandle(IntPtr handle)
        {
            flashPtr = handle;
            try
            {
                processName = Process.GetProcesses().Single(p => p.MainWindowHandle == handle).ProcessName;
            }
            catch
            {
                processName = "Unknown process.";
            }
            if(currentProcessLabel.InvokeRequired)
            {
                currentProcessLabel.BeginInvoke(new MethodInvoker(() =>
                {
                    currentProcessLabel.Text = "Bot bound to process:\n" + processName;
                }));
            }
            else
            {
                currentProcessLabel.Text = "Bot bound to process:\n" + processName;
            }
        }

        public void ShowChangeFlashNameMessage(string found, string current, Action updateCallback)
        {
            // Do this on a new thread so Plugin isn't blocked.
            new System.Threading.Thread(() =>
            {
                DialogResult result = MessageBox.Show(this, "FameBot is bound to \"" + found + "\" but is searching for \"" + current + "\" when it starts. Update the config to search for \"" + found + "\" instead?", "FameBot", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    updateCallback.Invoke();
                }
            }).Start();
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            Plugin.InvokeGuiEvent(GuiEvent.StartBot);
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            Plugin.InvokeGuiEvent(GuiEvent.StopBot);
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
            OverlayGUI overlayGUI = new OverlayGUI(flashPtr);
            overlayGUI.Show();
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
