namespace AutoPost.Presentation.Desktop.UserControls
{
    partial class TextBoxButton
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
            TextBox = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            Button = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            TextBox.Dock = DockStyle.Fill;
            TextBox.Location = new Point(3, 3);
            TextBox.Name = "textBox1";
            TextBox.Size = new Size(288, 23);
            TextBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(TextBox, 0, 0);
            tableLayoutPanel1.Controls.Add(Button, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(392, 29);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // Button
            // 
            Button.Dock = DockStyle.Fill;
            Button.Location = new Point(297, 3);
            Button.Name = "Button";
            Button.Size = new Size(92, 23);
            Button.TabIndex = 1;
            Button.Text = PlaceHolderText;
            Button.UseVisualStyleBackColor = true;
            Button.Click += Button_Click;
            // 
            // TextBoxButton
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "TextBoxButton";
            Size = new Size(392, 29);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TextBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Button Button;
    }
}
