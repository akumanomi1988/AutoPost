

namespace AutoPost.Presentation.Desktop.uControls
{
    partial class ucPostAnimatorSettings
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
            numDuracionVideo = new NumericUpDown();
            lblDuracionVideo = new Label();
            txtMusicPath = new TextBox();
            btnMusicPath = new Button();
            lblMusicPath = new Label();
            txtSoundsPath = new TextBox();
            btnSoundsPath = new Button();
            lblSoundsPath = new Label();
            numBallsNumber = new NumericUpDown();
            lblBallsNumber = new Label();
            lblWindowWidth = new Label();
            lblWindowHeight = new Label();
            numWindowHeight = new NumericUpDown();
            numWindowWidth = new NumericUpDown();
            folderBrowserDialog1 = new FolderBrowserDialog();
            lblHostId = new Label();
            txtHostId = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numDuracionVideo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBallsNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWindowHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWindowWidth).BeginInit();
            SuspendLayout();
            // 
            // numDuracionVideo
            // 
            numDuracionVideo.Location = new Point(132, 11);
            numDuracionVideo.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            numDuracionVideo.Name = "numDuracionVideo";
            numDuracionVideo.Size = new Size(120, 23);
            numDuracionVideo.TabIndex = 22;
            // 
            // lblDuracionVideo
            // 
            lblDuracionVideo.AutoSize = true;
            lblDuracionVideo.Location = new Point(3, 11);
            lblDuracionVideo.Name = "lblDuracionVideo";
            lblDuracionVideo.Size = new Size(85, 15);
            lblDuracionVideo.TabIndex = 23;
            lblDuracionVideo.Text = "Video duration";
            // 
            // txtMusicPath
            // 
            txtMusicPath.Location = new Point(132, 41);
            txtMusicPath.Name = "txtMusicPath";
            txtMusicPath.Size = new Size(160, 23);
            txtMusicPath.TabIndex = 24;
            // 
            // btnMusicPath
            // 
            btnMusicPath.Location = new Point(302, 41);
            btnMusicPath.Name = "btnMusicPath";
            btnMusicPath.Size = new Size(30, 20);
            btnMusicPath.TabIndex = 25;
            btnMusicPath.Text = "...";
            btnMusicPath.Click += btnMusicPath_Click;
            // 
            // lblMusicPath
            // 
            lblMusicPath.AutoSize = true;
            lblMusicPath.Location = new Point(3, 41);
            lblMusicPath.Name = "lblMusicPath";
            lblMusicPath.Size = new Size(69, 15);
            lblMusicPath.TabIndex = 26;
            lblMusicPath.Text = "Music path:";
            // 
            // txtSoundsPath
            // 
            txtSoundsPath.Location = new Point(132, 71);
            txtSoundsPath.Name = "txtSoundsPath";
            txtSoundsPath.Size = new Size(160, 23);
            txtSoundsPath.TabIndex = 27;
            // 
            // btnSoundsPath
            // 
            btnSoundsPath.Location = new Point(302, 71);
            btnSoundsPath.Name = "btnSoundsPath";
            btnSoundsPath.Size = new Size(30, 20);
            btnSoundsPath.TabIndex = 28;
            btnSoundsPath.Text = "...";
            btnSoundsPath.Click += btnSoundsPath_Click;
            // 
            // lblSoundsPath
            // 
            lblSoundsPath.AutoSize = true;
            lblSoundsPath.Location = new Point(3, 71);
            lblSoundsPath.Name = "lblSoundsPath";
            lblSoundsPath.Size = new Size(76, 15);
            lblSoundsPath.TabIndex = 29;
            lblSoundsPath.Text = "Sounds path:";
            // 
            // numBallsNumber
            // 
            numBallsNumber.Location = new Point(132, 101);
            numBallsNumber.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numBallsNumber.Name = "numBallsNumber";
            numBallsNumber.Size = new Size(120, 23);
            numBallsNumber.TabIndex = 30;
            // 
            // lblBallsNumber
            // 
            lblBallsNumber.AutoSize = true;
            lblBallsNumber.Location = new Point(3, 101);
            lblBallsNumber.Name = "lblBallsNumber";
            lblBallsNumber.Size = new Size(79, 15);
            lblBallsNumber.TabIndex = 31;
            lblBallsNumber.Text = "Balls number:";
            // 
            // lblWindowWidth
            // 
            lblWindowWidth.AutoSize = true;
            lblWindowWidth.Location = new Point(3, 131);
            lblWindowWidth.Name = "lblWindowWidth";
            lblWindowWidth.Size = new Size(89, 15);
            lblWindowWidth.TabIndex = 33;
            lblWindowWidth.Text = "Window Heigh:";
            // 
            // lblWindowHeight
            // 
            lblWindowHeight.AutoSize = true;
            lblWindowHeight.Location = new Point(3, 161);
            lblWindowHeight.Name = "lblWindowHeight";
            lblWindowHeight.Size = new Size(89, 15);
            lblWindowHeight.TabIndex = 35;
            lblWindowHeight.Text = "Window Width:";
            // 
            // numWindowHeight
            // 
            numWindowHeight.Location = new Point(132, 161);
            numWindowHeight.Maximum = new decimal(new int[] { 4320, 0, 0, 0 });
            numWindowHeight.Name = "numWindowHeight";
            numWindowHeight.Size = new Size(120, 23);
            numWindowHeight.TabIndex = 34;
            // 
            // numWindowWidth
            // 
            numWindowWidth.Location = new Point(132, 131);
            numWindowWidth.Maximum = new decimal(new int[] { 7680, 0, 0, 0 });
            numWindowWidth.Name = "numWindowWidth";
            numWindowWidth.Size = new Size(120, 23);
            numWindowWidth.TabIndex = 32;
            // 
            // lblHostId
            // 
            lblHostId.AutoSize = true;
            lblHostId.Location = new Point(3, 195);
            lblHostId.Name = "lblHostId";
            lblHostId.Size = new Size(48, 15);
            lblHostId.TabIndex = 36;
            lblHostId.Text = "Host Id:";
            // 
            // txtHostId
            // 
            txtHostId.Location = new Point(132, 190);
            txtHostId.Name = "txtHostId";
            txtHostId.Size = new Size(160, 23);
            txtHostId.TabIndex = 37;
            txtHostId.Text = "valorantesports";
            // 
            // button1
            // 
            button1.Location = new Point(309, 190);
            button1.Name = "button1";
            button1.Size = new Size(26, 24);
            button1.TabIndex = 38;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ucPostAnimatorSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(txtHostId);
            Controls.Add(lblHostId);
            Controls.Add(numDuracionVideo);
            Controls.Add(lblDuracionVideo);
            Controls.Add(txtMusicPath);
            Controls.Add(btnMusicPath);
            Controls.Add(lblMusicPath);
            Controls.Add(txtSoundsPath);
            Controls.Add(btnSoundsPath);
            Controls.Add(lblSoundsPath);
            Controls.Add(numBallsNumber);
            Controls.Add(lblBallsNumber);
            Controls.Add(numWindowWidth);
            Controls.Add(lblWindowWidth);
            Controls.Add(numWindowHeight);
            Controls.Add(lblWindowHeight);
            Name = "ucPostAnimatorSettings";
            Size = new Size(345, 220);
            ((System.ComponentModel.ISupportInitialize)numDuracionVideo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBallsNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWindowHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWindowWidth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown numDuracionVideo;
        private Label lblDuracionVideo;
        private TextBox txtMusicPath;
        private Button btnMusicPath;
        private Label lblMusicPath;
        private TextBox txtSoundsPath;
        private Button btnSoundsPath;
        private Label lblSoundsPath;
        private NumericUpDown numBallsNumber;
        private Label lblBallsNumber;
        private Label lblWindowWidth;
        private Label lblWindowHeight;
        private NumericUpDown numWindowHeight;
        private NumericUpDown numWindowWidth;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label lblHostId;
        private TextBox txtHostId;
        private Button button1;
    }
}
