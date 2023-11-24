using AutoPost.Application.Interfaces;
using AutoPost.Domain.Models;
using AutoPost.Presentation.Desktop.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPost.Presentation.Desktop
{
    public partial class MainForm : Form
    {
        private readonly IVideoUploadService _videoUploadService;
        private readonly IMetadataService _metadataService;
        //public Domain.Models.VideoMetadata currentYTVideoMetadata;
        private VideoMetadata? currentYTVideoMetadata
        {
            get
            {
                if (YTMetadataBS == null) { return null; }
                if (YTMetadataBS.Current == null) { return null; }
                return (VideoMetadata)YTMetadataBS.Current;
            }
        }

        public MainForm(IVideoUploadService videoUploadService, IMetadataService metadataService)
        {
            InitializeComponent();
            _videoUploadService = videoUploadService;
            _metadataService = metadataService;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (currentYTVideoMetadata == null) { return; }
            await _videoUploadService.UploadVideoAsync("Youtube", currentYTVideoMetadata);
            _metadataService.SaveMetadata(currentYTVideoMetadata);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            YTMetadataBS.DataSource = _metadataService.GetMetadata();
            if (currentYTVideoMetadata == null) { return; }
            tagBox1.DataBindings.Add(nameof(tagBox1.Text), string.Join(' ', currentYTVideoMetadata.Tags.Select(x => x.Text)), "", true, DataSourceUpdateMode.OnPropertyChanged);
            tagsBox1.DataBindings.Add(nameof(tagsBox1.TagList), string.Join(' ', currentYTVideoMetadata.Tags.Select(x => x.Text)), "", true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
