using AutoPost.Domain.Models;
using AutoPost.Presentation.Desktop.Controllers;
using AutoPost.Presentation.Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPost.Presentation.Desktop.uControls
{
    public partial class ucPost : UserControl
    {
        private Post _Post;
        private PostController _PostController;
        public ucPost()
        {
            InitializeComponent();
            _PostController = new PostController();
            _Post = _PostController.LoadPost() ?? new Post();

            // Vinculación de datos (Data Binding) entre los controles y las propiedades de la clase Post
            titleTextBox.DataBindings.Add("Text", _Post, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            descriptionTextBox.DataBindings.Add("Text", _Post, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
            tagsTextBox.DataBindings.Add("Text", _Post, "Tags", true, DataSourceUpdateMode.OnPropertyChanged);
            contentPathTextBox.DataBindings.Add("Text", _Post, "ContentPath", true, DataSourceUpdateMode.OnPropertyChanged);

            // Para la categoría y la privacidad, asumimos que son listas desplegables con opciones predefinidas
            // Debes asegurarte de que las listas desplegables estén pobladas con las opciones correspondientes antes de establecer el valor seleccionado
            categoryComboBox.DataSource = new List<string> { /* tus categorías aquí */ };
            categoryComboBox.DataBindings.Add("SelectedItem", _Post, "Category", true, DataSourceUpdateMode.OnPropertyChanged);

            privacyComboBox.DataSource = new List<string> { "public", "private", "unlisted" };
            privacyComboBox.DataBindings.Add("SelectedItem", _Post, "Privacy", true, DataSourceUpdateMode.OnPropertyChanged);
        }

    }
}
