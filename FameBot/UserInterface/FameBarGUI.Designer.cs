namespace FameBot.UserInterface
{
    partial class FameBarGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FameBarGUI));
            this.onTopBox = new System.Windows.Forms.CheckBox();
            this.fameBar = new System.Windows.Forms.ProgressBar();
            this.fameText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // onTopBox
            // 
            this.onTopBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.onTopBox.AutoSize = true;
            this.onTopBox.Checked = true;
            this.onTopBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onTopBox.Location = new System.Drawing.Point(14, 62);
            this.onTopBox.Name = "onTopBox";
            this.onTopBox.Size = new System.Drawing.Size(191, 24);
            this.onTopBox.TabIndex = 0;
            this.onTopBox.Text = "Window always on top";
            this.onTopBox.UseVisualStyleBackColor = true;
            this.onTopBox.CheckedChanged += new System.EventHandler(this.onTopBox_CheckedChanged);
            // 
            // fameBar
            // 
            this.fameBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fameBar.BackColor = System.Drawing.SystemColors.Control;
            this.fameBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.fameBar.Location = new System.Drawing.Point(14, 12);
            this.fameBar.Name = "fameBar";
            this.fameBar.Size = new System.Drawing.Size(352, 43);
            this.fameBar.TabIndex = 1;
            // 
            // fameText
            // 
            this.fameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fameText.Location = new System.Drawing.Point(212, 66);
            this.fameText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fameText.Name = "fameText";
            this.fameText.Size = new System.Drawing.Size(150, 23);
            this.fameText.TabIndex = 2;
            this.fameText.Text = "0 / 0";
            this.fameText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FameBarGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 106);
            this.Controls.Add(this.fameText);
            this.Controls.Add(this.fameBar);
            this.Controls.Add(this.onTopBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(252, 136);
            this.Name = "FameBarGUI";
            this.Text = "[FameBot] Fame";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox onTopBox;
        private System.Windows.Forms.ProgressBar fameBar;
        private System.Windows.Forms.Label fameText;
    }
}