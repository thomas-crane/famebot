using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FameBot.Core;
using FameBot.Helpers;

namespace FameBot.UserInterface
{
    public partial class FameBarGUI : Form
    {
        private Plugin.FameUpdateEventHandler fameUpdateHandler;
        private int currentFame = -1;
        public FameBarGUI()
        {
            InitializeComponent();
            fameUpdateHandler = new Plugin.FameUpdateEventHandler((s, e) =>
            {
                int newFame = e.Fame;
                if (e.FameGoal != -1)
                {
                    fameBar.Value = (int)((e.Fame / (float)e.FameGoal) * 100);
                    fameText.Text = string.Concat(e.Fame, " / ", e.FameGoal);
                }
                else
                {
                    fameBar.Value = 100;
                    fameText.Text = e.Fame.ToString();
                }
                if (currentFame != newFame)
                {
                    currentFame = newFame;
                }
            });

            Plugin.fameUpdate += fameUpdateHandler;

            this.FormClosing += (s, e) =>
            {
                Plugin.fameUpdate -= fameUpdateHandler;
            };
        }

        private void onTopBox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = onTopBox.Checked;
        }
    }
}
