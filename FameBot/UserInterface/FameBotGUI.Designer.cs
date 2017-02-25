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
            this.SuspendLayout();
            // 
            // windowOnTopBox
            // 
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
            this.onButton.Location = new System.Drawing.Point(13, 13);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(253, 40);
            this.onButton.TabIndex = 1;
            this.onButton.Text = "Start Bot";
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // offButton
            // 
            this.offButton.Location = new System.Drawing.Point(13, 59);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(253, 40);
            this.offButton.TabIndex = 2;
            this.offButton.Text = "Stop Bot";
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // FameBotGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.offButton);
            this.Controls.Add(this.onButton);
            this.Controls.Add(this.windowOnTopBox);
            this.Name = "FameBotGUI";
            this.Text = "FameBotGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox windowOnTopBox;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Button offButton;
    }
}