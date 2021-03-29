
namespace SonyRS232
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logBox = new System.Windows.Forms.ListBox();
            this.InitButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.DeInitButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.playbackControls = new System.Windows.Forms.GroupBox();
            this.PauseOnSelection = new System.Windows.Forms.Button();
            this.StartFromButton = new System.Windows.Forms.Button();
            this.TrackSelectorUpDown = new System.Windows.Forms.NumericUpDown();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.FFButton = new System.Windows.Forms.Button();
            this.RewindButton = new System.Windows.Forms.Button();
            this.KeyOffButton = new System.Windows.Forms.Button();
            this.TransportControls = new System.Windows.Forms.GroupBox();
            this.RepeatComboBox = new System.Windows.Forms.ComboBox();
            this.RepeatLabel = new System.Windows.Forms.Label();
            this.ModeComboBox = new System.Windows.Forms.ComboBox();
            this.EjectButton = new System.Windows.Forms.Button();
            this.ModeLabel1 = new System.Windows.Forms.Label();
            this.SlowFastForwardButton = new System.Windows.Forms.Button();
            this.SlowRewindButton = new System.Windows.Forms.Button();
            this.SpeedUpDown1 = new System.Windows.Forms.TrackBar();
            this.SetVariSpeedButton = new System.Windows.Forms.Button();
            this.CurrentInfoGroup = new System.Windows.Forms.GroupBox();
            this.InfoBox1 = new System.Windows.Forms.TextBox();
            this.ModelButton = new System.Windows.Forms.Button();
            this.DriveStatusGroup = new System.Windows.Forms.GroupBox();
            this.SystemStatus = new System.Windows.Forms.TextBox();
            this.VariSpeedGroup = new System.Windows.Forms.GroupBox();
            this.VariSpeedOn = new System.Windows.Forms.Button();
            this.VariSpeedOff = new System.Windows.Forms.Button();
            this.cmbSerialPorts = new System.Windows.Forms.ComboBox();
            this.DataControlGroup = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playbackControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackSelectorUpDown)).BeginInit();
            this.TransportControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedUpDown1)).BeginInit();
            this.CurrentInfoGroup.SuspendLayout();
            this.DriveStatusGroup.SuspendLayout();
            this.VariSpeedGroup.SuspendLayout();
            this.DataControlGroup.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.FormattingEnabled = true;
            this.logBox.ItemHeight = 15;
            this.logBox.Location = new System.Drawing.Point(7, 19);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(183, 94);
            this.logBox.TabIndex = 0;
            // 
            // InitButton
            // 
            this.InitButton.Location = new System.Drawing.Point(196, 22);
            this.InitButton.Name = "InitButton";
            this.InitButton.Size = new System.Drawing.Size(75, 23);
            this.InitButton.TabIndex = 1;
            this.InitButton.Text = "Initialize";
            this.InitButton.UseVisualStyleBackColor = true;
            this.InitButton.Click += new System.EventHandler(this.InitButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(6, 22);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(167, 23);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(6, 52);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(84, 23);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // DeInitButton
            // 
            this.DeInitButton.Location = new System.Drawing.Point(277, 22);
            this.DeInitButton.Name = "DeInitButton";
            this.DeInitButton.Size = new System.Drawing.Size(102, 23);
            this.DeInitButton.TabIndex = 4;
            this.DeInitButton.Text = "De-Init Remote";
            this.DeInitButton.UseVisualStyleBackColor = true;
            this.DeInitButton.Click += new System.EventHandler(this.DeInitButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(6, 81);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(84, 23);
            this.PauseButton.TabIndex = 5;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_click);
            // 
            // playbackControls
            // 
            this.playbackControls.Controls.Add(this.PauseOnSelection);
            this.playbackControls.Controls.Add(this.StartFromButton);
            this.playbackControls.Controls.Add(this.TrackSelectorUpDown);
            this.playbackControls.Controls.Add(this.NextButton);
            this.playbackControls.Controls.Add(this.PreviousButton);
            this.playbackControls.Controls.Add(this.StartButton);
            this.playbackControls.Controls.Add(this.PauseButton);
            this.playbackControls.Controls.Add(this.StopButton);
            this.playbackControls.Location = new System.Drawing.Point(12, 156);
            this.playbackControls.Name = "playbackControls";
            this.playbackControls.Size = new System.Drawing.Size(197, 181);
            this.playbackControls.TabIndex = 6;
            this.playbackControls.TabStop = false;
            this.playbackControls.Text = "Playback";
            // 
            // PauseOnSelection
            // 
            this.PauseOnSelection.Location = new System.Drawing.Point(7, 142);
            this.PauseOnSelection.Name = "PauseOnSelection";
            this.PauseOnSelection.Size = new System.Drawing.Size(83, 23);
            this.PauseOnSelection.TabIndex = 10;
            this.PauseOnSelection.Text = "Pause From:";
            this.PauseOnSelection.UseVisualStyleBackColor = true;
            this.PauseOnSelection.Click += new System.EventHandler(this.PauseOnSelection_Click);
            // 
            // StartFromButton
            // 
            this.StartFromButton.Location = new System.Drawing.Point(6, 112);
            this.StartFromButton.Name = "StartFromButton";
            this.StartFromButton.Size = new System.Drawing.Size(84, 23);
            this.StartFromButton.TabIndex = 9;
            this.StartFromButton.Text = "Start From:";
            this.StartFromButton.UseVisualStyleBackColor = true;
            this.StartFromButton.Click += new System.EventHandler(this.StartFromButton_Click);
            // 
            // TrackSelectorUpDown
            // 
            this.TrackSelectorUpDown.Location = new System.Drawing.Point(96, 125);
            this.TrackSelectorUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.TrackSelectorUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TrackSelectorUpDown.Name = "TrackSelectorUpDown";
            this.TrackSelectorUpDown.Size = new System.Drawing.Size(76, 23);
            this.TrackSelectorUpDown.TabIndex = 8;
            this.TrackSelectorUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(97, 80);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 7;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(97, 52);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(75, 23);
            this.PreviousButton.TabIndex = 6;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // FFButton
            // 
            this.FFButton.Location = new System.Drawing.Point(7, 81);
            this.FFButton.Name = "FFButton";
            this.FFButton.Size = new System.Drawing.Size(83, 23);
            this.FFButton.TabIndex = 8;
            this.FFButton.Text = "Fast Forward";
            this.FFButton.UseVisualStyleBackColor = true;
            this.FFButton.Click += new System.EventHandler(this.FFButton_Click);
            // 
            // RewindButton
            // 
            this.RewindButton.Location = new System.Drawing.Point(6, 52);
            this.RewindButton.Name = "RewindButton";
            this.RewindButton.Size = new System.Drawing.Size(84, 23);
            this.RewindButton.TabIndex = 7;
            this.RewindButton.Text = "Rewind";
            this.RewindButton.UseVisualStyleBackColor = true;
            this.RewindButton.Click += new System.EventHandler(this.RewindButton_Click);
            // 
            // KeyOffButton
            // 
            this.KeyOffButton.Location = new System.Drawing.Point(6, 22);
            this.KeyOffButton.Name = "KeyOffButton";
            this.KeyOffButton.Size = new System.Drawing.Size(84, 23);
            this.KeyOffButton.TabIndex = 6;
            this.KeyOffButton.Text = "Key OFF";
            this.KeyOffButton.UseVisualStyleBackColor = true;
            this.KeyOffButton.Click += new System.EventHandler(this.KeyOffButton_Click);
            // 
            // TransportControls
            // 
            this.TransportControls.Controls.Add(this.RepeatComboBox);
            this.TransportControls.Controls.Add(this.RepeatLabel);
            this.TransportControls.Controls.Add(this.ModeComboBox);
            this.TransportControls.Controls.Add(this.EjectButton);
            this.TransportControls.Controls.Add(this.ModeLabel1);
            this.TransportControls.Controls.Add(this.SlowFastForwardButton);
            this.TransportControls.Controls.Add(this.SlowRewindButton);
            this.TransportControls.Controls.Add(this.FFButton);
            this.TransportControls.Controls.Add(this.KeyOffButton);
            this.TransportControls.Controls.Add(this.RewindButton);
            this.TransportControls.Location = new System.Drawing.Point(215, 156);
            this.TransportControls.Name = "TransportControls";
            this.TransportControls.Size = new System.Drawing.Size(192, 181);
            this.TransportControls.TabIndex = 7;
            this.TransportControls.TabStop = false;
            this.TransportControls.Text = "Transport";
            // 
            // RepeatComboBox
            // 
            this.RepeatComboBox.FormattingEnabled = true;
            this.RepeatComboBox.Items.AddRange(new object[] {
            "Off",
            "All",
            "1 Track"});
            this.RepeatComboBox.Location = new System.Drawing.Point(58, 142);
            this.RepeatComboBox.Name = "RepeatComboBox";
            this.RepeatComboBox.Size = new System.Drawing.Size(121, 23);
            this.RepeatComboBox.TabIndex = 13;
            this.RepeatComboBox.SelectedIndexChanged += new System.EventHandler(this.RepeatComboBox_SelectedIndexChanged);
            // 
            // RepeatLabel
            // 
            this.RepeatLabel.AutoSize = true;
            this.RepeatLabel.Location = new System.Drawing.Point(7, 142);
            this.RepeatLabel.Name = "RepeatLabel";
            this.RepeatLabel.Size = new System.Drawing.Size(43, 15);
            this.RepeatLabel.TabIndex = 12;
            this.RepeatLabel.Text = "Repeat";
            // 
            // ModeComboBox
            // 
            this.ModeComboBox.FormattingEnabled = true;
            this.ModeComboBox.Items.AddRange(new object[] {
            "Continous",
            "1-Track-Pause"});
            this.ModeComboBox.Location = new System.Drawing.Point(58, 112);
            this.ModeComboBox.Name = "ModeComboBox";
            this.ModeComboBox.Size = new System.Drawing.Size(121, 23);
            this.ModeComboBox.TabIndex = 9;
            this.ModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ModeComboBox_SelectedIndexChanged);
            // 
            // EjectButton
            // 
            this.EjectButton.Location = new System.Drawing.Point(96, 22);
            this.EjectButton.Name = "EjectButton";
            this.EjectButton.Size = new System.Drawing.Size(83, 23);
            this.EjectButton.TabIndex = 11;
            this.EjectButton.Text = "Eject";
            this.EjectButton.UseVisualStyleBackColor = true;
            this.EjectButton.Click += new System.EventHandler(this.EjectButton_Click);
            // 
            // ModeLabel1
            // 
            this.ModeLabel1.AutoSize = true;
            this.ModeLabel1.Location = new System.Drawing.Point(7, 116);
            this.ModeLabel1.Name = "ModeLabel1";
            this.ModeLabel1.Size = new System.Drawing.Size(41, 15);
            this.ModeLabel1.TabIndex = 8;
            this.ModeLabel1.Text = "Mode:";
            // 
            // SlowFastForwardButton
            // 
            this.SlowFastForwardButton.Location = new System.Drawing.Point(96, 81);
            this.SlowFastForwardButton.Name = "SlowFastForwardButton";
            this.SlowFastForwardButton.Size = new System.Drawing.Size(83, 23);
            this.SlowFastForwardButton.TabIndex = 10;
            this.SlowFastForwardButton.Text = "Slow F.F";
            this.SlowFastForwardButton.UseVisualStyleBackColor = true;
            this.SlowFastForwardButton.Click += new System.EventHandler(this.SlowFastForwardButton_Click);
            // 
            // SlowRewindButton
            // 
            this.SlowRewindButton.Location = new System.Drawing.Point(96, 52);
            this.SlowRewindButton.Name = "SlowRewindButton";
            this.SlowRewindButton.Size = new System.Drawing.Size(83, 23);
            this.SlowRewindButton.TabIndex = 9;
            this.SlowRewindButton.Text = "Slow Rewind";
            this.SlowRewindButton.UseVisualStyleBackColor = true;
            this.SlowRewindButton.Click += new System.EventHandler(this.SlowRewindButton_Click);
            // 
            // SpeedUpDown1
            // 
            this.SpeedUpDown1.Location = new System.Drawing.Point(10, 81);
            this.SpeedUpDown1.Maximum = 25;
            this.SpeedUpDown1.Name = "SpeedUpDown1";
            this.SpeedUpDown1.Size = new System.Drawing.Size(172, 45);
            this.SpeedUpDown1.TabIndex = 18;
            this.SpeedUpDown1.Value = 13;
            // 
            // SetVariSpeedButton
            // 
            this.SetVariSpeedButton.Location = new System.Drawing.Point(7, 52);
            this.SetVariSpeedButton.Name = "SetVariSpeedButton";
            this.SetVariSpeedButton.Size = new System.Drawing.Size(175, 23);
            this.SetVariSpeedButton.TabIndex = 16;
            this.SetVariSpeedButton.Text = "Set VariSpeed ";
            this.SetVariSpeedButton.UseVisualStyleBackColor = true;
            this.SetVariSpeedButton.Click += new System.EventHandler(this.SetVariSpeedButton_Click);
            // 
            // CurrentInfoGroup
            // 
            this.CurrentInfoGroup.Controls.Add(this.InfoBox1);
            this.CurrentInfoGroup.Location = new System.Drawing.Point(417, 27);
            this.CurrentInfoGroup.Name = "CurrentInfoGroup";
            this.CurrentInfoGroup.Size = new System.Drawing.Size(192, 175);
            this.CurrentInfoGroup.TabIndex = 8;
            this.CurrentInfoGroup.TabStop = false;
            this.CurrentInfoGroup.Text = "CD player\'s HEX output.";
            // 
            // InfoBox1
            // 
            this.InfoBox1.Location = new System.Drawing.Point(6, 14);
            this.InfoBox1.Multiline = true;
            this.InfoBox1.Name = "InfoBox1";
            this.InfoBox1.ReadOnly = true;
            this.InfoBox1.Size = new System.Drawing.Size(179, 155);
            this.InfoBox1.TabIndex = 0;
            // 
            // ModelButton
            // 
            this.ModelButton.Location = new System.Drawing.Point(277, 51);
            this.ModelButton.Name = "ModelButton";
            this.ModelButton.Size = new System.Drawing.Size(102, 23);
            this.ModelButton.TabIndex = 9;
            this.ModelButton.Text = "Output Model";
            this.ModelButton.UseVisualStyleBackColor = true;
            this.ModelButton.Click += new System.EventHandler(this.ModelButton_Click);
            // 
            // DriveStatusGroup
            // 
            this.DriveStatusGroup.Controls.Add(this.SystemStatus);
            this.DriveStatusGroup.Location = new System.Drawing.Point(615, 27);
            this.DriveStatusGroup.Name = "DriveStatusGroup";
            this.DriveStatusGroup.Size = new System.Drawing.Size(200, 310);
            this.DriveStatusGroup.TabIndex = 11;
            this.DriveStatusGroup.TabStop = false;
            this.DriveStatusGroup.Text = " Status:";
            // 
            // SystemStatus
            // 
            this.SystemStatus.Location = new System.Drawing.Point(6, 14);
            this.SystemStatus.Multiline = true;
            this.SystemStatus.Name = "SystemStatus";
            this.SystemStatus.ReadOnly = true;
            this.SystemStatus.Size = new System.Drawing.Size(188, 290);
            this.SystemStatus.TabIndex = 0;
            // 
            // VariSpeedGroup
            // 
            this.VariSpeedGroup.Controls.Add(this.SpeedUpDown1);
            this.VariSpeedGroup.Controls.Add(this.VariSpeedOn);
            this.VariSpeedGroup.Controls.Add(this.SetVariSpeedButton);
            this.VariSpeedGroup.Controls.Add(this.VariSpeedOff);
            this.VariSpeedGroup.Location = new System.Drawing.Point(413, 208);
            this.VariSpeedGroup.Name = "VariSpeedGroup";
            this.VariSpeedGroup.Size = new System.Drawing.Size(196, 129);
            this.VariSpeedGroup.TabIndex = 12;
            this.VariSpeedGroup.TabStop = false;
            this.VariSpeedGroup.Text = "VariSpeed";
            // 
            // VariSpeedOn
            // 
            this.VariSpeedOn.Location = new System.Drawing.Point(7, 22);
            this.VariSpeedOn.Name = "VariSpeedOn";
            this.VariSpeedOn.Size = new System.Drawing.Size(75, 23);
            this.VariSpeedOn.TabIndex = 17;
            this.VariSpeedOn.Text = "On";
            this.VariSpeedOn.UseVisualStyleBackColor = true;
            this.VariSpeedOn.Click += new System.EventHandler(this.VariSpeedOn_Click);
            // 
            // VariSpeedOff
            // 
            this.VariSpeedOff.Location = new System.Drawing.Point(107, 22);
            this.VariSpeedOff.Name = "VariSpeedOff";
            this.VariSpeedOff.Size = new System.Drawing.Size(75, 23);
            this.VariSpeedOff.TabIndex = 16;
            this.VariSpeedOff.Text = "Off";
            this.VariSpeedOff.UseVisualStyleBackColor = true;
            this.VariSpeedOff.Click += new System.EventHandler(this.VariSpeedOff_Click);
            // 
            // cmbSerialPorts
            // 
            this.cmbSerialPorts.FormattingEnabled = true;
            this.cmbSerialPorts.Location = new System.Drawing.Point(197, 51);
            this.cmbSerialPorts.Name = "cmbSerialPorts";
            this.cmbSerialPorts.Size = new System.Drawing.Size(74, 23);
            this.cmbSerialPorts.TabIndex = 13;
            // 
            // DataControlGroup
            // 
            this.DataControlGroup.Controls.Add(this.logBox);
            this.DataControlGroup.Controls.Add(this.cmbSerialPorts);
            this.DataControlGroup.Controls.Add(this.InitButton);
            this.DataControlGroup.Controls.Add(this.DeInitButton);
            this.DataControlGroup.Controls.Add(this.ModelButton);
            this.DataControlGroup.Location = new System.Drawing.Point(12, 27);
            this.DataControlGroup.Name = "DataControlGroup";
            this.DataControlGroup.Size = new System.Drawing.Size(395, 123);
            this.DataControlGroup.TabIndex = 14;
            this.DataControlGroup.TabStop = false;
            this.DataControlGroup.Text = "System";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(824, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AboutMenuItem.Text = "About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 342);
            this.Controls.Add(this.DataControlGroup);
            this.Controls.Add(this.VariSpeedGroup);
            this.Controls.Add(this.DriveStatusGroup);
            this.Controls.Add(this.CurrentInfoGroup);
            this.Controls.Add(this.TransportControls);
            this.Controls.Add(this.playbackControls);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "SonyRS232";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.playbackControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TrackSelectorUpDown)).EndInit();
            this.TransportControls.ResumeLayout(false);
            this.TransportControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedUpDown1)).EndInit();
            this.CurrentInfoGroup.ResumeLayout(false);
            this.CurrentInfoGroup.PerformLayout();
            this.DriveStatusGroup.ResumeLayout(false);
            this.DriveStatusGroup.PerformLayout();
            this.VariSpeedGroup.ResumeLayout(false);
            this.VariSpeedGroup.PerformLayout();
            this.DataControlGroup.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox logBox;
        private System.Windows.Forms.Button InitButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button DeInitButton;        
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.GroupBox playbackControls;
        private System.Windows.Forms.Button KeyOffButton;
        private System.Windows.Forms.Button FFButton;
        private System.Windows.Forms.Button RewindButton;
        private System.Windows.Forms.GroupBox TransportControls;
        private System.Windows.Forms.Button SlowRewindButton;
        private System.Windows.Forms.Button SlowFastForwardButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button StartFromButton;
        private System.Windows.Forms.NumericUpDown TrackSelectorUpDown;
        private System.Windows.Forms.Button PauseOnSelection;
        private System.Windows.Forms.Button EjectButton;
        private System.Windows.Forms.Label ModeLabel1;
        private System.Windows.Forms.ComboBox ModeComboBox;
        private System.Windows.Forms.ComboBox RepeatComboBox;
        private System.Windows.Forms.Label RepeatLabel;
        private System.Windows.Forms.GroupBox CurrentInfoGroup;
        private System.Windows.Forms.TextBox InfoBox1;
        private System.Windows.Forms.Button ModelButton;
        private System.Windows.Forms.GroupBox DriveStatusGroup;
        private System.Windows.Forms.TextBox SystemStatus;
        private System.Windows.Forms.Button SetVariSpeedButton;
        private System.Windows.Forms.Button VariSpeedButton;
        private System.Windows.Forms.GroupBox VariSpeedGroup;
        private System.Windows.Forms.Button VariSpeedOff;
        private System.Windows.Forms.Button VariSpeedOn;
        private System.Windows.Forms.TrackBar SpeedUpDown1;
        private System.Windows.Forms.ComboBox cmbSerialPorts;
        private System.Windows.Forms.GroupBox DataControlGroup;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
    }
}

