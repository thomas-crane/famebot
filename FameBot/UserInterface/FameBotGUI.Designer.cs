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
            this.windowOnTopBox = new System.Windows.Forms.CheckBox();
            this.onButton = new System.Windows.Forms.Button();
            this.offButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHealthBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showKeyPressesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(580, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHealthBarToolStripMenuItem,
            this.showKeyPressesToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // showHealthBarToolStripMenuItem
            // 
            this.showHealthBarToolStripMenuItem.Name = "showHealthBarToolStripMenuItem";
            this.showHealthBarToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.showHealthBarToolStripMenuItem.Text = "Show health bar";
            this.showHealthBarToolStripMenuItem.Click += new System.EventHandler(this.showHealthBarToolStripMenuItem_Click);
            // 
            // showKeyPressesToolStripMenuItem
            // 
            this.showKeyPressesToolStripMenuItem.Name = "showKeyPressesToolStripMenuItem";
            this.showKeyPressesToolStripMenuItem.Size = new System.Drawing.Size(237, 30);
            this.showKeyPressesToolStripMenuItem.Text = "Show key presses";
            this.showKeyPressesToolStripMenuItem.Click += new System.EventHandler(this.showKeyPressesToolStripMenuItem_Click);
            // 
            // FameBotGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 244);
            this.Controls.Add(this.offButton);
            this.Controls.Add(this.onButton);
            this.Controls.Add(this.windowOnTopBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
    }
}