namespace AutoPost.View
{
    partial class frmUploaderTest
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            openFileDialog = new OpenFileDialog();
            btnUpload = new Button();
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            lblTitle = new Label();
            lblDescription = new Label();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            openFileDialog.Filter = "Video files (*.mp4;*.avi)|*.mp4;*.avi";
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(64, 162);
            btnUpload.Margin = new Padding(4, 3, 4, 3);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(117, 27);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "Upload Video";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(64, 12);
            txtTitle.Margin = new Padding(4, 3, 4, 3);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(233, 23);
            txtTitle.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(81, 69);
            txtDescription.Margin = new Padding(4, 3, 4, 3);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(233, 69);
            txtDescription.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(6, 12);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(29, 15);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Title";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(6, 69);
            lblDescription.Margin = new Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            // 
            // frmUploaderTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 288);
            Controls.Add(btnUpload);
            Controls.Add(txtTitle);
            Controls.Add(txtDescription);
            Controls.Add(lblTitle);
            Controls.Add(lblDescription);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmUploaderTest";
            Text = "YTUploader";
            ResumeLayout(false);
            PerformLayout();
        }

        private OpenFileDialog openFileDialog;
        private Button btnUpload;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private Label lblTitle;
        private Label lblDescription;
    }
}