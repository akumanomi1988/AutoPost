using AutoPost.Presentation.Desktop.Controllers;
using AutoPost.Presentation.Desktop.ViewModel;

namespace AutoPost.Presentation.Desktop.uControls
{
    public partial class ucVideoRecorderSettings : UserControl
    {
        private VideoRecorderSettings _ViewModel;
        private VideoRecorderController _Controller;

        public ucVideoRecorderSettings()
        {
            InitializeComponent();
            _Controller = new();
            _ViewModel = _Controller.Load() ?? new VideoRecorderSettings();

            txtIP.DataBindings.Add("Text", _ViewModel, nameof(_ViewModel.RecorderIP), false, DataSourceUpdateMode.OnPropertyChanged);
            txtPort.DataBindings.Add("Text", _ViewModel, nameof(_ViewModel.Port), false, DataSourceUpdateMode.OnPropertyChanged);
            txtPassword.DataBindings.Add("Text", _ViewModel, nameof(_ViewModel.Password), false, DataSourceUpdateMode.OnPropertyChanged);
            numDuration.DataBindings.Add("Value", _ViewModel, nameof(_ViewModel.DurationRecorderSec), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public VideoRecorderSettings GetVideoRecorderSettings()
        {
            return _ViewModel;
        }
        public void SaveState()
        {
            _Controller.Save(_ViewModel);
        }
    }
}
