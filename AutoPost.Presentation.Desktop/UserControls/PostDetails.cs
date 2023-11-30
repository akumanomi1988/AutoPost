using AutoPost.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPost.Presentation.Desktop.UserControls
{
    public partial class PostDetails : UserControl
    {
        private Post? post;

        public Post? GetPost()
        {
            return post;
        }

        public void SetPost(Post value)
        {
            post = value;
        }
        public PostDetails()
        {
            InitializeComponent();
        }

    }
}
