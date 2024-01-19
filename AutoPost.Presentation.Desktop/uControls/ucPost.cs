using AutoPost.Presentation.Desktop.Controllers;
using AutoPost.Presentation.Desktop.ViewModel;

namespace AutoPost.Presentation.Desktop.uControls
{
    public partial class ucPost : UserControl
    {
        private PostSettings _ViewModel;
        private PostController _Controller;
        public ucPost()
        {
            InitializeComponent();
            _Controller = new PostController();
            _ViewModel = _Controller.Load() ?? new PostSettings();

            // Vinculación de datos (Data Binding) entre los controles y las propiedades de la clase Post
            titleTextBox.DataBindings.Add("Text", _ViewModel, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            descriptionTextBox.DataBindings.Add("Text", _ViewModel, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
            tagsTextBox.DataBindings.Add("Text", _ViewModel, "TagsText", true, DataSourceUpdateMode.OnPropertyChanged);
            contentPathTextBox.DataBindings.Add("Text", _ViewModel, "ContentPath", true, DataSourceUpdateMode.OnPropertyChanged);

            // Para la categoría y la privacidad, asumimos que son listas desplegables con opciones predefinidas
            // Debes asegurarte de que las listas desplegables estén pobladas con las opciones correspondientes antes de establecer el valor seleccionado
            categoryComboBox.DataSource = YTCategories.Get();
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "ID";


            categoryComboBox.DataBindings.Add("SelectedItem", _ViewModel, "Category", true, DataSourceUpdateMode.OnPropertyChanged);

            privacyComboBox.DataSource = new List<string> { "public", "private", "unlisted" };
            privacyComboBox.DataBindings.Add("SelectedItem", _ViewModel, "Privacy", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public PostSettings GetPost()
        {
            return _ViewModel;
        }
        public void SaveState()
        {
            _Controller.Save(_ViewModel);
        }
    }
}
