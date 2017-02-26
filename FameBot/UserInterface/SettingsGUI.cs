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
                Epsilon = (float)epsilon.Value,
                MinPoints = (int)minPoints.Value
            };
            ConfigManager.WriteXML(newConfig);
        }

        private void UpdateUI(Configuration cfg)
        {
            autoNexusPercent.Value = (decimal)cfg.AutonexusThreshold;
            tickPerScan.Value = cfg.TickCountThreshold;
            tickLabel.Text = cfg.TickCountThreshold == 1 ? "tick" : "ticks";
            escapeIfNoTargets.Checked = cfg.EscapeIfNoTargets;
            teleportDistanceThreshold.Value = (decimal)cfg.TeleportDistanceThreshold;
            followDistanceThreshold.Value = (decimal)cfg.FollowDistanceThreshold;
            findNearCenter.Checked = cfg.FindClustersNearCenter;
            epsilon.Value = (decimal)cfg.Epsilon;
            minPoints.Value = cfg.MinPoints;
        }
    }
}
