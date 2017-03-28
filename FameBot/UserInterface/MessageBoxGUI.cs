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
using FameBot.Data.Events;

namespace FameBot.UserInterface
{
    public partial class MessageBoxGUI : Form
    {
        public MessageBoxGUI()
        {
            InitializeComponent();
            Plugin.receiveMesssage += (s, e) =>
            {
                UpdateTextBox(e);
            };
            messageBox.KeyUp += (s, e) =>
            {
                if(e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(messageBox.Text))
                        return;
                    SendMessage();
                }
            };
            messageBox.TextChanged += (s, e) =>
            {
                charCountLabel.Text = string.Format("{0} / 128", messageBox.Text.Length);
                if (string.IsNullOrWhiteSpace(messageBox.Text))
                    sendButton.Enabled = false;
                else
                    sendButton.Enabled = true;
            };
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void UpdateTextBox(MessageEventArgs args)
        {
            if (this.incomingMessagesBox.InvokeRequired)
            {
                this.incomingMessagesBox.Invoke(new MethodInvoker(() =>
                {
                    UpdateTextBox(args);
                }));
            }
            else
            {
                incomingMessagesBox.Text += (args.FullMessage + "\n");
                incomingMessagesBox.SelectionStart = incomingMessagesBox.Text.Length;
                incomingMessagesBox.ScrollToCaret();
            }
        }

        private void SendMessage()
        {
            Plugin.InvokeSendMessageEvent(messageBox.Text);
            UpdateTextBox(new MessageEventArgs(messageBox.Text, "You"));
            messageBox.Text = "";
        }
    }
}
