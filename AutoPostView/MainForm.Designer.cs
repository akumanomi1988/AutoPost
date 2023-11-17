namespace AutoPostView
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
            btnSend = new Button();
            txtPrompt = new TextBox();
            txtResponse = new TextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnSeeKey01 = new Button();
            txtApiKey = new TextBox();
            tabPage2 = new TabPage();
            textBox1 = new TextBox();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            textBox2 = new TextBox();
            button1 = new Button();
            btnTiktokUpload = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Location = new Point(689, 60);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(85, 85);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += button1_ClickAsync;
            // 
            // txtPrompt
            // 
            txtPrompt.Location = new Point(6, 60);
            txtPrompt.Multiline = true;
            txtPrompt.Name = "txtPrompt";
            txtPrompt.PlaceholderText = "Prompt";
            txtPrompt.Size = new Size(677, 85);
            txtPrompt.TabIndex = 1;
            // 
            // txtResponse
            // 
            txtResponse.Location = new Point(6, 151);
            txtResponse.Multiline = true;
            txtResponse.Name = "txtResponse";
            txtResponse.PlaceholderText = "Response";
            txtResponse.Size = new Size(768, 263);
            txtResponse.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(794, 450);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnSeeKey01);
            tabPage1.Controls.Add(txtApiKey);
            tabPage1.Controls.Add(txtResponse);
            tabPage1.Controls.Add(btnSend);
            tabPage1.Controls.Add(txtPrompt);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(786, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "ChatGPT";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSeeKey01
            // 
            btnSeeKey01.Location = new Point(744, 12);
            btnSeeKey01.Name = "btnSeeKey01";
            btnSeeKey01.Size = new Size(30, 23);
            btnSeeKey01.TabIndex = 4;
            btnSeeKey01.Text = "-";
            btnSeeKey01.UseVisualStyleBackColor = true;
            btnSeeKey01.MouseDown += btnSeeKey01_MouseDown;
            btnSeeKey01.MouseUp += btnSeeKey01_MouseUp;
            // 
            // txtApiKey
            // 
            txtApiKey.Location = new Point(6, 12);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.PlaceholderText = "API Key";
            txtApiKey.Size = new Size(732, 23);
            txtApiKey.TabIndex = 3;
            txtApiKey.Text = "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";
            txtApiKey.UseSystemPasswordChar = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(786, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "ImagesGeneration";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 9);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "API Key";
            textBox1.Size = new Size(753, 23);
            textBox1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(786, 422);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "VideoGeneration";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btnTiktokUpload);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(786, 422);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Upload";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(textBox2);
            tabPage5.Controls.Add(button1);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(786, 422);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Twitter";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(231, 46);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(183, 23);
            textBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(29, 29);
            button1.Name = "button1";
            button1.Size = new Size(103, 50);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnTiktokUpload
            // 
            btnTiktokUpload.Location = new Point(136, 104);
            btnTiktokUpload.Name = "btnTiktokUpload";
            btnTiktokUpload.Size = new Size(75, 23);
            btnTiktokUpload.TabIndex = 0;
            btnTiktokUpload.Text = "upload";
            btnTiktokUpload.UseVisualStyleBackColor = true;
            btnTiktokUpload.Click += button2_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 450);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "AutoPost";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSend;
        private TextBox txtPrompt;
        private TextBox txtResponse;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox txtApiKey;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button btnSeeKey01;
        private TextBox textBox1;
        private TabPage tabPage5;
        private TextBox textBox2;
        private Button button1;
        private Button btnTiktokUpload;
    }
}