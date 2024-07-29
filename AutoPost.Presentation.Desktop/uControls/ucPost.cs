using AutoPost.Presentation.Desktop.Controllers;
using AutoPost.Presentation.Desktop.ViewModel;

namespace AutoPost.Presentation.Desktop.uControls
{
    public partial class ucPost : UserControl
    {
        private readonly PostSettings _ViewModel;
        private readonly PostController _Controller;
        public ucPost()
        {
            InitializeComponent();
            _Controller = new PostController();
            _ViewModel = _Controller.Load() ?? new PostSettings();

            _ = titleTextBox.DataBindings.Add("Text", _ViewModel, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            _ = descriptionTextBox.DataBindings.Add("Text", _ViewModel, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
            _ = tagsTextBox.DataBindings.Add("Text", _ViewModel, "TagsText", true, DataSourceUpdateMode.OnPropertyChanged);
            _ = contentPathTextBox.DataBindings.Add("Text", _ViewModel, "ContentPath", true, DataSourceUpdateMode.OnPropertyChanged);

            categoryComboBox.DataSource = YTCategories.Get();
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "ID";

            _ = categoryComboBox.DataBindings.Add("SelectedItem", _ViewModel, "Category", true, DataSourceUpdateMode.OnPropertyChanged);
            privacyComboBox.DataSource = new List<string> { "public", "private", "unlisted" };
            _ = privacyComboBox.DataBindings.Add("SelectedItem", _ViewModel, "Privacy", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public PostSettings GetPost()
        {
            return _ViewModel;
        }
        public void SaveState()
        {
            _Controller.Save(_ViewModel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                contentPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
