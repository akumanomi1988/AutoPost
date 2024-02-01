using AutoPost.Presentation.Desktop.Controllers;
using AutoPost.Presentation.Desktop.ViewModel;

namespace AutoPost.Presentation.Desktop.uControls
{
    public partial class ucPostUploaderSettings : UserControl
    {
        private readonly PostUploaderController _Controller;
        private readonly PostUploaderSettings _ViewModel;
        public ucPostUploaderSettings()
        {
            InitializeComponent();
            _Controller = new();
            _ViewModel = _Controller.Load() ?? new PostUploaderSettings();
            _ = txtDefaultVideoFolder.DataBindings.Add("Text", _ViewModel, nameof(_ViewModel.DefaultVideoFolder), false, DataSourceUpdateMode.OnPropertyChanged);
            _ = txtSessionID.DataBindings.Add("Text", _ViewModel, nameof(_ViewModel.SessionID), false, DataSourceUpdateMode.OnPropertyChanged);

        }
        public PostUploaderSettings GetPostUploaderSettings()
        {
            return _ViewModel;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDefaultVideoFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        public void SaveState()
        {
            _Controller.Save(_ViewModel);
        }

    }
}
