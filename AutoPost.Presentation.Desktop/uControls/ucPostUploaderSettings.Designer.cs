namespace AutoPost.Presentation.Desktop.uControls
{
    partial class ucPostUploaderSettings
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            txtDefaultVideoFolder = new TextBox();
            txtSessionID = new TextBox();
            label1 = new Label();
            label2 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtDefaultVideoFolder
            // 
            txtDefaultVideoFolder.Location = new Point(141, 4);
            txtDefaultVideoFolder.Name = "txtDefaultVideoFolder";
            txtDefaultVideoFolder.Size = new Size(214, 23);
            txtDefaultVideoFolder.TabIndex = 0;
            // 
            // txtSessionID
            // 
            txtSessionID.Location = new Point(141, 34);
            txtSessionID.Name = "txtSessionID";
            txtSessionID.Size = new Size(214, 23);
            txtSessionID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 8);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 2;
            label1.Text = "Default videos folder:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 37);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 3;
            label2.Text = "TikTok Session id:";
            // 
            // button1
            // 
            button1.Location = new Point(363, 4);
            button1.Name = "button1";
            button1.Size = new Size(24, 24);
            button1.TabIndex = 4;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ucPostUploaderSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSessionID);
            Controls.Add(txtDefaultVideoFolder);
            Name = "ucPostUploaderSettings";
            Size = new Size(397, 62);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDefaultVideoFolder;
        private TextBox txtSessionID;
        private Label label1;
        private Label label2;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button1;
    }
}
