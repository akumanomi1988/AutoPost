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
            button1 = new Button();
            postBindingSource = new BindingSource(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            tagsBox1 = new UserControls.TagsBox();
            contentTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            privacyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            titleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)postBindingSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // postBindingSource
            // 
            postBindingSource.DataSource = typeof(Domain.Models.Post);
            postBindingSource.CurrentChanged += postBindingSource_CurrentChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.1686745F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 87.83132F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 203F));
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 1, 1);
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
            // tagsBox1
            // 
            tagsBox1.Dock = DockStyle.Fill;
            tagsBox1.Location = new Point(953, 3);
            tagsBox1.Name = "tagsBox1";
            tagsBox1.Size = new Size(198, 261);
            tagsBox1.TabIndex = 4;
            // 
            // contentTypeDataGridViewTextBoxColumn
            // 
            contentTypeDataGridViewTextBoxColumn.DataPropertyName = "ContentType";
            contentTypeDataGridViewTextBoxColumn.HeaderText = "ContentType";
            contentTypeDataGridViewTextBoxColumn.Name = "contentTypeDataGridViewTextBoxColumn";
            // 
            // createdDataGridViewTextBoxColumn
            // 
            createdDataGridViewTextBoxColumn.DataPropertyName = "Created";
            createdDataGridViewTextBoxColumn.HeaderText = "Created";
            createdDataGridViewTextBoxColumn.Name = "createdDataGridViewTextBoxColumn";
            // 
            // privacyDataGridViewTextBoxColumn
            // 
            privacyDataGridViewTextBoxColumn.DataPropertyName = "Privacy";
            privacyDataGridViewTextBoxColumn.HeaderText = "Privacy";
            privacyDataGridViewTextBoxColumn.Name = "privacyDataGridViewTextBoxColumn";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // titleDataGridViewTextBoxColumn
            // 
            titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            titleDataGridViewTextBoxColumn.HeaderText = "Title";
            titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, titleDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, categoryDataGridViewTextBoxColumn, privacyDataGridViewTextBoxColumn, createdDataGridViewTextBoxColumn, contentTypeDataGridViewTextBoxColumn });
            dataGridView1.DataSource = postBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(118, 270);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(829, 262);
            dataGridView1.TabIndex = 1;
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
            ((System.ComponentModel.ISupportInitialize)postBindingSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridViewTextBoxColumn categoryIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn privacidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Platform;
        private DataGridViewTextBoxColumn VideoPath;
        private DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private TableLayoutPanel tableLayoutPanel1;
        private UserControls.TagsBox tagsBox1;
        private BindingSource postBindingSource;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn privacyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn contentTypeDataGridViewTextBoxColumn;
    }
}