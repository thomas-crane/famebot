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
    }
}
