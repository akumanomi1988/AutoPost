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
    public partial class ucPostUploaderSettings : UserControl
    {
        private PostUploaderSettingsController _Controller;
        private PostUploaderSettings _ViewModel;
        public ucPostUploaderSettings()
        {
            InitializeComponent();
            _Controller = new();
            _ViewModel = _Controller.Load() ?? new PostUploaderSettings();
            txtDefaultVideoFolder.DataBindings.Add("Text", _ViewModel, nameof(_ViewModel.DefaultVideoFolder), false, DataSourceUpdateMode.OnPropertyChanged);
            txtSessionID.DataBindings.Add("Text", _ViewModel, nameof(_ViewModel.SessionID), false, DataSourceUpdateMode.OnPropertyChanged);

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
