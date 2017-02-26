using FameBot.Data.Enums;
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
    public partial class FameBotGUI : Form
    {
        private Action<GuiEvent> eventCallback;
        public FameBotGUI()
        {
            InitializeComponent();
        }
        
        public FameBotGUI(Action<GuiEvent> callback)
        {
            eventCallback = callback;
            InitializeComponent();
            FormClosed += (s, e) =>
            {
                eventCallback?.Invoke(GuiEvent.GuiClosed);
            };
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            eventCallback(GuiEvent.StartBot);
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            eventCallback(GuiEvent.StopBot);
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

        }
    }
}
