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
using FameBot.Data.Enums;
using FameBot.Properties;

namespace FameBot.UserInterface
{
    public partial class KeyPressGUI : Form
    {
        private Plugin.KeyEventHandler keyEventHandler;
        public KeyPressGUI()
        {
            InitializeComponent();

            keyEventHandler = new Plugin.KeyEventHandler((s, e) =>
            {
                switch (e.Key)
                {
                    case Key.W:
                        if (e.Value)
                            wBox.Image = Resources.w_on;
                        else
                            wBox.Image = Resources.w_off;
                        break;
                    case Key.A:
                        if (e.Value)
                            aBox.Image = Resources.a_on;
                        else
                            aBox.Image = Resources.a_off;
                        break;
                    case Key.S:
                        if (e.Value)
                            sBox.Image = Resources.s_on;
                        else
                            sBox.Image = Resources.s_off;
                        break;
                    case Key.D:
                        if (e.Value)
                            dBox.Image = Resources.d_on;
                        else
                            dBox.Image = Resources.d_off;
                        break;
                }
            });

            Plugin.keyChanged += keyEventHandler;

            this.FormClosing += (s, e) =>
            {
                Plugin.keyChanged -= keyEventHandler;
            };
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkBox1.Checked;
        }
    }
}
