namespace AutoPost.Presentation.Desktop.UserControls
{
    partial class PostDetails
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox2 = new TextBox();
            postBindingSource = new BindingSource(components);
            textBox1 = new TextBox();
            label1 = new Label();
            tbbContentPathSearch = new TextBoxButton();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)postBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(textBox2, 0, 2);
            tableLayoutPanel1.Controls.Add(textBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tbbContentPathSearch, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 16;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(390, 463);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.DataBindings.Add(new Binding("Text", postBindingSource, "Description", true));
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(3, 78);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Description";
            textBox2.Size = new Size(384, 102);
            textBox2.TabIndex = 1;
            // 
            // postBindingSource
            // 
            postBindingSource.DataSource = typeof(Domain.Models.Post);
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", postBindingSource, "Title", true));
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 51);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Title";
            textBox1.Size = new Size(384, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Cascadia Code", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(384, 48);
            label1.TabIndex = 4;
            label1.Text = "POST DETAILS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbbContentPathSearch
            // 
            tbbContentPathSearch.Dock = DockStyle.Fill;
            tbbContentPathSearch.Location = new Point(3, 186);
            tbbContentPathSearch.Name = "tbbContentPathSearch";
            tbbContentPathSearch.PlaceHolderText = "Content full path";
            tbbContentPathSearch.Size = new Size(384, 30);
            tbbContentPathSearch.TabIndex = 5;
            tbbContentPathSearch.UCButtonAction = null;
            tbbContentPathSearch.UCButtonText = "Search";
            tbbContentPathSearch.UCText = "";
            // 
            // PostDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "PostDetails";
            Size = new Size(390, 463);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)postBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox2;
        private TextBox textBox1;
        private BindingSource postBindingSource;
        private Label label1;
        private TextBoxButton tbbContentPathSearch;
    }
}
