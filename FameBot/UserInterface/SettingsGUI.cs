using FameBot.Core;
using FameBot.Data.Enums;
using FameBot.Data.Models;
using FameBot.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FameBot.UserInterface
{
    public partial class SettingsGUI : Form
    {
        private Configuration config;
        public SettingsGUI()
        {
            InitializeComponent();

            config = ConfigManager.GetConfiguration();
            UpdateUI(config);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Configuration newConfig = new Configuration()
            {
                AutonexusThreshold = (float)autoNexusPercent.Value,
                TickCountThreshold = (int)tickPerScan.Value,
                EscapeIfNoTargets = escapeIfNoTargets.Checked,
                TeleportDistanceThreshold = (float)teleportDistanceThreshold.Value,
                FollowDistanceThreshold = (float)followDistanceThreshold.Value,
                AutoConnect = autoConnect.Checked,
                FindClustersNearCenter = findNearCenter.Checked,
                Epsilon = (float)epsilon.Value,
                MinPoints = (int)minPoints.Value
            };
            ConfigManager.WriteXML(newConfig);
            MessageBox.Show("Settings have been saved", "[FameBot]");
            
            // There is a 0.5 second delay between saving settings and telling Plugin
            // that the settings have changes due to a problem with Windows indexing
            // where if a file is written to and then read from immediately afterwards
            // an error will be thrown.
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(0.5));
                Plugin.InvokeGuiEvent(GuiEvent.SettingsChanged, null);
            });
        }

        private void UpdateUI(Configuration cfg)
        {
            autoNexusPercent.Value = (decimal)cfg.AutonexusThreshold;
            tickPerScan.Value = cfg.TickCountThreshold;
            tickLabel.Text = cfg.TickCountThreshold == 1 ? "tick" : "ticks";
            escapeIfNoTargets.Checked = cfg.EscapeIfNoTargets;
            teleportDistanceThreshold.Value = (decimal)cfg.TeleportDistanceThreshold;
            followDistanceThreshold.Value = (decimal)cfg.FollowDistanceThreshold;
            autoConnect.Checked = cfg.AutoConnect;
            findNearCenter.Checked = cfg.FindClustersNearCenter;
            epsilon.Value = (decimal)cfg.Epsilon;
            minPoints.Value = cfg.MinPoints;
        }
    }
}
