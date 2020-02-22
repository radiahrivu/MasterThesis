namespace RealWorld
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
            this.LabelTopText = new System.Windows.Forms.Label();
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonStartExperiment = new System.Windows.Forms.Button();
            this.VideoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.valenceGroup = new System.Windows.Forms.Panel();
            this.v9 = new System.Windows.Forms.RadioButton();
            this.v7 = new System.Windows.Forms.RadioButton();
            this.v8 = new System.Windows.Forms.RadioButton();
            this.v2 = new System.Windows.Forms.RadioButton();
            this.v1 = new System.Windows.Forms.RadioButton();
            this.v6 = new System.Windows.Forms.RadioButton();
            this.v3 = new System.Windows.Forms.RadioButton();
            this.v5 = new System.Windows.Forms.RadioButton();
            this.v4 = new System.Windows.Forms.RadioButton();
            this.arousalGroup = new System.Windows.Forms.Panel();
            this.ButtonAbRNext = new System.Windows.Forms.Button();
            this.a9 = new System.Windows.Forms.RadioButton();
            this.a7 = new System.Windows.Forms.RadioButton();
            this.a8 = new System.Windows.Forms.RadioButton();
            this.a2 = new System.Windows.Forms.RadioButton();
            this.a1 = new System.Windows.Forms.RadioButton();
            this.a6 = new System.Windows.Forms.RadioButton();
            this.a3 = new System.Windows.Forms.RadioButton();
            this.a5 = new System.Windows.Forms.RadioButton();
            this.a4 = new System.Windows.Forms.RadioButton();
            this.dominanceGroup = new System.Windows.Forms.Panel();
            this.d9 = new System.Windows.Forms.RadioButton();
            this.d7 = new System.Windows.Forms.RadioButton();
            this.d8 = new System.Windows.Forms.RadioButton();
            this.d2 = new System.Windows.Forms.RadioButton();
            this.d1 = new System.Windows.Forms.RadioButton();
            this.d6 = new System.Windows.Forms.RadioButton();
            this.d3 = new System.Windows.Forms.RadioButton();
            this.d5 = new System.Windows.Forms.RadioButton();
            this.d4 = new System.Windows.Forms.RadioButton();
            this.ButtonSubmitManikin = new System.Windows.Forms.Button();
            this.LabelFinishText = new System.Windows.Forms.Label();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayer)).BeginInit();
            this.valenceGroup.SuspendLayout();
            this.arousalGroup.SuspendLayout();
            this.dominanceGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelTopText
            // 
            this.LabelTopText.AutoSize = true;
            this.LabelTopText.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelTopText.Location = new System.Drawing.Point(9, 0);
            this.LabelTopText.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.LabelTopText.Name = "LabelTopText";
            this.LabelTopText.Size = new System.Drawing.Size(167, 35);
            this.LabelTopText.TabIndex = 0;
            this.LabelTopText.Text = "TOP TEXT";
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.LabelTopText, 0, 0);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 1;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.LayoutPanel.Size = new System.Drawing.Size(1953, 180);
            this.LayoutPanel.TabIndex = 1;
            // 
            // ButtonStartExperiment
            // 
            this.ButtonStartExperiment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonStartExperiment.Location = new System.Drawing.Point(822, 597);
            this.ButtonStartExperiment.Name = "ButtonStartExperiment";
            this.ButtonStartExperiment.Size = new System.Drawing.Size(343, 128);
            this.ButtonStartExperiment.TabIndex = 2;
            this.ButtonStartExperiment.Text = "Start Experiment";
            this.ButtonStartExperiment.UseVisualStyleBackColor = true;
            this.ButtonStartExperiment.Click += new System.EventHandler(this.ButtonStartExperiment_Click);
            // 
            // VideoPlayer
            // 
            this.VideoPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VideoPlayer.Enabled = true;
            this.VideoPlayer.Location = new System.Drawing.Point(9, 9);
            this.VideoPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.VideoPlayer.Name = "VideoPlayer";
            this.VideoPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VideoPlayer.OcxState")));
            this.VideoPlayer.Size = new System.Drawing.Size(1898, 975);
            this.VideoPlayer.TabIndex = 3;
            this.VideoPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.VideoPlayer_PlayStateChange);
            // 
            // valenceGroup
            // 
            this.valenceGroup.Controls.Add(this.v9);
            this.valenceGroup.Controls.Add(this.v7);
            this.valenceGroup.Controls.Add(this.v8);
            this.valenceGroup.Controls.Add(this.v2);
            this.valenceGroup.Controls.Add(this.v1);
            this.valenceGroup.Controls.Add(this.v6);
            this.valenceGroup.Controls.Add(this.v3);
            this.valenceGroup.Controls.Add(this.v5);
            this.valenceGroup.Controls.Add(this.v4);
            this.valenceGroup.Location = new System.Drawing.Point(60, 186);
            this.valenceGroup.Name = "valenceGroup";
            this.valenceGroup.Size = new System.Drawing.Size(1869, 196);
            this.valenceGroup.TabIndex = 16;
            // 
            // v9
            // 
            this.v9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("v9.BackgroundImage")));
            this.v9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.v9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.v9.Location = new System.Drawing.Point(1646, 3);
            this.v9.Name = "v9";
            this.v9.Size = new System.Drawing.Size(175, 188);
            this.v9.TabIndex = 30;
            this.v9.TabStop = true;
            this.v9.Text = "9";
            this.v9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.v9.UseVisualStyleBackColor = true;
            // 
            // v7
            // 
            this.v7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("v7.BackgroundImage")));
            this.v7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.v7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.v7.Location = new System.Drawing.Point(1241, 3);
            this.v7.Name = "v7";
            this.v7.Size = new System.Drawing.Size(175, 188);
            this.v7.TabIndex = 28;
            this.v7.TabStop = true;
            this.v7.Text = "7";
            this.v7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.v7.UseVisualStyleBackColor = true;
            // 
            // v8
            // 
            this.v8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("v8.BackgroundImage")));
            this.v8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.v8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.v8.Location = new System.Drawing.Point(1444, 3);
            this.v8.Name = "v8";
            this.v8.Size = new System.Drawing.Size(175, 188);
            this.v8.TabIndex = 29;
            this.v8.TabStop = true;
            this.v8.Text = "8";
            this.v8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.v8.UseVisualStyleBackColor = true;
            // 
            // v2
            // 
            this.v2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("v2.BackgroundImage")));
            this.v2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.v2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.v2.Location = new System.Drawing.Point(231, 3);
            this.v2.Name = "v2";
            this.v2.Size = new System.Drawing.Size(175, 188);
            this.v2.TabIndex = 23;
            this.v2.TabStop = true;
            this.v2.Text = "2";
            this.v2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.v2.UseVisualStyleBackColor = true;
            // 
            // v1
            // 
            this.v1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("v1.BackgroundImage")));
            this.v1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.v1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.v1.Location = new System.Drawing.Point(32, 3);
            this.v1.Name = "v1";
            this.v1.Size = new System.Drawing.Size(175, 188);
            this.v1.TabIndex = 22;
            this.v1.TabStop = true;
            this.v1.Text = "1";
            this.v1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.v1.UseVisualStyleBackColor = true;
            // 
            // v6
            // 
            this.v6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("v6.BackgroundImage")));
            this.v6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.v6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.v6.Location = new System.Drawing.Point(1035, 3);
            this.v6.Name = "v6";
            this.v6.Size = new System.Drawing.Size(175, 188);
            this.v6.TabIndex = 27;
            this.v6.TabStop = true;
            this.v6.Text = "6";
            this.v6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.v6.UseVisualStyleBackColor = true;
            // 
            // v3
            // 
            this.v3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("v3.BackgroundImage")));
            this.v3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.v3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.v3.Location = new System.Drawing.Point(431, 3);
            this.v3.Name = "v3";
            this.v3.Size = new System.Drawing.Size(175, 188);
            this.v3.TabIndex = 24;
            this.v3.TabStop = true;
            this.v3.Text = "3";
            this.v3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.v3.UseVisualStyleBackColor = true;
            // 
            // v5
            // 
            this.v5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("v5.BackgroundImage")));
            this.v5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.v5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.v5.Location = new System.Drawing.Point(833, 3);
            this.v5.Name = "v5";
            this.v5.Size = new System.Drawing.Size(175, 188);
            this.v5.TabIndex = 26;
            this.v5.TabStop = true;
            this.v5.Text = "5";
            this.v5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.v5.UseVisualStyleBackColor = true;
            // 
            // v4
            // 
            this.v4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("v4.BackgroundImage")));
            this.v4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.v4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.v4.Location = new System.Drawing.Point(633, 3);
            this.v4.Name = "v4";
            this.v4.Size = new System.Drawing.Size(175, 188);
            this.v4.TabIndex = 25;
            this.v4.TabStop = true;
            this.v4.Text = "4";
            this.v4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.v4.UseVisualStyleBackColor = true;
            // 
            // arousalGroup
            // 
            this.arousalGroup.Controls.Add(this.a9);
            this.arousalGroup.Controls.Add(this.a7);
            this.arousalGroup.Controls.Add(this.a8);
            this.arousalGroup.Controls.Add(this.a2);
            this.arousalGroup.Controls.Add(this.a1);
            this.arousalGroup.Controls.Add(this.a6);
            this.arousalGroup.Controls.Add(this.a3);
            this.arousalGroup.Controls.Add(this.a5);
            this.arousalGroup.Controls.Add(this.a4);
            this.arousalGroup.Location = new System.Drawing.Point(60, 413);
            this.arousalGroup.Name = "arousalGroup";
            this.arousalGroup.Size = new System.Drawing.Size(1869, 193);
            this.arousalGroup.TabIndex = 31;
            // 
            // ButtonAbRNext
            // 
            this.ButtonAbRNext.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAbRNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonAbRNext.Location = new System.Drawing.Point(822, 812);
            this.ButtonAbRNext.Name = "ButtonAbRNext";
            this.ButtonAbRNext.Size = new System.Drawing.Size(343, 128);
            this.ButtonAbRNext.TabIndex = 33;
            this.ButtonAbRNext.Text = "Next Step";
            this.ButtonAbRNext.UseVisualStyleBackColor = true;
            this.ButtonAbRNext.Visible = false;
            this.ButtonAbRNext.Click += new System.EventHandler(this.ButtonAbRNext_Click);
            // 
            // a9
            // 
            this.a9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("a9.BackgroundImage")));
            this.a9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.a9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.a9.Location = new System.Drawing.Point(1646, 3);
            this.a9.Name = "a9";
            this.a9.Size = new System.Drawing.Size(175, 188);
            this.a9.TabIndex = 30;
            this.a9.TabStop = true;
            this.a9.Text = "9";
            this.a9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.a9.UseVisualStyleBackColor = true;
            // 
            // a7
            // 
            this.a7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("a7.BackgroundImage")));
            this.a7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.a7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.a7.Location = new System.Drawing.Point(1241, 3);
            this.a7.Name = "a7";
            this.a7.Size = new System.Drawing.Size(175, 188);
            this.a7.TabIndex = 28;
            this.a7.TabStop = true;
            this.a7.Text = "7";
            this.a7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.a7.UseVisualStyleBackColor = true;
            // 
            // a8
            // 
            this.a8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("a8.BackgroundImage")));
            this.a8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.a8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.a8.Location = new System.Drawing.Point(1444, 3);
            this.a8.Name = "a8";
            this.a8.Size = new System.Drawing.Size(175, 188);
            this.a8.TabIndex = 29;
            this.a8.TabStop = true;
            this.a8.Text = "8";
            this.a8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.a8.UseVisualStyleBackColor = true;
            // 
            // a2
            // 
            this.a2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("a2.BackgroundImage")));
            this.a2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.a2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.a2.Location = new System.Drawing.Point(231, 3);
            this.a2.Name = "a2";
            this.a2.Size = new System.Drawing.Size(175, 188);
            this.a2.TabIndex = 23;
            this.a2.TabStop = true;
            this.a2.Text = "2";
            this.a2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.a2.UseVisualStyleBackColor = true;
            // 
            // a1
            // 
            this.a1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("a1.BackgroundImage")));
            this.a1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.a1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.a1.Location = new System.Drawing.Point(32, 3);
            this.a1.Name = "a1";
            this.a1.Size = new System.Drawing.Size(175, 188);
            this.a1.TabIndex = 22;
            this.a1.TabStop = true;
            this.a1.Text = "1";
            this.a1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.a1.UseVisualStyleBackColor = true;
            // 
            // a6
            // 
            this.a6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("a6.BackgroundImage")));
            this.a6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.a6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.a6.Location = new System.Drawing.Point(1035, 3);
            this.a6.Name = "a6";
            this.a6.Size = new System.Drawing.Size(175, 188);
            this.a6.TabIndex = 27;
            this.a6.TabStop = true;
            this.a6.Text = "6";
            this.a6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.a6.UseVisualStyleBackColor = true;
            // 
            // a3
            // 
            this.a3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("a3.BackgroundImage")));
            this.a3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.a3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.a3.Location = new System.Drawing.Point(431, 3);
            this.a3.Name = "a3";
            this.a3.Size = new System.Drawing.Size(175, 188);
            this.a3.TabIndex = 24;
            this.a3.TabStop = true;
            this.a3.Text = "3";
            this.a3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.a3.UseVisualStyleBackColor = true;
            // 
            // a5
            // 
            this.a5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("a5.BackgroundImage")));
            this.a5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.a5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.a5.Location = new System.Drawing.Point(833, 3);
            this.a5.Name = "a5";
            this.a5.Size = new System.Drawing.Size(175, 188);
            this.a5.TabIndex = 26;
            this.a5.TabStop = true;
            this.a5.Text = "5";
            this.a5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.a5.UseVisualStyleBackColor = true;
            // 
            // a4
            // 
            this.a4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("a4.BackgroundImage")));
            this.a4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.a4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.a4.Location = new System.Drawing.Point(633, 3);
            this.a4.Name = "a4";
            this.a4.Size = new System.Drawing.Size(175, 188);
            this.a4.TabIndex = 25;
            this.a4.TabStop = true;
            this.a4.Text = "4";
            this.a4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.a4.UseVisualStyleBackColor = true;
            // 
            // dominanceGroup
            // 
            this.dominanceGroup.Controls.Add(this.d9);
            this.dominanceGroup.Controls.Add(this.d7);
            this.dominanceGroup.Controls.Add(this.d8);
            this.dominanceGroup.Controls.Add(this.d2);
            this.dominanceGroup.Controls.Add(this.d1);
            this.dominanceGroup.Controls.Add(this.d6);
            this.dominanceGroup.Controls.Add(this.d3);
            this.dominanceGroup.Controls.Add(this.d5);
            this.dominanceGroup.Controls.Add(this.d4);
            this.dominanceGroup.Location = new System.Drawing.Point(60, 632);
            this.dominanceGroup.Name = "dominanceGroup";
            this.dominanceGroup.Size = new System.Drawing.Size(1869, 194);
            this.dominanceGroup.TabIndex = 31;
            // 
            // d9
            // 
            this.d9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("d9.BackgroundImage")));
            this.d9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.d9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.d9.Location = new System.Drawing.Point(1646, 3);
            this.d9.Name = "d9";
            this.d9.Size = new System.Drawing.Size(175, 188);
            this.d9.TabIndex = 30;
            this.d9.TabStop = true;
            this.d9.Text = "9";
            this.d9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.d9.UseVisualStyleBackColor = true;
            // 
            // d7
            // 
            this.d7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("d7.BackgroundImage")));
            this.d7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.d7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.d7.Location = new System.Drawing.Point(1241, 3);
            this.d7.Name = "d7";
            this.d7.Size = new System.Drawing.Size(175, 188);
            this.d7.TabIndex = 28;
            this.d7.TabStop = true;
            this.d7.Text = "7";
            this.d7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.d7.UseVisualStyleBackColor = true;
            // 
            // d8
            // 
            this.d8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("d8.BackgroundImage")));
            this.d8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.d8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.d8.Location = new System.Drawing.Point(1444, 3);
            this.d8.Name = "d8";
            this.d8.Size = new System.Drawing.Size(175, 188);
            this.d8.TabIndex = 29;
            this.d8.TabStop = true;
            this.d8.Text = "8";
            this.d8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.d8.UseVisualStyleBackColor = true;
            // 
            // d2
            // 
            this.d2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("d2.BackgroundImage")));
            this.d2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.d2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.d2.Location = new System.Drawing.Point(231, 3);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(175, 188);
            this.d2.TabIndex = 23;
            this.d2.TabStop = true;
            this.d2.Text = "2";
            this.d2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.d2.UseVisualStyleBackColor = true;
            // 
            // d1
            // 
            this.d1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("d1.BackgroundImage")));
            this.d1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.d1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.d1.Location = new System.Drawing.Point(32, 3);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(175, 188);
            this.d1.TabIndex = 22;
            this.d1.TabStop = true;
            this.d1.Text = "1";
            this.d1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.d1.UseVisualStyleBackColor = true;
            // 
            // d6
            // 
            this.d6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("d6.BackgroundImage")));
            this.d6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.d6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.d6.Location = new System.Drawing.Point(1035, 3);
            this.d6.Name = "d6";
            this.d6.Size = new System.Drawing.Size(175, 188);
            this.d6.TabIndex = 27;
            this.d6.TabStop = true;
            this.d6.Text = "6";
            this.d6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.d6.UseVisualStyleBackColor = true;
            // 
            // d3
            // 
            this.d3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("d3.BackgroundImage")));
            this.d3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.d3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.d3.Location = new System.Drawing.Point(431, 3);
            this.d3.Name = "d3";
            this.d3.Size = new System.Drawing.Size(175, 188);
            this.d3.TabIndex = 24;
            this.d3.TabStop = true;
            this.d3.Text = "3";
            this.d3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.d3.UseVisualStyleBackColor = true;
            // 
            // d5
            // 
            this.d5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("d5.BackgroundImage")));
            this.d5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.d5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.d5.Location = new System.Drawing.Point(833, 3);
            this.d5.Name = "d5";
            this.d5.Size = new System.Drawing.Size(175, 188);
            this.d5.TabIndex = 26;
            this.d5.TabStop = true;
            this.d5.Text = "5";
            this.d5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.d5.UseVisualStyleBackColor = true;
            // 
            // d4
            // 
            this.d4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("d4.BackgroundImage")));
            this.d4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.d4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.d4.Location = new System.Drawing.Point(633, 3);
            this.d4.Name = "d4";
            this.d4.Size = new System.Drawing.Size(175, 188);
            this.d4.TabIndex = 25;
            this.d4.TabStop = true;
            this.d4.Text = "4";
            this.d4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.d4.UseVisualStyleBackColor = true;
            // 
            // ButtonSubmitManikin
            // 
            this.ButtonSubmitManikin.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonSubmitManikin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonSubmitManikin.Location = new System.Drawing.Point(731, 866);
            this.ButtonSubmitManikin.Name = "ButtonSubmitManikin";
            this.ButtonSubmitManikin.Size = new System.Drawing.Size(539, 74);
            this.ButtonSubmitManikin.TabIndex = 32;
            this.ButtonSubmitManikin.Text = "Submit my Selection";
            this.ButtonSubmitManikin.UseVisualStyleBackColor = true;
            this.ButtonSubmitManikin.Click += new System.EventHandler(this.ButtonSubmitManikin_Click);
            // 
            // LabelFinishText
            // 
            this.LabelFinishText.Location = new System.Drawing.Point(501, 394);
            this.LabelFinishText.Name = "LabelFinishText";
            this.LabelFinishText.Size = new System.Drawing.Size(1000, 200);
            this.LabelFinishText.TabIndex = 33;
            this.LabelFinishText.Text = "Thank you for participating our experiment, now you may let the experimenter know" +
    " it is all finished.";
            this.LabelFinishText.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1953, 1061);
            this.Controls.Add(this.ButtonAbRNext);
            this.Controls.Add(this.LabelFinishText);
            this.Controls.Add(this.ButtonSubmitManikin);
            this.Controls.Add(this.dominanceGroup);
            this.Controls.Add(this.arousalGroup);
            this.Controls.Add(this.valenceGroup);
            this.Controls.Add(this.VideoPlayer);
            this.Controls.Add(this.ButtonStartExperiment);
            this.Controls.Add(this.LayoutPanel);
            this.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(9);
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayer)).EndInit();
            this.valenceGroup.ResumeLayout(false);
            this.arousalGroup.ResumeLayout(false);
            this.dominanceGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelTopText;
        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.Button ButtonStartExperiment;
        private AxWMPLib.AxWindowsMediaPlayer VideoPlayer;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Panel valenceGroup;
        private System.Windows.Forms.RadioButton v9;
        private System.Windows.Forms.RadioButton v7;
        private System.Windows.Forms.RadioButton v8;
        private System.Windows.Forms.RadioButton v2;
        private System.Windows.Forms.RadioButton v1;
        private System.Windows.Forms.RadioButton v6;
        private System.Windows.Forms.RadioButton v3;
        private System.Windows.Forms.RadioButton v5;
        private System.Windows.Forms.RadioButton v4;
        private System.Windows.Forms.Panel arousalGroup;
        private System.Windows.Forms.RadioButton a9;
        private System.Windows.Forms.RadioButton a7;
        private System.Windows.Forms.RadioButton a8;
        private System.Windows.Forms.RadioButton a2;
        private System.Windows.Forms.RadioButton a1;
        private System.Windows.Forms.RadioButton a6;
        private System.Windows.Forms.RadioButton a3;
        private System.Windows.Forms.RadioButton a5;
        private System.Windows.Forms.RadioButton a4;
        private System.Windows.Forms.Panel dominanceGroup;
        private System.Windows.Forms.RadioButton d9;
        private System.Windows.Forms.RadioButton d7;
        private System.Windows.Forms.RadioButton d8;
        private System.Windows.Forms.RadioButton d2;
        private System.Windows.Forms.RadioButton d1;
        private System.Windows.Forms.RadioButton d6;
        private System.Windows.Forms.RadioButton d3;
        private System.Windows.Forms.RadioButton d5;
        private System.Windows.Forms.RadioButton d4;
        private System.Windows.Forms.Button ButtonSubmitManikin;
        private System.Windows.Forms.Button ButtonAbRNext;
        private System.Windows.Forms.Label LabelFinishText;
    }
}

