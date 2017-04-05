namespace FameBot.UserInterface
{
    partial class FameBotGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FameBotGUI));
            this.windowOnTopBox = new System.Windows.Forms.CheckBox();
            this.onButton = new System.Windows.Forms.Button();
            this.offButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHealthBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showKeyPressesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGraphicsOverlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inGameChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.currentProcessLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowOnTopBox
            // 
            this.windowOnTopBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.windowOnTopBox.AutoSize = true;
            this.windowOnTopBox.Location = new System.Drawing.Point(13, 208);
            this.windowOnTopBox.Name = "windowOnTopBox";
            this.windowOnTopBox.Size = new System.Drawing.Size(191, 24);
            this.windowOnTopBox.TabIndex = 0;
            this.windowOnTopBox.Text = "Window always on top";
            this.windowOnTopBox.UseVisualStyleBackColor = true;
            this.windowOnTopBox.CheckedChanged += new System.EventHandler(this.windowOnTopBox_CheckedChanged);
            // 
            // onButton
            // 
            this.onButton.Location = new System.Drawing.Point(13, 52);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(253, 40);
            this.onButton.TabIndex = 1;
            this.onButton.Text = "Start Bot";
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // offButton
            // 
            this.offButton.Location = new System.Drawing.Point(13, 98);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(253, 40);
            this.offButton.TabIndex = 2;
            this.offButton.Text = "Stop Bot";
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.utilitiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(578, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHealthBarToolStripMenuItem,
            this.showKeyPressesToolStripMenuItem,
            this.showGraphicsOverlayToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // showHealthBarToolStripMenuItem
            // 
            this.showHealthBarToolStripMenuItem.Name = "showHealthBarToolStripMenuItem";
            this.showHealthBarToolStripMenuItem.Size = new System.Drawing.Size(275, 30);
            this.showHealthBarToolStripMenuItem.Text = "Show health bar";
            this.showHealthBarToolStripMenuItem.Click += new System.EventHandler(this.showHealthBarToolStripMenuItem_Click);
            // 
            // showKeyPressesToolStripMenuItem
            // 
            this.showKeyPressesToolStripMenuItem.Name = "showKeyPressesToolStripMenuItem";
            this.showKeyPressesToolStripMenuItem.Size = new System.Drawing.Size(275, 30);
            this.showKeyPressesToolStripMenuItem.Text = "Show key presses";
            this.showKeyPressesToolStripMenuItem.Click += new System.EventHandler(this.showKeyPressesToolStripMenuItem_Click);
            // 
            // showGraphicsOverlayToolStripMenuItem
            // 
            this.showGraphicsOverlayToolStripMenuItem.Enabled = false;
            this.showGraphicsOverlayToolStripMenuItem.Name = "showGraphicsOverlayToolStripMenuItem";
            this.showGraphicsOverlayToolStripMenuItem.Size = new System.Drawing.Size(275, 30);
            this.showGraphicsOverlayToolStripMenuItem.Text = "Show graphics overlay";
            this.showGraphicsOverlayToolStripMenuItem.Click += new System.EventHandler(this.showGraphicsOverlayToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConfigManagerToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // openConfigManagerToolStripMenuItem
            // 
            this.openConfigManagerToolStripMenuItem.Name = "openConfigManagerToolStripMenuItem";
            this.openConfigManagerToolStripMenuItem.Size = new System.Drawing.Size(274, 30);
            this.openConfigManagerToolStripMenuItem.Text = "Open Config Manager";
            this.openConfigManagerToolStripMenuItem.Click += new System.EventHandler(this.openConfigManagerToolStripMenuItem_Click);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inGameChatToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(81, 29);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // inGameChatToolStripMenuItem
            // 
            this.inGameChatToolStripMenuItem.Name = "inGameChatToolStripMenuItem";
            this.inGameChatToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.inGameChatToolStripMenuItem.Text = "In-Game Chat";
            this.inGameChatToolStripMenuItem.Click += new System.EventHandler(this.inGameChatToolStripMenuItem_Click);
            // 
            // eventLog
            // 
            this.eventLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventLog.Location = new System.Drawing.Point(276, 78);
            this.eventLog.Name = "eventLog";
            this.eventLog.ReadOnly = true;
            this.eventLog.Size = new System.Drawing.Size(290, 154);
            this.eventLog.TabIndex = 4;
            this.eventLog.Text = "---- Start of Log ----";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Event Log";
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(455, 42);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(110, 30);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear log";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // currentProcessLabel
            // 
            this.currentProcessLabel.AutoSize = true;
            this.currentProcessLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.currentProcessLabel.Location = new System.Drawing.Point(13, 145);
            this.currentProcessLabel.Name = "currentProcessLabel";
            this.currentProcessLabel.Size = new System.Drawing.Size(192, 40);
            this.currentProcessLabel.TabIndex = 7;
            this.currentProcessLabel.Text = "Bot not bound to process.\r\nUse /bind in-game.";
            // 
            // FameBotGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 244);
            this.Controls.Add(this.currentProcessLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eventLog);
            this.Controls.Add(this.offButton);
            this.Controls.Add(this.onButton);
            this.Controls.Add(this.windowOnTopBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "FameBotGUI";
            this.Text = "FameBot";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox windowOnTopBox;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHealthBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showKeyPressesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConfigManagerToolStripMenuItem;
        private System.Windows.Forms.RichTextBox eventLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ToolStripMenuItem showGraphicsOverlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inGameChatToolStripMenuItem;
        private System.Windows.Forms.Label currentProcessLabel;
    }
}