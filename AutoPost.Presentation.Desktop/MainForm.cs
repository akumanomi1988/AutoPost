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
        private readonly IPublishService _PublishService;
        private readonly IPostService _PostService;
        //public Domain.Models.VideoPost currentYTVideoPost;
        private Post? currentPost
        {
            get
            {
                if (postBindingSource == null) { return null; }
                if (postBindingSource.Current == null) { return null; }
                return (Post)postBindingSource.Current;
            }
        }

        public MainForm(IPublishService publishService, IPostService postService)
        {
            InitializeComponent();
            _PublishService = publishService;
            _PostService = postService;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (currentPost == null) { return; }
                currentPost.PendingNetworks.Add(new SocialNetwork() { Id = 0, Name = "youtube" });
            await _PublishService.PublishAsync(currentPost);
            _PostService.SavePost(currentPost);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            postBindingSource.DataSource = _PostService.GetPost();
            if (currentPost == null) { return; }
            tagsBox1.DataBindings.Add(nameof(tagsBox1.TagList), string.Join(' ', currentPost.Tags), "", true, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void postBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

    }
}
