namespace AutoPost.Presentation.Desktop.UserControls
{
    partial class TagsBox
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
            this.flowLayoutPanel = new FlowLayoutPanel();
            this.textBox = new TextBox();

            // Configura el FlowLayoutPanel
            this.flowLayoutPanel.Dock = DockStyle.Top;
            this.flowLayoutPanel.AutoSize = true;
            this.Controls.Add(this.flowLayoutPanel);

            // Configura el TextBox
            this.textBox.Dock = DockStyle.Bottom;
            this.textBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            this.Controls.Add(this.textBox);
        }

        #endregion
    }
}
