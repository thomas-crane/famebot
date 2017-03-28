namespace FameBot.UserInterface
{
    partial class MessageBoxGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageBox = new System.Windows.Forms.TextBox();
            this.onTopBox = new System.Windows.Forms.CheckBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.incomingMessagesBox = new System.Windows.Forms.RichTextBox();
            this.charCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBox.Location = new System.Drawing.Point(12, 265);
            this.messageBox.MaxLength = 128;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(554, 26);
            this.messageBox.TabIndex = 0;
            // 
            // onTopBox
            // 
            this.onTopBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.onTopBox.AutoSize = true;
            this.onTopBox.Location = new System.Drawing.Point(12, 308);
            this.onTopBox.Name = "onTopBox";
            this.onTopBox.Size = new System.Drawing.Size(191, 24);
            this.onTopBox.TabIndex = 1;
            this.onTopBox.Text = "Window always on top";
            this.onTopBox.UseVisualStyleBackColor = true;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(454, 302);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(112, 34);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // incomingMessagesBox
            // 
            this.incomingMessagesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.incomingMessagesBox.Location = new System.Drawing.Point(12, 13);
            this.incomingMessagesBox.Name = "incomingMessagesBox";
            this.incomingMessagesBox.Size = new System.Drawing.Size(554, 246);
            this.incomingMessagesBox.TabIndex = 3;
            this.incomingMessagesBox.Text = "";
            // 
            // charCountLabel
            // 
            this.charCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.charCountLabel.AutoSize = true;
            this.charCountLabel.Location = new System.Drawing.Point(391, 308);
            this.charCountLabel.Name = "charCountLabel";
            this.charCountLabel.Size = new System.Drawing.Size(57, 20);
            this.charCountLabel.TabIndex = 4;
            this.charCountLabel.Text = "0 / 128";
            this.charCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MessageBoxGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 344);
            this.Controls.Add(this.charCountLabel);
            this.Controls.Add(this.incomingMessagesBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.onTopBox);
            this.Controls.Add(this.messageBox);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MessageBoxGUI";
            this.Text = "MessageBoxGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.CheckBox onTopBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.RichTextBox incomingMessagesBox;
        private System.Windows.Forms.Label charCountLabel;
    }
}