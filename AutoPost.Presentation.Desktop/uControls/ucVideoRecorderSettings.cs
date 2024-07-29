using AutoPost.Presentation.Desktop.Controllers;
using AutoPost.Presentation.Desktop.ViewModel;

namespace AutoPost.Presentation.Desktop.uControls
{
    public partial class ucVideoRecorderSettings : UserControl
    {
        private readonly VideoRecorderSettings _ViewModel;
        private readonly VideoRecorderController _Controller;

        public ucVideoRecorderSettings()
        {
            InitializeComponent();
            _Controller = new();
            _ViewModel = _Controller.Load() ?? new VideoRecorderSettings();

            _ = txtIP.DataBindings.Add("Text", _ViewModel, nameof(_ViewModel.RecorderIP), false, DataSourceUpdateMode.OnPropertyChanged);
            _ = txtPort.DataBindings.Add("Text", _ViewModel, nameof(_ViewModel.Port), false, DataSourceUpdateMode.OnPropertyChanged);
            _ = txtPassword.DataBindings.Add("Text", _ViewModel, nameof(_ViewModel.Password), false, DataSourceUpdateMode.OnPropertyChanged);
            _ = numDuration.DataBindings.Add("Value", _ViewModel, nameof(_ViewModel.DurationRecorderSec), false, DataSourceUpdateMode.OnPropertyChanged);
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
