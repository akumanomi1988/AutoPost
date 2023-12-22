namespace AutoPost.AnimationCanva.Test
{
    partial class Form1
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
            Animation = new PictureBox();
            btnStart = new Button();
            btnStop = new Button();
            ((System.ComponentModel.ISupportInitialize)Animation).BeginInit();
            SuspendLayout();
            // 
            // Animation
            // 
            Animation.Location = new Point(55, 57);
            Animation.Name = "Animation";
            Animation.Size = new Size(195, 227);
            Animation.TabIndex = 0;
            Animation.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(299, 36);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(186, 73);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(307, 189);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(186, 73);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(Animation);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Animation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Animation;
        private Button btnStart;
        private Button btnStop;
    }
}