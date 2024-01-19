using AutoPost.Presentation.Desktop.Controllers;
using AutoPost.Presentation.Desktop.ViewModel;
using System.ComponentModel;

namespace AutoPost.Presentation.Desktop.uControls
{
    public partial class ucPostAnimatorSettings : UserControl
    {
        public event EventHandler? BallNumberChangedInUCPost;
        private PostAnimatorSettings _ViewModel { get; set; }
        private PostAnimatorController _Controller { get; set; }
        public ucPostAnimatorSettings()
        {
            InitializeComponent();
            _Controller = new();
            _ViewModel = _Controller.Load() ?? new PostAnimatorSettings();
            numDuracionVideo.DataBindings.Add("Value", _ViewModel, nameof(_ViewModel.Duration), false, DataSourceUpdateMode.OnPropertyChanged);
            txtMusicPath.DataBindings.Add("Text", _ViewModel, "MusicPath");
            txtSoundsPath.DataBindings.Add("Text", _ViewModel, "SoundsPath");
            numBallsNumber.DataBindings.Add("Value", _ViewModel, "BallsNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            numWindowWidth.DataBindings.Add("Value", _ViewModel, nameof(_ViewModel.WindowWidth), false, DataSourceUpdateMode.OnPropertyChanged);
            numWindowHeight.DataBindings.Add("Value", _ViewModel, nameof(_ViewModel.WindowHeight), false, DataSourceUpdateMode.OnPropertyChanged);
            _ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "BallsNumber")
            {
                HandleBallNumberChanged();
            }
        }
        private void HandleBallNumberChanged()
        {
            BallNumberChangedInUCPost?.Invoke(this, EventArgs.Empty);
        }
        public PostAnimatorSettings GetSettingsViewModel()
        {
            return _ViewModel;
        }
        private void btnMusicPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtMusicPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSoundsPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSoundsPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        public void SaveState()
        {
            if (_ViewModel == null) { return; }
            _Controller.Save(_ViewModel);
        }
    }
}
