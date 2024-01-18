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
    public partial class ucPostGeneratorSettings : UserControl
    {
        private PostGeneratorSettings viewModel { get; set; }
        private PostGeneratorSettingsController controller { get; set; }
        public ucPostGeneratorSettings()
        {
            InitializeComponent();
            controller = new();
            viewModel = controller.LoadPostGeneratorSettings() ?? new PostGeneratorSettings();
            numDuracionVideo.DataBindings.Add("Value", viewModel, "DuracionVideo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtMusicPath.DataBindings.Add("Text", viewModel, "MusicPath");
            txtSoundsPath.DataBindings.Add("Text", viewModel, "SoundsPath");
            numBallsNumber.DataBindings.Add("Value", viewModel, "BallsNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            numWindowWidth.DataBindings.Add("Value", viewModel, "WindowWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            numWindowHeight.DataBindings.Add("Value", viewModel, "WindowHeight", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        public PostGeneratorSettings GetSettingsViewModel()
        {
            return viewModel;
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
            if(viewModel == null) { return; }
            controller.SavePostGeneratorSettings(viewModel);
        }
    }
}
