using AutoPost.AnimationCanvas.Classes;
using AutoPost.AnimationCanvas.Factories;
using AutoPost.AnimationCanvas.Recorders;
using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;
using AutoPost.Infraestructure.TikTok;
using AutoPost.Infraestructure.Youtube;
using AutoPost.Infrastructure.Factories;
using AutoPost.Presentation.Desktop.Controllers;
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
        private AnimationCanvas.Classes.AnimationCanvas? _AnimationCanvas;
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
            //_AnimationCanvas = new(720, 720, SFML.Graphics.Color.White, new CanvasElementFactory(AnimationCanvas.Classes.AnimationCanvas.SoundsPath));
            ucPostAnimatorSettings.BallNumberChangedInUCPost += UcPostAnimatorSettings_BallNumberChangedInUCPost;

        }

        private async void _AnimationCanvas_AnimationStarted(object source, EventArgs args)
        {
           await AddBallsEvery(3, 20, 10);
        }

        private void UcPostAnimatorSettings_BallNumberChangedInUCPost(object? sender, EventArgs e)
        {
            var settings = ucPostAnimatorSettings.GetSettingsViewModel();

            // Determinar si necesitamos agregar o quitar elementos.
            int step = settings.BallsNumber > _AnimationCanvas.CanvasElementCount() ? 1 : -1;

            while (_AnimationCanvas.CanvasElementCount() != settings.BallsNumber)
            {
                if (step > 0)
                {
                    _AnimationCanvas.AddBall(); 
                }
                else
                {
                    _AnimationCanvas.RemoveBall(); 
                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var obs = ucVideoRecorderSettings1.GetVideoRecorderSettings();
            _obsController.Connect($"{obs.RecorderIP}:{obs.Port}",obs.Password);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var settings = ucPostAnimatorSettings.GetSettingsViewModel();

            _AnimationCanvas = new( settings.WindowHeight,
                                    settings.WindowWidth, 
                                    new SFML.Graphics.Color( settings.BackGroundColor.R, settings.BackGroundColor.G, settings.BackGroundColor.B),
                                    new CanvasElementFactory(AnimationCanvas.Classes.AnimationCanvas.SoundsPath));
            _AnimationCanvas.AnimationStarted += _AnimationCanvas_AnimationStarted;
            _AnimationCanvas.StartAnimation(settings.BallsNumber,settings.Duration);

        }

        private  void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(_obsController.IsConnected) 
                _obsController.StartRecording();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (_AnimationCanvas == null) { return; }
            _AnimationCanvas.StopAnimation();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (_obsController.IsConnected && _obsController.IsRecording)
                _obsController.StopRecording();
        }

        private async void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (!_obsController.IsConnected) return;
                var LastFile = _obsController.GetLastSavedFile();
            if (LastFile == "") { return; }
            await uploadVideoYT(LastFile);
        }
        private async Task<int> uploadVideoTT(string File)
        {
            var publisher = _postPublisherFactory.CreatePublisher("tiktok");
            var Post = ucPostData1.GetPost();
            var tikTokPostData = new TikTokPostData(
                title: Post.Title, // "Bolitas Rebotando - Relajación y Satisfacción",
                description: Post.Description, // "Disfruta de este video relajante y satisfactorio con bolitas rebotando al ritmo de una melodía tranquila.",
                tags: Post.Tags, //new List<string> { "relajante", "satisfying", "bolitas", "música" },
                contentPath: $@"{File}", // Asegúrate de que 'LastFile' sea la ruta correcta al archivo
                category: Post.Category,// "Entretenimiento", // Categoría específica de TikTok (si es aplicable)
                privacy: Post.Privacy,//"public", // Ajustar según sea necesario
                allowDuet: true // Permitir duetos, ajustar según la necesidad
            );

            return await publisher.UploadPostAsync(tikTokPostData);
        }
        private async Task<int> uploadVideoYT(string File)
        {

            //var LastFile = _AnimationCanvas.GetLastFileGenerated();
            //if (LastFile == "") { return -1; }
            var publisher = _postPublisherFactory.CreatePublisher("Youtube");
            var Post = ucPostData1.GetPost();
            var youtubePostData = new YoutubePostData(
                title: Post.Title, // "Bolitas Rebotando - Relajación y Satisfacción",
                description: Post.Description, // "Disfruta de este video relajante y satisfactorio con bolitas rebotando al ritmo de una melodía tranquila.",
                tags: Post.Tags, //new List<string> { "relajante", "satisfying", "bolitas", "música" },
                contentPath: $@"{File}", // Asegúrate de que 'LastFile' sea la ruta correcta al archivo
                category: YTCategories.GetID( Post.Category),// "Entretenimiento", // Categoría específica de TikTok (si es aplicable)
                privacy: Post.Privacy,//"public", // Ajustar según sea necesario
                playlistId: "123",
                enableComments: true
            );
            return await publisher.UploadPostAsync(youtubePostData);
        }
        private int cuentaVideos = 0;
        private async Task RunRecordingAndUploadingLoop()
        {
            if (_AnimationCanvas == null) { return; }
            while (Auto && cuentaVideos < 10)
            {
                cuentaVideos += 1;
                _obsController.StartRecording();
                var settings = ucPostAnimatorSettings.GetSettingsViewModel();

                _AnimationCanvas = new(settings.WindowHeight,
                                        settings.WindowWidth,
                                        new SFML.Graphics.Color(settings.BackGroundColor.R, settings.BackGroundColor.G, settings.BackGroundColor.B),
                                        new CanvasElementFactory(AnimationCanvas.Classes.AnimationCanvas.SoundsPath));
                _AnimationCanvas.AnimationStarted += _AnimationCanvas_AnimationStarted;
                _AnimationCanvas.StartAnimation(settings.BallsNumber, settings.Duration);

                _obsController.StopRecording();
                _AnimationCanvas.StopAnimation();
                await uploadLastVideo();
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
            ucPostAnimatorSettings.SaveState();
            ucPostData1.SaveState();
            ucPostUploaderSettings1.SaveState();
            ucVideoRecorderSettings1.SaveState();
            if (_obsController.IsConnected && _obsController.IsRecording) _obsController.StopRecording();
            if (_AnimationCanvas == null) { return; }
            if (_AnimationCanvas.IsAnimating) _AnimationCanvas.StopAnimation();
        }
        private bool IsIncreasingNumber = true;  // Iniciar aumentando

        private async Task AddBallsEvery(int sec, int MaxBalls, int MinBalls)
        {
            if(_AnimationCanvas == null) { return; }

            while (_AnimationCanvas.IsAnimating)
            {
                await Task.Delay(sec * 1000);
                var numBall = _AnimationCanvas.CanvasElementCount();
                // Si estamos aumentando y aún no hemos alcanzado el máximo
                if (IsIncreasingNumber && numBall < MaxBalls)
                {
                    _AnimationCanvas.AddBall();
                }
                // Si estamos disminuyendo y aún no hemos alcanzado el mínimo
                else if (!IsIncreasingNumber && numBall > MinBalls)
                {
                    _AnimationCanvas.RemoveBall();
                }

                // Verificar si necesitamos cambiar de aumentar a disminuir o viceversa
                if (numBall >= MaxBalls)
                {
                    IsIncreasingNumber = false;  // Cambiar a disminuir
                }
                else if (numBall <= MinBalls)
                {
                    IsIncreasingNumber = true;  // Cambiar a aumentar
                }
            }
        }

    }
}
