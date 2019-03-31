namespace hands_viewer.cs
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Live = new System.Windows.Forms.ToolStripMenuItem();
            this.Playback = new System.Windows.Forms.ToolStripMenuItem();
            this.Record = new System.Windows.Forms.ToolStripMenuItem();
            this.Depth = new System.Windows.Forms.RadioButton();
            this.Labelmap = new System.Windows.Forms.RadioButton();
            this.Status2 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Scale2 = new System.Windows.Forms.CheckBox();
            this.Panel2 = new System.Windows.Forms.PictureBox();
            this.Mirror = new System.Windows.Forms.CheckBox();
            this.cmbGesturesList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFPS = new System.Windows.Forms.Label();
            this.infoTextBox = new System.Windows.Forms.RichTextBox();
            this.ContourCheckBox = new System.Windows.Forms.CheckBox();
            this.ImageGroupBox = new System.Windows.Forms.GroupBox();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.TrackingModeGroupBox = new System.Windows.Forms.GroupBox();
            this.Extremities = new System.Windows.Forms.CheckBox();
            this.Skeleton = new System.Windows.Forms.CheckBox();
            this.Joints = new System.Windows.Forms.CheckBox();
            this.FullHandMode = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.sp = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.MainMenu.SuspendLayout();
            this.Status2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panel2)).BeginInit();
            this.ImageGroupBox.SuspendLayout();
            this.OptionsGroupBox.SuspendLayout();
            this.TrackingModeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Start.Location = new System.Drawing.Point(452, 426);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(80, 28);
            this.Start.TabIndex = 2;
            this.Start.Text = "开始";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Stop.Enabled = false;
            this.Stop.Location = new System.Drawing.Point(452, 458);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(80, 27);
            this.Stop.TabIndex = 3;
            this.Stop.Text = "断开";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.sourceToolStripMenuItem.Text = "设备";
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(601, 28);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Live,
            this.Playback,
            this.Record});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.modeToolStripMenuItem.Text = "模式";
            // 
            // Live
            // 
            this.Live.Checked = true;
            this.Live.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Live.Name = "Live";
            this.Live.Size = new System.Drawing.Size(147, 26);
            this.Live.Text = "Live";
            this.Live.Click += new System.EventHandler(this.Live_Click);
            // 
            // Playback
            // 
            this.Playback.Name = "Playback";
            this.Playback.Size = new System.Drawing.Size(147, 26);
            this.Playback.Text = "Playback";
            this.Playback.Click += new System.EventHandler(this.Playback_Click);
            // 
            // Record
            // 
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(147, 26);
            this.Record.Text = "Record";
            this.Record.Click += new System.EventHandler(this.Record_Click);
            // 
            // Depth
            // 
            this.Depth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Depth.AutoSize = true;
            this.Depth.Checked = true;
            this.Depth.Location = new System.Drawing.Point(-22, 12);
            this.Depth.Name = "Depth";
            this.Depth.Size = new System.Drawing.Size(88, 19);
            this.Depth.TabIndex = 20;
            this.Depth.TabStop = true;
            this.Depth.Text = "深度模式";
            this.Depth.UseVisualStyleBackColor = true;
            this.Depth.CheckedChanged += new System.EventHandler(this.Depth_CheckedChanged);
            // 
            // Labelmap
            // 
            this.Labelmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Labelmap.AutoSize = true;
            this.Labelmap.Location = new System.Drawing.Point(19, 27);
            this.Labelmap.Name = "Labelmap";
            this.Labelmap.Size = new System.Drawing.Size(88, 19);
            this.Labelmap.TabIndex = 21;
            this.Labelmap.Text = "图像标记";
            this.Labelmap.UseVisualStyleBackColor = true;
            this.Labelmap.CheckedChanged += new System.EventHandler(this.Labelmap_CheckedChanged);
            // 
            // Status2
            // 
            this.Status2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Status2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.Status2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.Status2.Location = new System.Drawing.Point(0, 535);
            this.Status2.Name = "Status2";
            this.Status2.Size = new System.Drawing.Size(601, 25);
            this.Status2.SizingGrip = false;
            this.Status2.TabIndex = 25;
            this.Status2.Text = "Status2";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(31, 20);
            this.StatusLabel.Text = "OK";
            // 
            // Scale2
            // 
            this.Scale2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Scale2.AutoSize = true;
            this.Scale2.Checked = true;
            this.Scale2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Scale2.Location = new System.Drawing.Point(5, 15);
            this.Scale2.Name = "Scale2";
            this.Scale2.Size = new System.Drawing.Size(59, 19);
            this.Scale2.TabIndex = 26;
            this.Scale2.Text = "尺寸";
            this.Scale2.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel2.ErrorImage = null;
            this.Panel2.InitialImage = null;
            this.Panel2.Location = new System.Drawing.Point(24, 31);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(400, 349);
            this.Panel2.TabIndex = 27;
            this.Panel2.TabStop = false;
            this.Panel2.Click += new System.EventHandler(this.Panel2_Click);
            // 
            // Mirror
            // 
            this.Mirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Mirror.AutoSize = true;
            this.Mirror.Checked = true;
            this.Mirror.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Mirror.Location = new System.Drawing.Point(4, 31);
            this.Mirror.Name = "Mirror";
            this.Mirror.Size = new System.Drawing.Size(59, 19);
            this.Mirror.TabIndex = 30;
            this.Mirror.Text = "反射";
            this.Mirror.UseVisualStyleBackColor = true;
            // 
            // cmbGesturesList
            // 
            this.cmbGesturesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGesturesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbGesturesList.FormattingEnabled = true;
            this.cmbGesturesList.Location = new System.Drawing.Point(440, 386);
            this.cmbGesturesList.Name = "cmbGesturesList";
            this.cmbGesturesList.Size = new System.Drawing.Size(94, 17);
            this.cmbGesturesList.TabIndex = 35;
            this.cmbGesturesList.SelectedIndexChanged += new System.EventHandler(this.cmbGesturesList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "手势";
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Location = new System.Drawing.Point(473, 490);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(0, 15);
            this.labelFPS.TabIndex = 39;
            // 
            // infoTextBox
            // 
            this.infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.infoTextBox.AutoWordSelection = true;
            this.infoTextBox.Location = new System.Drawing.Point(24, 386);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(400, 136);
            this.infoTextBox.TabIndex = 40;
            this.infoTextBox.Text = "";
            this.infoTextBox.TextChanged += new System.EventHandler(this.infoTextBox_TextChanged);
            // 
            // ContourCheckBox
            // 
            this.ContourCheckBox.AutoSize = true;
            this.ContourCheckBox.Checked = true;
            this.ContourCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ContourCheckBox.Enabled = false;
            this.ContourCheckBox.Location = new System.Drawing.Point(13, 43);
            this.ContourCheckBox.Name = "ContourCheckBox";
            this.ContourCheckBox.Size = new System.Drawing.Size(89, 19);
            this.ContourCheckBox.TabIndex = 41;
            this.ContourCheckBox.Text = "手部轮廓";
            this.ContourCheckBox.UseVisualStyleBackColor = true;
            // 
            // ImageGroupBox
            // 
            this.ImageGroupBox.Controls.Add(this.Depth);
            this.ImageGroupBox.Controls.Add(this.Labelmap);
            this.ImageGroupBox.Controls.Add(this.ContourCheckBox);
            this.ImageGroupBox.Location = new System.Drawing.Point(430, 40);
            this.ImageGroupBox.Name = "ImageGroupBox";
            this.ImageGroupBox.Size = new System.Drawing.Size(128, 63);
            this.ImageGroupBox.TabIndex = 47;
            this.ImageGroupBox.TabStop = false;
            this.ImageGroupBox.Text = "图像";
            this.ImageGroupBox.Enter += new System.EventHandler(this.ImageGroupBox_Enter);
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Controls.Add(this.Scale2);
            this.OptionsGroupBox.Controls.Add(this.Mirror);
            this.OptionsGroupBox.Location = new System.Drawing.Point(430, 109);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(128, 50);
            this.OptionsGroupBox.TabIndex = 48;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "选项";
            // 
            // TrackingModeGroupBox
            // 
            this.TrackingModeGroupBox.Controls.Add(this.Extremities);
            this.TrackingModeGroupBox.Controls.Add(this.Skeleton);
            this.TrackingModeGroupBox.Controls.Add(this.Joints);
            this.TrackingModeGroupBox.Controls.Add(this.FullHandMode);
            this.TrackingModeGroupBox.Location = new System.Drawing.Point(430, 165);
            this.TrackingModeGroupBox.Name = "TrackingModeGroupBox";
            this.TrackingModeGroupBox.Size = new System.Drawing.Size(128, 97);
            this.TrackingModeGroupBox.TabIndex = 49;
            this.TrackingModeGroupBox.TabStop = false;
            this.TrackingModeGroupBox.Text = "追踪模式";
            // 
            // Extremities
            // 
            this.Extremities.AutoSize = true;
            this.Extremities.Location = new System.Drawing.Point(22, 72);
            this.Extremities.Name = "Extremities";
            this.Extremities.Size = new System.Drawing.Size(89, 19);
            this.Extremities.TabIndex = 46;
            this.Extremities.Text = "扩展模式";
            this.Extremities.UseVisualStyleBackColor = true;
            // 
            // Skeleton
            // 
            this.Skeleton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Skeleton.AutoSize = true;
            this.Skeleton.Checked = true;
            this.Skeleton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Skeleton.Location = new System.Drawing.Point(31, 56);
            this.Skeleton.Name = "Skeleton";
            this.Skeleton.Size = new System.Drawing.Size(59, 19);
            this.Skeleton.TabIndex = 23;
            this.Skeleton.Text = "骨架";
            this.Skeleton.UseVisualStyleBackColor = true;
            // 
            // Joints
            // 
            this.Joints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Joints.AutoSize = true;
            this.Joints.Checked = true;
            this.Joints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Joints.Location = new System.Drawing.Point(16, 41);
            this.Joints.Name = "Joints";
            this.Joints.Size = new System.Drawing.Size(59, 19);
            this.Joints.TabIndex = 19;
            this.Joints.Text = "关节";
            this.Joints.UseVisualStyleBackColor = true;
            // 
            // FullHandMode
            // 
            this.FullHandMode.AutoSize = true;
            this.FullHandMode.Checked = true;
            this.FullHandMode.Location = new System.Drawing.Point(8, 24);
            this.FullHandMode.Name = "FullHandMode";
            this.FullHandMode.Size = new System.Drawing.Size(148, 19);
            this.FullHandMode.TabIndex = 51;
            this.FullHandMode.TabStop = true;
            this.FullHandMode.Text = "完整手部追踪模式";
            this.FullHandMode.UseVisualStyleBackColor = true;
            this.FullHandMode.CheckedChanged += new System.EventHandler(this.TrackingModeChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.comboBox1.Location = new System.Drawing.Point(430, 268);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 23);
            this.comboBox1.TabIndex = 50;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(430, 499);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 51;
            this.button1.Text = "连接";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200"});
            this.comboBox5.Location = new System.Drawing.Point(430, 294);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(75, 23);
            this.comboBox5.TabIndex = 52;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "5位",
            "6位",
            "7位",
            "8位"});
            this.comboBox6.Location = new System.Drawing.Point(430, 320);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(75, 23);
            this.comboBox6.TabIndex = 53;
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "1位",
            "1.5位",
            "2位"});
            this.comboBox7.Location = new System.Drawing.Point(430, 346);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(75, 23);
            this.comboBox7.TabIndex = 54;
            this.comboBox7.SelectedIndexChanged += new System.EventHandler(this.comboBox7_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 55;
            this.label1.Text = "串口号";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 56;
            this.label3.Text = "波特率";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(511, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 57;
            this.label4.Text = "数据位";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(511, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 58;
            this.label5.Text = "停止位";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(514, 499);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 59;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(601, 560);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.TrackingModeGroupBox);
            this.Controls.Add(this.OptionsGroupBox);
            this.Controls.Add(this.ImageGroupBox);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.labelFPS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbGesturesList);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Status2);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "vr康复平台";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.Status2.ResumeLayout(false);
            this.Status2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panel2)).EndInit();
            this.ImageGroupBox.ResumeLayout(false);
            this.ImageGroupBox.PerformLayout();
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            this.TrackingModeGroupBox.ResumeLayout(false);
            this.TrackingModeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.ToolStripMenuItem sourceToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.RadioButton Depth;
        private System.Windows.Forms.RadioButton Labelmap;
        private System.Windows.Forms.StatusStrip Status2;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.CheckBox Scale2;
        private System.Windows.Forms.PictureBox Panel2;
        private System.Windows.Forms.CheckBox Mirror;
        private System.Windows.Forms.ComboBox cmbGesturesList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.RichTextBox infoTextBox;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Live;
        private System.Windows.Forms.ToolStripMenuItem Playback;
        private System.Windows.Forms.ToolStripMenuItem Record;
        private System.Windows.Forms.CheckBox ContourCheckBox;
        private System.Windows.Forms.GroupBox ImageGroupBox;
        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.GroupBox TrackingModeGroupBox;
        private System.Windows.Forms.RadioButton FullHandMode;
        private System.Windows.Forms.CheckBox Extremities;
        private System.Windows.Forms.CheckBox Skeleton;
        private System.Windows.Forms.CheckBox Joints;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.IO.Ports.SerialPort sp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
    }
}