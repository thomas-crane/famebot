namespace FameBot.UserInterface
{
    partial class SettingsGUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsGUI));
            this.generalSettings = new System.Windows.Forms.GroupBox();
            this.autoConnect = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.followDistanceThreshold = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.teleportDistanceThreshold = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.escapeIfNoTargets = new System.Windows.Forms.CheckBox();
            this.autoNexusPercent = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.findNearCenter = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tickLabel = new System.Windows.Forms.Label();
            this.tickPerScan = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.minPoints = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.epsilon = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.txbxFlashProjectorName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.generalSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.followDistanceThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teleportDistanceThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoNexusPercent)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tickPerScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epsilon)).BeginInit();
            this.SuspendLayout();
            // 
            // generalSettings
            // 
            this.generalSettings.Controls.Add(this.label12);
            this.generalSettings.Controls.Add(this.txbxFlashProjectorName);
            this.generalSettings.Controls.Add(this.autoConnect);
            this.generalSettings.Controls.Add(this.label8);
            this.generalSettings.Controls.Add(this.followDistanceThreshold);
            this.generalSettings.Controls.Add(this.label5);
            this.generalSettings.Controls.Add(this.label4);
            this.generalSettings.Controls.Add(this.teleportDistanceThreshold);
            this.generalSettings.Controls.Add(this.label3);
            this.generalSettings.Controls.Add(this.escapeIfNoTargets);
            this.generalSettings.Controls.Add(this.autoNexusPercent);
            this.generalSettings.Controls.Add(this.label2);
            this.generalSettings.Location = new System.Drawing.Point(8, 36);
            this.generalSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.generalSettings.Name = "generalSettings";
            this.generalSettings.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.generalSettings.Size = new System.Drawing.Size(289, 135);
            this.generalSettings.TabIndex = 0;
            this.generalSettings.TabStop = false;
            this.generalSettings.Text = "General";
            // 
            // autoConnect
            // 
            this.autoConnect.AutoSize = true;
            this.autoConnect.Checked = true;
            this.autoConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoConnect.Location = new System.Drawing.Point(7, 110);
            this.autoConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.autoConnect.Name = "autoConnect";
            this.autoConnect.Size = new System.Drawing.Size(88, 17);
            this.autoConnect.TabIndex = 9;
            this.autoConnect.Text = "AutoConnect";
            this.toolTip1.SetToolTip(this.autoConnect, "If this is checked the bot will automatically\r\nwalk to the most full realm and co" +
        "nnect to it\r\nwhen it is in the nexus. If it has to, it will stop\r\nto heal on the" +
        " way.\r\n");
            this.autoConnect.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 56);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "tiles";
            // 
            // followDistanceThreshold
            // 
            this.followDistanceThreshold.DecimalPlaces = 1;
            this.followDistanceThreshold.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.followDistanceThreshold.Location = new System.Drawing.Point(175, 54);
            this.followDistanceThreshold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.followDistanceThreshold.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.followDistanceThreshold.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.followDistanceThreshold.Name = "followDistanceThreshold";
            this.followDistanceThreshold.Size = new System.Drawing.Size(80, 20);
            this.followDistanceThreshold.TabIndex = 7;
            this.followDistanceThreshold.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Follow distance";
            this.toolTip1.SetToolTip(this.label5, "The max distance in game tiles\r\nthe character can be from the target\r\nposition be" +
        "fore it will start moving\r\n\r\nNOTE: It is recommended to observe\r\nhow the bot mov" +
        "es before changing this\r\nvalue.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "tiles";
            // 
            // teleportDistanceThreshold
            // 
            this.teleportDistanceThreshold.DecimalPlaces = 1;
            this.teleportDistanceThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.teleportDistanceThreshold.Location = new System.Drawing.Point(7, 80);
            this.teleportDistanceThreshold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.teleportDistanceThreshold.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.teleportDistanceThreshold.Name = "teleportDistanceThreshold";
            this.teleportDistanceThreshold.Size = new System.Drawing.Size(51, 20);
            this.teleportDistanceThreshold.TabIndex = 4;
            this.teleportDistanceThreshold.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Teleport distance";
            this.toolTip1.SetToolTip(this.label3, "How far away in game tiles the\r\nbot can be from the target position\r\nbefore it tr" +
        "ies to teleport closer.");
            // 
            // escapeIfNoTargets
            // 
            this.escapeIfNoTargets.AutoSize = true;
            this.escapeIfNoTargets.Checked = true;
            this.escapeIfNoTargets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.escapeIfNoTargets.Location = new System.Drawing.Point(165, 17);
            this.escapeIfNoTargets.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.escapeIfNoTargets.Name = "escapeIfNoTargets";
            this.escapeIfNoTargets.Size = new System.Drawing.Size(120, 17);
            this.escapeIfNoTargets.TabIndex = 2;
            this.escapeIfNoTargets.Text = "Escape if no targets";
            this.toolTip1.SetToolTip(this.escapeIfNoTargets, "If the bot is running but there are no\r\ntargets it will nexus if this is checked\r" +
        "\n\r\nNOTE: This feature only activates after\r\nthe bot gets some targets");
            this.escapeIfNoTargets.UseVisualStyleBackColor = true;
            // 
            // autoNexusPercent
            // 
            this.autoNexusPercent.Location = new System.Drawing.Point(7, 32);
            this.autoNexusPercent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.autoNexusPercent.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.autoNexusPercent.Name = "autoNexusPercent";
            this.autoNexusPercent.Size = new System.Drawing.Size(114, 20);
            this.autoNexusPercent.TabIndex = 1;
            this.autoNexusPercent.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Auto nexus percent (%)";
            this.toolTip1.SetToolTip(this.label2, "Standard auto nexus.\r\nA higher value is recommended if you intend to leave\r\nthe b" +
        "ot unsupervised for long periods of time");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mouse over settings to see what they do";
            // 
            // findNearCenter
            // 
            this.findNearCenter.AutoSize = true;
            this.findNearCenter.Checked = true;
            this.findNearCenter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.findNearCenter.Location = new System.Drawing.Point(7, 17);
            this.findNearCenter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.findNearCenter.Name = "findNearCenter";
            this.findNearCenter.Size = new System.Drawing.Size(142, 17);
            this.findNearCenter.TabIndex = 0;
            this.findNearCenter.Text = "Find clusters near center";
            this.toolTip1.SetToolTip(this.findNearCenter, "If checked the clustering algorithm\r\nwill prioritize clusters of players which\r\na" +
        "re closer to the center of the map");
            this.findNearCenter.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Max distance between points";
            this.toolTip1.SetToolTip(this.label6, "The max distance in game tiles between\r\ntwo players before they are no longer\r\nco" +
        "nsidered to be part of the same cluster");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 85);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Minimum players per cluster";
            this.toolTip1.SetToolTip(this.label9, "The minimum number of players which\r\nneed to be part of the same cluster for\r\ntha" +
        "t group of players to be considered\r\na valid cluster.");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 128);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Ticks between cluster scans";
            this.toolTip1.SetToolTip(this.label11, "The number of game ticks between\r\nscanning for new clusters\r\n\r\nNOTE: If your CPU " +
        "isn\'t very good\r\nor K-Relay is using a lot of memory\r\ntry turning this up");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tickLabel);
            this.groupBox1.Controls.Add(this.tickPerScan);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.minPoints);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.epsilon);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.findNearCenter);
            this.groupBox1.Location = new System.Drawing.Point(8, 175);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(289, 177);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clustering";
            // 
            // tickLabel
            // 
            this.tickLabel.AutoSize = true;
            this.tickLabel.Location = new System.Drawing.Point(88, 145);
            this.tickLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tickLabel.Name = "tickLabel";
            this.tickLabel.Size = new System.Drawing.Size(29, 13);
            this.tickLabel.TabIndex = 14;
            this.tickLabel.Text = "ticks";
            // 
            // tickPerScan
            // 
            this.tickPerScan.Location = new System.Drawing.Point(5, 144);
            this.tickPerScan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tickPerScan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tickPerScan.Name = "tickPerScan";
            this.tickPerScan.Size = new System.Drawing.Size(80, 20);
            this.tickPerScan.TabIndex = 13;
            this.tickPerScan.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 101);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "players";
            // 
            // minPoints
            // 
            this.minPoints.Location = new System.Drawing.Point(7, 100);
            this.minPoints.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.minPoints.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.minPoints.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.minPoints.Name = "minPoints";
            this.minPoints.Size = new System.Drawing.Size(80, 20);
            this.minPoints.TabIndex = 10;
            this.minPoints.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 58);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "tiles";
            // 
            // epsilon
            // 
            this.epsilon.DecimalPlaces = 1;
            this.epsilon.Location = new System.Drawing.Point(7, 57);
            this.epsilon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.epsilon.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.epsilon.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.epsilon.Name = "epsilon";
            this.epsilon.Size = new System.Drawing.Size(80, 20);
            this.epsilon.TabIndex = 2;
            this.epsilon.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(8, 371);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(289, 31);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save Settings";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // txbxFlashProjectorName
            // 
            this.txbxFlashProjectorName.Location = new System.Drawing.Point(165, 107);
            this.txbxFlashProjectorName.Name = "txbxFlashProjectorName";
            this.txbxFlashProjectorName.Size = new System.Drawing.Size(119, 20);
            this.txbxFlashProjectorName.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(181, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Flash Projector Name";
            // 
            // SettingsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 409);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generalSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(325, 429);
            this.Name = "SettingsGUI";
            this.Text = " [FameBot] Config";
            this.generalSettings.ResumeLayout(false);
            this.generalSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.followDistanceThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teleportDistanceThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoNexusPercent)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tickPerScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epsilon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox generalSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown autoNexusPercent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox escapeIfNoTargets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown teleportDistanceThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown followDistanceThreshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox findNearCenter;
        private System.Windows.Forms.NumericUpDown epsilon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown minPoints;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label tickLabel;
        private System.Windows.Forms.NumericUpDown tickPerScan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox autoConnect;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbxFlashProjectorName;
    }
}