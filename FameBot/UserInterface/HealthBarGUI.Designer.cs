namespace FameBot.UserInterface
{
    partial class HealthBarGUI
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
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.onTopCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // healthBar
            // 
            this.healthBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.healthBar.ForeColor = System.Drawing.Color.Lime;
            this.healthBar.Location = new System.Drawing.Point(13, 12);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(353, 43);
            this.healthBar.Step = 1;
            this.healthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.healthBar.TabIndex = 0;
            // 
            // onTopCheckBox
            // 
            this.onTopCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.onTopCheckBox.AutoSize = true;
            this.onTopCheckBox.Checked = true;
            this.onTopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onTopCheckBox.Location = new System.Drawing.Point(13, 61);
            this.onTopCheckBox.Name = "onTopCheckBox";
            this.onTopCheckBox.Size = new System.Drawing.Size(191, 24);
            this.onTopCheckBox.TabIndex = 1;
            this.onTopCheckBox.Text = "Window always on top";
            this.onTopCheckBox.UseVisualStyleBackColor = true;
            this.onTopCheckBox.CheckedChanged += new System.EventHandler(this.onTopCheckBox_CheckedChanged);
            // 
            // HealthBarGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 89);
            this.Controls.Add(this.onTopCheckBox);
            this.Controls.Add(this.healthBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(255, 145);
            this.Name = "HealthBarGUI";
            this.Text = "[FameBot] Health";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.CheckBox onTopCheckBox;
    }
}