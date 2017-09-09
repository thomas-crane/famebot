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
            this.enableEnemyAvoidance = new System.Windows.Forms.CheckBox();
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
            this.generalSettings.Controls.Add(this.enableEnemyAvoidance);
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
            this.generalSettings.Location = new System.Drawing.Point(12, 56);
            this.generalSettings.Name = "generalSettings";
            this.generalSettings.Size = new System.Drawing.Size(434, 208);
            this.generalSettings.TabIndex = 0;
            this.generalSettings.TabStop = false;
            this.generalSettings.Text = "General";
            // 
            // autoConnect
            // 
            this.autoConnect.AutoSize = true;
            this.autoConnect.Checked = true;
            this.autoConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoConnect.Location = new System.Drawing.Point(11, 170);
            this.autoConnect.Name = "autoConnect";
            this.autoConnect.Size = new System.Drawing.Size(129, 24);
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
            this.label8.Location = new System.Drawing.Point(391, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 20);
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
            this.followDistanceThreshold.Location = new System.Drawing.Point(265, 122);
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
            this.followDistanceThreshold.Size = new System.Drawing.Size(120, 26);
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
            this.label5.Location = new System.Drawing.Point(310, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Follow distance";
            this.toolTip1.SetToolTip(this.label5, "The max distance in game tiles\r\nthe character can be from the target\r\nposition be" +
        "fore it will start moving\r\n\r\nNOTE: It is recommended to observe\r\nhow the bot mov" +
        "es before changing this\r\nvalue.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
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
            this.teleportDistanceThreshold.Location = new System.Drawing.Point(11, 123);
            this.teleportDistanceThreshold.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.teleportDistanceThreshold.Name = "teleportDistanceThreshold";
            this.teleportDistanceThreshold.Size = new System.Drawing.Size(76, 26);
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
            this.label3.Location = new System.Drawing.Point(7, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
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
            this.escapeIfNoTargets.Location = new System.Drawing.Point(251, 26);
            this.escapeIfNoTargets.Name = "escapeIfNoTargets";
            this.escapeIfNoTargets.Size = new System.Drawing.Size(177, 24);
            this.escapeIfNoTargets.TabIndex = 2;
            this.escapeIfNoTargets.Text = "Escape if no targets";
            this.toolTip1.SetToolTip(this.escapeIfNoTargets, "If the bot is running but there are no\r\ntargets it will nexus if this is checked\r" +
        "\n\r\nNOTE: This feature only activates after\r\nthe bot gets some targets");
            this.escapeIfNoTargets.UseVisualStyleBackColor = true;
            // 
            // autoNexusPercent
            // 
            this.autoNexusPercent.Location = new System.Drawing.Point(11, 50);
            this.autoNexusPercent.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.autoNexusPercent.Name = "autoNexusPercent";
            this.autoNexusPercent.Size = new System.Drawing.Size(171, 26);
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
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Auto nexus percent (%)";
            this.toolTip1.SetToolTip(this.label2, "Standard auto nexus.\r\nA higher value is recommended if you intend to leave\r\nthe b" +
        "ot unsupervised for long periods of time");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mouse over settings to see what they do";
            // 
            // findNearCenter
            // 
            this.findNearCenter.AutoSize = true;
            this.findNearCenter.Checked = true;
            this.findNearCenter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.findNearCenter.Location = new System.Drawing.Point(10, 26);
            this.findNearCenter.Name = "findNearCenter";
            this.findNearCenter.Size = new System.Drawing.Size(210, 24);
            this.findNearCenter.TabIndex = 0;
            this.findNearCenter.Text = "Find clusters near center";
            this.toolTip1.SetToolTip(this.findNearCenter, "If checked the clustering algorithm\r\nwill prioritize clusters of players which\r\na" +
        "re closer to the center of the map");
            this.findNearCenter.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(214, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Max distance between points";
            this.toolTip1.SetToolTip(this.label6, "The max distance in game tiles between\r\ntwo players before they are no longer\r\nco" +
        "nsidered to be part of the same cluster");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(204, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Minimum players per cluster";
            this.toolTip1.SetToolTip(this.label9, "The minimum number of players which\r\nneed to be part of the same cluster for\r\ntha" +
        "t group of players to be considered\r\na valid cluster.");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(207, 20);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 272);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clustering";
            // 
            // tickLabel
            // 
            this.tickLabel.AutoSize = true;
            this.tickLabel.Location = new System.Drawing.Point(132, 223);
            this.tickLabel.Name = "tickLabel";
            this.tickLabel.Size = new System.Drawing.Size(41, 20);
            this.tickLabel.TabIndex = 14;
            this.tickLabel.Text = "ticks";
            // 
            // tickPerScan
            // 
            this.tickPerScan.Location = new System.Drawing.Point(7, 221);
            this.tickPerScan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tickPerScan.Name = "tickPerScan";
            this.tickPerScan.Size = new System.Drawing.Size(120, 26);
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
            this.label10.Location = new System.Drawing.Point(136, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "players";
            // 
            // minPoints
            // 
            this.minPoints.Location = new System.Drawing.Point(10, 154);
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
            this.minPoints.Size = new System.Drawing.Size(120, 26);
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
            this.label7.Location = new System.Drawing.Point(136, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "tiles";
            // 
            // epsilon
            // 
            this.epsilon.DecimalPlaces = 1;
            this.epsilon.Location = new System.Drawing.Point(10, 87);
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
            this.epsilon.Size = new System.Drawing.Size(120, 26);
            this.epsilon.TabIndex = 2;
            this.epsilon.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 571);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(434, 47);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save Settings";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // enableEnemyAvoidance
            // 
            this.enableEnemyAvoidance.AutoSize = true;
            this.enableEnemyAvoidance.Checked = true;
            this.enableEnemyAvoidance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableEnemyAvoidance.Location = new System.Drawing.Point(216, 170);
            this.enableEnemyAvoidance.Name = "enableEnemyAvoidance";
            this.enableEnemyAvoidance.Size = new System.Drawing.Size(212, 24);
            this.enableEnemyAvoidance.TabIndex = 10;
            this.enableEnemyAvoidance.Text = "Enable enemy avoidance";
            this.toolTip1.SetToolTip(this.enableEnemyAvoidance, "If this is checked, the bot will actively attempt to avoid gods by staying at lea" +
        "st 7-8 game tiles away from them.");
            this.enableEnemyAvoidance.UseVisualStyleBackColor = true;
            // 
            // SettingsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 630);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generalSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 640);
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
        private System.Windows.Forms.CheckBox enableEnemyAvoidance;
    }
}