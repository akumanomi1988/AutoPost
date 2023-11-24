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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            button1 = new Button();
            YTMetadataBS = new BindingSource(components);
            dataGridView1 = new DataGridView();
            titleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoryIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Platform = new DataGridViewTextBoxColumn();
            Privacy = new DataGridViewTextBoxColumn();
            VideoPath = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            textDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tagsBindingSource = new BindingSource(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            tagBox1 = new UserControls.TagBox();
            tagsBox1 = new UserControls.TagsBox();
            ((System.ComponentModel.ISupportInitialize)YTMetadataBS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tagsBindingSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(109, 83);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // YTMetadataBS
            // 
            YTMetadataBS.DataSource = typeof(Domain.Models.VideoMetadata);
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { titleDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, categoryIdDataGridViewTextBoxColumn, Platform, Privacy, VideoPath });
            dataGridView1.DataSource = YTMetadataBS;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(118, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(829, 261);
            dataGridView1.TabIndex = 1;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            titleDataGridViewTextBoxColumn.HeaderText = "Title";
            titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // categoryIdDataGridViewTextBoxColumn
            // 
            categoryIdDataGridViewTextBoxColumn.DataPropertyName = "CategoryId";
            categoryIdDataGridViewTextBoxColumn.HeaderText = "CategoryId";
            categoryIdDataGridViewTextBoxColumn.Name = "categoryIdDataGridViewTextBoxColumn";
            // 
            // Platform
            // 
            Platform.DataPropertyName = "Platform";
            Platform.HeaderText = "Platform";
            Platform.Name = "Platform";
            // 
            // Privacy
            // 
            Privacy.DataPropertyName = "Privacy";
            Privacy.HeaderText = "Privacy";
            Privacy.Name = "Privacy";
            // 
            // VideoPath
            // 
            VideoPath.DataPropertyName = "VideoPath";
            VideoPath.HeaderText = "VideoPath";
            VideoPath.Name = "VideoPath";
            // 
            // dataGridView2
            // 
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { textDataGridViewTextBoxColumn });
            dataGridView2.DataSource = tagsBindingSource;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(118, 270);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(829, 262);
            dataGridView2.TabIndex = 2;
            // 
            // textDataGridViewTextBoxColumn
            // 
            textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            textDataGridViewTextBoxColumn.HeaderText = "Text";
            textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            // 
            // tagsBindingSource
            // 
            tagsBindingSource.DataMember = "Tags";
            tagsBindingSource.DataSource = YTMetadataBS;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.1686745F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 87.83132F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 203F));
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 1, 0);
            tableLayoutPanel1.Controls.Add(dataGridView2, 1, 1);
            tableLayoutPanel1.Controls.Add(tagBox1, 2, 1);
            tableLayoutPanel1.Controls.Add(tagsBox1, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1154, 535);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tagBox1
            // 
            tagBox1.AcceptsReturn = true;
            tagBox1.Dock = DockStyle.Fill;
            tagBox1.Location = new Point(953, 270);
            tagBox1.Multiline = true;
            tagBox1.Name = "tagBox1";
            tagBox1.ScrollBars = ScrollBars.Vertical;
            tagBox1.Size = new Size(198, 262);
            tagBox1.TabIndex = 3;
            // 
            // tagsBox1
            // 
            tagsBox1.Dock = DockStyle.Fill;
            tagsBox1.Location = new Point(953, 3);
            tagsBox1.Name = "tagsBox1";
            tagsBox1.Size = new Size(198, 261);
            tagsBox1.TabIndex = 4;
            tagsBox1.TagList = (List<string>)resources.GetObject("tagsBox1.TagList");
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1154, 535);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "fmrMain";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)YTMetadataBS).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)tagsBindingSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private BindingSource YTMetadataBS;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoryIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn privacidadDataGridViewTextBoxColumn;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn Privacy;
        private DataGridViewTextBoxColumn VideoPath;
        private DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private BindingSource tagsBindingSource;
        private DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private TableLayoutPanel tableLayoutPanel1;
        private UserControls.TagBox tagBox1;
        private UserControls.TagsBox tagsBox1;
    }
}