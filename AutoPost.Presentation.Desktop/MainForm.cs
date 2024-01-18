using AutoPost.AnimationCanvas.Classes;
using AutoPost.AnimationCanvas.Factories;
using AutoPost.AnimationCanvas.Recorders;
using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;
using AutoPost.Infraestructure.TikTok;
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
        private OBSController _obsController;
        
        public bool Auto { get; set; } = false;
        private AnimationCanvas.Classes.AnimationCanvas _AnimationCanvas;
        private void OnOBSStatusChanged(object? sender, OBSController.OBSState e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnOBSStatusChanged(sender, e)));
                return;
            }
            switch (e)
            {
                case OBSController.OBSState.NotRunning:
                    toolStripStatusLabel1.BackColor = Color.Black;
                    toolStripStatusLabel1.ForeColor = Color.White;
                    break;
                case OBSController.OBSState.Running:
                    toolStripStatusLabel1.BackColor = Color.DarkBlue;
                    toolStripStatusLabel1.ForeColor = Color.White;
                    break;
                case OBSController.OBSState.Disconnected:
                    toolStripStatusLabel1.BackColor = Color.Red;
                    toolStripStatusLabel1.ForeColor = Color.Black;
                    break;
                case OBSController.OBSState.Connected:
                    toolStripStatusLabel1.BackColor = Color.Green;
                    toolStripStatusLabel1.ForeColor = Color.Black;
                    break;
                case OBSController.OBSState.Recording:
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
            _postPublisherFactory = postPublisherFactory;
            _obsController = new();
            _obsController.OBSStatusChanged += OnOBSStatusChanged;
            _AnimationCanvas = new(720, 720, SFML.Graphics.Color.White, new VideoRecorder(), new AudioRecorder(), new CanvasElementFactory(AnimationCanvas.Classes.AnimationCanvas.SoundsPath));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _obsController.Connect("http://localhost:4455","");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _AnimationCanvas = new(720, 720, SFML.Graphics.Color.White, new VideoRecorder(), new AudioRecorder(), new CanvasElementFactory(AnimationCanvas.Classes.AnimationCanvas.SoundsPath));
            _AnimationCanvas.StartAnimation();
        }

        private  void toolStripButton3_Click(object sender, EventArgs e)
        {
            _obsController.StartRecording();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _AnimationCanvas.StopAnimation();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            _obsController.StopRecording();
        }

        private async void toolStripButton6_Click(object sender, EventArgs e)
        {
            var LastFile = _obsController.GetLastSavedFile();
            if (LastFile == "") { return; }
            await uploadVideoYT(LastFile);
        }
        private async Task<int> uploadVideoTT(string File)
        {
            var publisher = _postPublisherFactory.CreatePublisher("tiktok");
            var tikTokPostData = new TikTokPostData(
                title: "Bolitas Rebotando - Relajación y Satisfacción",
                description: "Disfruta de este video relajante y satisfactorio con bolitas rebotando al ritmo de una melodía tranquila.",
                tags: new List<string> { "relajante", "satisfying", "bolitas", "música" },
                contentPath: $@"{File}", // Asegúrate de que 'LastFile' sea la ruta correcta al archivo
                category: "Entretenimiento", // Categoría específica de TikTok (si es aplicable)
                privacy: "public", // Ajustar según sea necesario
                allowDuet: true // Permitir duetos, ajustar según la necesidad
            );

            return await publisher.UploadPostAsync(tikTokPostData);
        }
        private async Task<int> uploadVideoYT(string File)
        {

            //var LastFile = _AnimationCanvas.GetLastFileGenerated();
            //if (LastFile == "") { return -1; }
            var publisher = _postPublisherFactory.CreatePublisher("Youtube");
            var youtubePostData = new YoutubePostData(
                title: "Bolitas Rebotando - Relajación y Satisfacción",
                description: "Disfruta de este video relajante y satisfactorio con bolitas rebotando al ritmo de una melodía tranquila.",
                tags: new List<string> { "relajante", "satisfying", "bolitas", "música" },
                contentPath: $@"{File}",
                category: "22",
                privacy: "public",
                playlistId: "123",
                enableComments: true
            );
            return await publisher.UploadPostAsync(youtubePostData);
        }
        private int cuentaVideos = 0;
        private async Task RunRecordingAndUploadingLoop()
        {

            while (Auto && cuentaVideos < 1)
            {
                cuentaVideos += 1;
                _obsController.StartRecording();
                //_AnimationCanvas.StartAnimation(10, _AnimationCanvas.MusicDuration());
                _AnimationCanvas.StartAnimation(10, 120);
                // Detener la grabación
                _obsController.StopRecording();
                _AnimationCanvas.StopAnimation();
                // Esperar 10 segundos
                await Task.Delay(TimeSpan.FromSeconds(5));

                // Subir el video
                await uploadLastVideo();

                // Esperar 10 segundos antes de empezar de nuevo
                await Task.Delay(TimeSpan.FromSeconds(5));

            }
        }

        private async Task uploadLastVideo()
        {
            var LastFile = _obsController.GetLastSavedFile();
            if (LastFile == "") { return; }
            await uploadVideoTT(LastFile);
            await uploadVideoYT(LastFile);
        }

        private async void toolStripButton8_Click(object sender, EventArgs e)
        {
            Auto = !Auto;
            if (Auto) await RunRecordingAndUploadingLoop();
        }

        private async void toolStripButton7_Click(object sender, EventArgs e)
        {
            var LastFile = _obsController.GetLastSavedFile();
            if (LastFile == "") { return; }
            await uploadVideoTT(LastFile);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucSettings1.SaveState();
        }
    }
}
