namespace AutoPost.Presentation.Desktop.uControls
{
    partial class ucVideoRecorderSettings
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
            lblIpRecorder = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtIP = new TextBox();
            txtPort = new TextBox();
            txtPassword = new TextBox();
            numDuration = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            SuspendLayout();
            // 
            // lblIpRecorder
            // 
            lblIpRecorder.AutoSize = true;
            lblIpRecorder.Location = new Point(3, 9);
            lblIpRecorder.Name = "lblIpRecorder";
            lblIpRecorder.Size = new Size(70, 15);
            lblIpRecorder.TabIndex = 0;
            lblIpRecorder.Text = "IP Recorder:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 34);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 1;
            label1.Text = "Port:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 59);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 84);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 3;
            label3.Text = "VideoDuration:";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(107, 6);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(144, 23);
            txtIP.TabIndex = 4;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(107, 31);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(144, 23);
            txtPort.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(107, 56);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(144, 23);
            txtPassword.TabIndex = 6;
            // 
            // numDuration
            // 
            numDuration.Location = new Point(109, 82);
            numDuration.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(142, 23);
            numDuration.TabIndex = 7;
            // 
            // ucVideoRecorderSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numDuration);
            Controls.Add(txtPassword);
            Controls.Add(txtPort);
            Controls.Add(txtIP);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblIpRecorder);
            Name = "ucVideoRecorderSettings";
            Size = new Size(341, 107);
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIpRecorder;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtIP;
        private TextBox txtPort;
        private TextBox txtPassword;
        private NumericUpDown numDuration;
    }
}
