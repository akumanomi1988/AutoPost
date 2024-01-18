namespace AutoPost.Presentation.Desktop.uControls
{
    partial class ucPost
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
            titleLabel = new Label();
            descriptionLabel = new Label();
            tagsLabel = new Label();
            contentPathLabel = new Label();
            categoryLabel = new Label();
            privacyLabel = new Label();
            titleTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            tagsTextBox = new TextBox();
            contentPathTextBox = new TextBox();
            categoryComboBox = new ComboBox();
            privacyComboBox = new ComboBox();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(13, 16);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(32, 15);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Title:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(13, 44);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(70, 15);
            descriptionLabel.TabIndex = 1;
            descriptionLabel.Text = "Description:";
            // 
            // tagsLabel
            // 
            tagsLabel.AutoSize = true;
            tagsLabel.Location = new Point(13, 72);
            tagsLabel.Name = "tagsLabel";
            tagsLabel.Size = new Size(33, 15);
            tagsLabel.TabIndex = 2;
            tagsLabel.Text = "Tags:";
            // 
            // contentPathLabel
            // 
            contentPathLabel.AutoSize = true;
            contentPathLabel.Location = new Point(13, 150);
            contentPathLabel.Name = "contentPathLabel";
            contentPathLabel.Size = new Size(80, 15);
            contentPathLabel.TabIndex = 3;
            contentPathLabel.Text = "Content Path:";
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new Point(13, 178);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(58, 15);
            categoryLabel.TabIndex = 4;
            categoryLabel.Text = "Category:";
            // 
            // privacyLabel
            // 
            privacyLabel.AutoSize = true;
            privacyLabel.Location = new Point(13, 206);
            privacyLabel.Name = "privacyLabel";
            privacyLabel.Size = new Size(48, 15);
            privacyLabel.TabIndex = 5;
            privacyLabel.Text = "Privacy:";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(120, 8);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(150, 23);
            titleTextBox.TabIndex = 6;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(120, 36);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(150, 23);
            descriptionTextBox.TabIndex = 7;
            // 
            // tagsTextBox
            // 
            tagsTextBox.Location = new Point(120, 64);
            tagsTextBox.Multiline = true;
            tagsTextBox.Name = "tagsTextBox";
            tagsTextBox.Size = new Size(150, 72);
            tagsTextBox.TabIndex = 8;
            // 
            // contentPathTextBox
            // 
            contentPathTextBox.Location = new Point(120, 142);
            contentPathTextBox.Name = "contentPathTextBox";
            contentPathTextBox.Size = new Size(150, 23);
            contentPathTextBox.TabIndex = 9;
            // 
            // categoryComboBox
            // 
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.Location = new Point(120, 170);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(150, 23);
            categoryComboBox.TabIndex = 10;
            // 
            // privacyComboBox
            // 
            privacyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            privacyComboBox.Location = new Point(120, 198);
            privacyComboBox.Name = "privacyComboBox";
            privacyComboBox.Size = new Size(150, 23);
            privacyComboBox.TabIndex = 11;
            // 
            // ucPost
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(privacyComboBox);
            Controls.Add(categoryComboBox);
            Controls.Add(contentPathTextBox);
            Controls.Add(tagsTextBox);
            Controls.Add(descriptionTextBox);
            Controls.Add(titleTextBox);
            Controls.Add(privacyLabel);
            Controls.Add(categoryLabel);
            Controls.Add(contentPathLabel);
            Controls.Add(tagsLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(titleLabel);
            Name = "ucPost";
            Size = new Size(284, 235);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label descriptionLabel;
        private Label tagsLabel;
        private Label contentPathLabel;
        private Label categoryLabel;
        private Label privacyLabel;

        private TextBox titleTextBox;
        private TextBox descriptionTextBox;
        private TextBox tagsTextBox;
        private TextBox contentPathTextBox;
        private ComboBox categoryComboBox;
        private ComboBox privacyComboBox;
    }
}
