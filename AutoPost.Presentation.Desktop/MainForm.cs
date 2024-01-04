using AutoPost.AnimationCanvas.Factories;
using AutoPost.AnimationCanvas.Recorders;
using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;
using AutoPost.Infraestructure.Youtube;
using AutoPost.Infrastructure.Factories;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace AutoPost.Presentation.Desktop
{
    public partial class MainForm : Form
    {
        private AnimationCanvas.Classes.AnimationCanvas _AnimationCanvas;

        private void OnOBSStatusChanged(object? sender, OBS.OBSState e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnOBSStatusChanged(sender, e)));
                return;
            }
            switch (e)
            {
                case OBS.OBSState.NotRunning:
                    toolStripStatusLabel1.BackColor = Color.Black;
                    toolStripStatusLabel1.ForeColor = Color.White;
                    break;
                case OBS.OBSState.Running:
                    toolStripStatusLabel1.BackColor = Color.DarkBlue;
                    toolStripStatusLabel1.ForeColor = Color.White;
                    break;
                case OBS.OBSState.Disconnected:
                    toolStripStatusLabel1.BackColor = Color.Red;
                    toolStripStatusLabel1.ForeColor = Color.Black;
                    break;
                case OBS.OBSState.Connected:
                    toolStripStatusLabel1.BackColor = Color.Green;
                    toolStripStatusLabel1.ForeColor = Color.Black;
                    break;
                case OBS.OBSState.Recording:
                    toolStripStatusLabel1.BackColor = Color.Blue;
                    toolStripStatusLabel1.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }
            try
            {
                toolStripStatusLabel1.Text = e.ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }
        private readonly IPostPublisherFactory _postPublisherFactory;
        public MainForm(IPostPublisherFactory postPublisherFactory)
        {
            InitializeComponent();
            _AnimationCanvas = new(720, 1280, SFML.Graphics.Color.White, new VideoRecorder(), new AudioRecorder(), new CanvasElementFactory(AnimationCanvas.Classes.AnimationCanvas.SoundsPath));
            _AnimationCanvas.OBSStateChanged += OnOBSStatusChanged;
            _postPublisherFactory = postPublisherFactory;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _AnimationCanvas.ConnectRecorder();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _AnimationCanvas.StartAnimation();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _AnimationCanvas.StartRecording();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _AnimationCanvas.StopAnimation();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            _AnimationCanvas.StopRecording();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
            
            var LastFile = _AnimationCanvas.GetLastFileGenerated();
            if (LastFile == "") { return; }
                var publisher = _postPublisherFactory.CreatePublisher("Youtube");
            Post youtubeVideoPost = new Post
            {
                Id = Guid.NewGuid(),
                Title = "Mi Viaje Increíble a las Montañas",
                ContentPath =  $@"{LastFile}" ,
                Description = "Un video detallado de mi reciente viaje a las montañas, incluyendo increíbles paisajes y consejos de viaje.",
                Category = "22",
                Privacy = "public",
                Created = DateTime.Now,
                //PublishedNetworks = new List<SocialNetwork> { /* Agrega aquí las redes sociales donde ya se publicó */ },
                //PendingNetworks = new List<SocialNetwork> { SocialNetwork.Youtube }, // Suponiendo que SocialNetwork es una enumeración
                Tags = new string[] { "viaje", "montañas", "naturaleza", "turismo" }
            };
            publisher.UploadVideoAsync(youtubeVideoPost);
        }

    }
}
