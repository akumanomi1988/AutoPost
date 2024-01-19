using AutoPost.Presentation.Desktop.uControls;
namespace AutoPost.Presentation.Desktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStripContainer1 = new ToolStripContainer();
            statusStrip1 = new StatusStrip();
            lblSocketStatus = new ToolStripStatusLabel();
            lblRecorderStatus = new ToolStripStatusLabel();
            lblAnimationStatus = new ToolStripStatusLabel();
            pbAuto = new ToolStripProgressBar();
            pbYTUploading = new ToolStripProgressBar();
            pbTikTokUploading = new ToolStripProgressBar();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            ucPostUploaderSettings1 = new ucPostUploaderSettings();
            ucPostAnimatorSettings = new ucPostAnimatorSettings();
            ucVideoRecorderSettings1 = new ucVideoRecorderSettings();
            ucPostData1 = new ucPost();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            toolStripButton6 = new ToolStripButton();
            toolStripButton7 = new ToolStripButton();
            toolStripButton8 = new ToolStripButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            toolStripContainer1.BottomToolStripPanel.Controls.Add(statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(splitContainer1);
            toolStripContainer1.ContentPanel.Size = new Size(897, 634);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(897, 681);
            toolStripContainer1.TabIndex = 0;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.None;
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblSocketStatus, lblRecorderStatus, lblAnimationStatus, pbAuto, pbYTUploading, pbTikTokUploading });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(897, 22);
            statusStrip1.TabIndex = 0;
            // 
            // lblSocketStatus
            // 
            lblSocketStatus.Name = "lblSocketStatus";
            lblSocketStatus.Size = new Size(77, 17);
            lblSocketStatus.Text = "Socket Status";
            // 
            // lblRecorderStatus
            // 
            lblRecorderStatus.Name = "lblRecorderStatus";
            lblRecorderStatus.Size = new Size(89, 17);
            lblRecorderStatus.Text = "Recorder Status";
            // 
            // lblAnimationStatus
            // 
            lblAnimationStatus.Name = "lblAnimationStatus";
            lblAnimationStatus.Size = new Size(98, 17);
            lblAnimationStatus.Text = "Animation Status";
            // 
            // pbAuto
            // 
            pbAuto.Name = "pbAuto";
            pbAuto.Size = new Size(100, 16);
            pbAuto.Tag = "";
            pbAuto.ToolTipText = "Auto";
            // 
            // pbYTUploading
            // 
            pbYTUploading.Name = "pbYTUploading";
            pbYTUploading.Size = new Size(100, 16);
            pbYTUploading.ToolTipText = "YT Uploading";
            // 
            // pbTikTokUploading
            // 
            pbTikTokUploading.Name = "pbTikTokUploading";
            pbTikTokUploading.Size = new Size(100, 16);
            pbTikTokUploading.ToolTipText = "TikTok Uploading";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer1.Size = new Size(897, 634);
            splitContainer1.SplitterDistance = 455;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(ucPostUploaderSettings1, 0, 0);
            tableLayoutPanel1.Controls.Add(ucPostAnimatorSettings, 0, 2);
            tableLayoutPanel1.Controls.Add(ucVideoRecorderSettings1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(455, 634);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // ucPostUploaderSettings1
            // 
            ucPostUploaderSettings1.BackColor = Color.White;
            ucPostUploaderSettings1.Dock = DockStyle.Fill;
            ucPostUploaderSettings1.Location = new Point(3, 3);
            ucPostUploaderSettings1.Name = "ucPostUploaderSettings1";
            ucPostUploaderSettings1.Size = new Size(449, 66);
            ucPostUploaderSettings1.TabIndex = 1;
            // 
            // ucPostAnimatorSettings
            // 
            ucPostAnimatorSettings.Dock = DockStyle.Fill;
            ucPostAnimatorSettings.Location = new Point(3, 194);
            ucPostAnimatorSettings.Name = "ucPostAnimatorSettings";
            ucPostAnimatorSettings.Size = new Size(449, 437);
            ucPostAnimatorSettings.TabIndex = 0;
            // 
            // ucVideoRecorderSettings1
            // 
            ucVideoRecorderSettings1.Dock = DockStyle.Fill;
            ucVideoRecorderSettings1.Location = new Point(3, 75);
            ucVideoRecorderSettings1.Name = "ucVideoRecorderSettings1";
            ucVideoRecorderSettings1.Size = new Size(449, 113);
            ucVideoRecorderSettings1.TabIndex = 2;
            // 
            // ucPostData1
            // 
            ucPostData1.Dock = DockStyle.Fill;
            ucPostData1.Location = new Point(3, 3);
            ucPostData1.Name = "ucPostData1";
            ucPostData1.Size = new Size(438, 263);
            ucPostData1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5, toolStripButton6, toolStripButton7, toolStripButton8 });
            toolStrip1.Location = new Point(3, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(647, 25);
            toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(81, 22);
            toolStripButton1.Text = "OBS Connect";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(92, 22);
            toolStripButton2.Text = "Start animation";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(92, 22);
            toolStripButton3.Text = "Start Recording";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(94, 22);
            toolStripButton4.Text = "Stop Animation";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(92, 22);
            toolStripButton5.Text = "Stop Recording";
            toolStripButton5.Click += toolStripButton5_Click;
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton6.Image = (Image)resources.GetObject("toolStripButton6.Image");
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(62, 22);
            toolStripButton6.Text = "YTUpload";
            toolStripButton6.Click += toolStripButton6_Click;
            // 
            // toolStripButton7
            // 
            toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton7.Image = (Image)resources.GetObject("toolStripButton7.Image");
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(85, 22);
            toolStripButton7.Text = "TikTok Upload";
            toolStripButton7.Click += toolStripButton7_Click;
            // 
            // toolStripButton8
            // 
            toolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton8.Image = (Image)resources.GetObject("toolStripButton8.Image");
            toolStripButton8.ImageTransparentColor = Color.Magenta;
            toolStripButton8.Name = "toolStripButton8";
            toolStripButton8.Size = new Size(37, 22);
            toolStripButton8.Text = "Auto";
            toolStripButton8.Click += toolStripButton8_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(ucPostData1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(438, 634);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 681);
            Controls.Add(toolStripContainer1);
            MinimumSize = new Size(720, 720);
            Name = "MainForm";
            Text = "MainForm";
            FormClosed += MainForm_FormClosed;
            toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer1.BottomToolStripPanel.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer toolStripContainer1;
        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripStatusLabel lblSocketStatus;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripButton8;
        private SplitContainer splitContainer1;
        private ucPostAnimatorSettings ucPostAnimatorSettings;
        private TableLayoutPanel tableLayoutPanel1;
        private ucPostUploaderSettings ucPostUploaderSettings1;
        private ucPost ucPostData1;
        private ucVideoRecorderSettings ucVideoRecorderSettings1;
        private ToolStripStatusLabel lblRecorderStatus;
        private ToolStripStatusLabel lblAnimationStatus;
        private ToolStripProgressBar pbAuto;
        private ToolStripProgressBar pbYTUploading;
        private ToolStripProgressBar pbTikTokUploading;
        private TableLayoutPanel tableLayoutPanel2;
    }
}