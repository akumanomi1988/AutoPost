using AutoMapper;
using AutoPost.AnimationCanvas.Classes;
using AutoPost.AnimationCanvas.Factories;
using AutoPost.Application.Interfaces;
using AutoPost.Application.Services;
using AutoPost.Domain.Interfaces;
using AutoPost.Domain.Models;
using AutoPost.Infraestructure.TikTok;
using AutoPost.Infraestructure.Youtube;
using AutoPost.Presentation.Desktop.Controllers;
using System.Runtime.CompilerServices;

namespace AutoPost.Presentation.Desktop
{
    public partial class MainForm : Form
    {
        private readonly OBSController _obsController;
        public bool Auto { get; set; } = false;
        private AnimationCanvas.Classes.AnimationCanvas? _AnimationCanvas;
        private readonly IVideoDownloadService _VideoDownloadService;
        private readonly IVideoManagementService _VideoSplitterServide;
        private readonly IPostPublisherFactory _postPublisherFactory;
        private readonly IMapper _Mapper;
        public MainForm(IPostPublisherFactory postPublisherFactory, IVideoDownloadService videoDownloadService, IVideoManagementService videoSplitter,IMapper mapper)
        {
            InitializeComponent();
            _VideoDownloadService = videoDownloadService;
            _VideoSplitterServide = videoSplitter;
            _postPublisherFactory = postPublisherFactory;
            _obsController = new();
            _obsController.SocketStatusChanged += _obsController_SocketStatusChanged;
            _obsController.VideoRecorderStatusChanged += _obsController_VideoRecorderStatusChanged;
            ucPostAnimatorSettings.BallNumberChangedInUCPost += UcPostAnimatorSettings_BallNumberChangedInUCPost;
            _Mapper = mapper;
            
        }

        private void _obsController_VideoRecorderStatusChanged(object? sender, VideoRecorder.Interfaces.Models.VideoRecorderStatus.Status e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => _obsController_VideoRecorderStatusChanged(sender, e)));
                return;
            }
            switch (e)
            {
                case VideoRecorder.Interfaces.Models.VideoRecorderStatus.Status.NotRunning:
                    lblRecorderStatus.BackColor = Color.Black;
                    lblRecorderStatus.ForeColor = Color.White;
                    break;
                case VideoRecorder.Interfaces.Models.VideoRecorderStatus.Status.Running:
                    lblRecorderStatus.BackColor = Color.DarkBlue;
                    lblRecorderStatus.ForeColor = Color.White;
                    break;
                case VideoRecorder.Interfaces.Models.VideoRecorderStatus.Status.Recording:
                    lblRecorderStatus.BackColor = Color.Blue;
                    lblRecorderStatus.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }
            try
            {
                lblRecorderStatus.Text = e.ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void _obsController_SocketStatusChanged(object? sender, VideoRecorder.Interfaces.Models.SocketStatus.Status e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => _obsController_SocketStatusChanged(sender, e)));
                return;
            }
            switch (e)
            {

                case VideoRecorder.Interfaces.Models.SocketStatus.Status.Disconnected:
                    lblSocketStatus.BackColor = Color.Red;
                    lblSocketStatus.ForeColor = Color.Black;
                    break;
                case VideoRecorder.Interfaces.Models.SocketStatus.Status.Connected:
                    lblSocketStatus.BackColor = Color.Green;
                    lblSocketStatus.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }
            try
            {
                lblSocketStatus.Text = e.ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async void AnimationCanvas_AnimationStarted(object? source, EventArgs args)
        {
            await AddBallsEvery(3, 20, 10);
        }

        private void UcPostAnimatorSettings_BallNumberChangedInUCPost(object? sender, EventArgs e)
        {
            if (_AnimationCanvas == null)
            {
                return;
            }

            ViewModel.PostAnimatorSettings settings = ucPostAnimatorSettings.GetSettingsViewModel();
            int step = settings.BallsNumber > _AnimationCanvas.CanvasElementCount() ? 1 : -1;
            while (_AnimationCanvas.CanvasElementCount() != settings.BallsNumber)
            {
                if (step > 0)
                {
                    _AnimationCanvas.AddElement();
                }
                else
                {
                    _AnimationCanvas.RemoveElement();
                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ViewModel.VideoRecorderSettings obs = ucVideoRecorderSettings1.GetVideoRecorderSettings();
            _obsController.Connect($"{obs.RecorderIP}:{obs.Port}", obs.Password);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ViewModel.PostAnimatorSettings settings = ucPostAnimatorSettings.GetSettingsViewModel();

            _AnimationCanvas = new(settings.WindowHeight,
                                    settings.WindowWidth,
                                    new SFML.Graphics.Color(settings.BackGroundColor.R, settings.BackGroundColor.G, settings.BackGroundColor.B),
                                    new CanvasElementFactory(DirectoryManager.SoundsPath));
            _AnimationCanvas.AnimationStarted += AnimationCanvas_AnimationStarted;
            _AnimationCanvas.StartAnimation(settings.BallsNumber, settings.Duration);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (_obsController.IsConnected)
            {
                _obsController.StartRecording();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (_AnimationCanvas == null) { return; }
            _AnimationCanvas.StopAnimation();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (_obsController.IsConnected && _obsController.IsRecording)
            {
                _obsController.StopRecording();
            }
        }

        private async void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (!_obsController.IsConnected)
            {
                return;
            }

            string LastFile = _obsController.GetLastSavedFile();
            if (LastFile == "") { return; }
            _ = await uploadVideoYT(LastFile);
        }
        private async Task<int> uploadVideoTT(string File)
        {
            if (_postPublisherFactory.CreatePublisher("tiktok") is not TikTokPublisher publisher)
            {
                return -1;
            }

            publisher.SessionID = ucPostUploaderSettings1.GetPostUploaderSettings().SessionID;
            publisher.OnProcessOutput += Publisher_OnProcessOutput;

            ViewModel.PostSettings Post = ucPostData1.GetPost();
            TikTokPostData tikTokPostData = new(
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

        private void Publisher_OnProcessOutput(string output)
        {
            try
            {
                txtlog.Text += output;
            }
            catch (Exception)
            {

                throw;
            }


        }

        private async Task<int> uploadVideoYT(string File)
        {
            if (_postPublisherFactory.CreatePublisher("Youtube") is not YouTubePublisher publisher)
            {
                return -1;
            }

            publisher.OnProcessOutput += Publisher_OnProcessOutput;
            ViewModel.PostSettings Post = ucPostData1.GetPost();
            YoutubePostData youtubePostData = new(
                title: Post.Title, // "Bolitas Rebotando - Relajación y Satisfacción",
                description: Post.Description, // "Disfruta de este video relajante y satisfactorio con bolitas rebotando al ritmo de una melodía tranquila.",
                tags: Post.Tags, //new List<string> { "relajante", "satisfying", "bolitas", "música" },
                contentPath: $@"{File}", // Asegúrate de que 'LastFile' sea la ruta correcta al archivo
                category: YTCategories.GetID(Post.Category),// "Entretenimiento", // Categoría específica de TikTok (si es aplicable)
                privacy: Post.Privacy,//"public", // Ajustar según sea necesario
                playlistId: "123",
                enableComments: true
            );
            return await publisher.UploadPostAsync(youtubePostData);
        }

        private async Task RunRecordingAndUploadingLoop(int Times = 24, int minutesWait = 90)
        {
            int cuentaVideos = 0;
            while (Auto && cuentaVideos < Times)
            {
                pbAuto.Value = cuentaVideos;
                cuentaVideos += 1;
                _obsController.StartRecording();
                ViewModel.PostAnimatorSettings settings = ucPostAnimatorSettings.GetSettingsViewModel();

                _AnimationCanvas = new(settings.WindowHeight,
                                        settings.WindowWidth,
                                        new SFML.Graphics.Color(settings.BackGroundColor.R, settings.BackGroundColor.G, settings.BackGroundColor.B),
                                        new CanvasElementFactory(DirectoryManager.SoundsPath));
                _AnimationCanvas.AnimationStarted += AnimationCanvas_AnimationStarted;
                _AnimationCanvas.StartAnimation(settings.BallsNumber, settings.Duration);

                _obsController.StopRecording();
                _AnimationCanvas.StopAnimation();
                await uploadLastVideo();
                await Task.Delay(minutesWait * 60 * 1000);
            }
            pbAuto.Value = Times;

        }

        private async Task uploadLastVideo()
        {
            string LastFile = _obsController.GetLastSavedFile();
            if (LastFile == "") { return; }
            _ = await uploadVideoTT(LastFile);
            _ = await uploadVideoYT(LastFile);
        }

        private async void toolStripButton8_Click(object sender, EventArgs e)
        {
            Auto = !Auto;
            if (Auto)
            {
                await RunRecordingAndUploadingLoop(24, 60);
            }
        }

        private async void toolStripButton7_Click(object sender, EventArgs e)
        {
            string LastFile = _obsController.GetLastSavedFile();
            if (LastFile == "") { return; }
            _ = await uploadVideoTT(LastFile);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveStates();
            CloseAll();
        }
        private void CloseAll()
        {

            if (_obsController.IsConnected && _obsController.IsRecording)
            {
                _obsController.StopRecording();
            }

            if (_AnimationCanvas == null) { return; }
            if (_AnimationCanvas.IsAnimating)
            {
                _AnimationCanvas.StopAnimation();
            }
        }
        private void saveStates()
        {
            ucPostAnimatorSettings.SaveState();
            ucPostData1.SaveState();
            ucPostUploaderSettings1.SaveState();
            ucVideoRecorderSettings1.SaveState();
        }
        private bool IsIncreasingNumber = true;  // Iniciar aumentando

        private async Task AddBallsEvery(int sec, int MaxBalls, int MinBalls)
        {
            if (_AnimationCanvas == null) { return; }

            while (_AnimationCanvas.IsAnimating)
            {
                await Task.Delay(sec * 1000);
                int numBall = _AnimationCanvas.CanvasElementCount();
                // Si estamos aumentando y aún no hemos alcanzado el máximo
                if (IsIncreasingNumber && numBall < MaxBalls)
                {
                    _AnimationCanvas.AddElement();
                }
                // Si estamos disminuyendo y aún no hemos alcanzado el mínimo
                else if (!IsIncreasingNumber && numBall > MinBalls)
                {
                    _AnimationCanvas.RemoveElement();
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

        private async void toolStripButton9_Click(object sender, EventArgs e)
        {
            var url = "https://www.youtube.com/watch?v=FNFz178Iaqk";
            var downloadPath = "C:\\Users\\dmozota\\Downloads";
            await _VideoDownloadService.DownloadVideoAsync(url, downloadPath);
        }

        private async void toolStripButton10_Click(object sender, EventArgs e)
        {
            var videoManager = new VideoManager(_VideoDownloadService, _VideoSplitterServide);
            var url = "https://www.youtube.com/watch?v=FNFz178Iaqk";
            //descarga el video en la carpeta que hemos seleccionado en el form
            var downloadedVideoPath = await videoManager.DownloadVideoFromURL(url, ucPostUploaderSettings1.GetPostUploaderSettings().DefaultVideoFolder);
            var splittedVideoPath = Path.Combine(ucPostUploaderSettings1.GetPostUploaderSettings().DefaultVideoFolder, videoManager.GetFileName(downloadedVideoPath));
            //$"{Path.Combine(outputPath, Path.GetFileNameWithoutExtension(inputFile.Filename))}_{contadorVideos:D3}.mp4";
            Directory.CreateDirectory(splittedVideoPath);
            await videoManager.SplitVideo(downloadedVideoPath, splittedVideoPath, 2);

            var croppedFolder = await videoManager.CropVideosFromFolder(splittedVideoPath);


            if (_postPublisherFactory.CreatePublisher("tiktok") is not TikTokPublisher publisher)
            {
                return ;
            }
            //var postSettings = ucPostData1.GetPost();
            //var postData = _Mapper.Map<PostData>(postSettings);
            ViewModel.PostSettings Post = ucPostData1.GetPost();
            Post.ContentPath = croppedFolder;
            TikTokPostData tikTokPostData = new(
                title: Post.Title, // "Bolitas Rebotando - Relajación y Satisfacción",
                description: Post.Description, // "Disfruta de este video relajante y satisfactorio con bolitas rebotando al ritmo de una melodía tranquila.",
                tags: Post.Tags, //new List<string> { "relajante", "satisfying", "bolitas", "música" },
                contentPath: $@"{Post.ContentPath}", // Asegúrate de que 'LastFile' sea la ruta correcta al archivo
                category: Post.Category,// "Entretenimiento", // Categoría específica de TikTok (si es aplicable)
                privacy: Post.Privacy,//"public", // Ajustar según sea necesario
                allowDuet: true // Permitir duetos, ajustar según la necesidad
            );

            publisher.SessionID = ucPostUploaderSettings1.GetPostUploaderSettings().SessionID;
           
            videoManager.Publish(tikTokPostData, publisher);

            //var VideoPath = "C:\\Users\\dmozota\\Downloads\\Así DEBERÍAS empezar BIEN EN CUALQUIER PROYECTO.mp4";
            //var OutputFolder = "C:\\Users\\dmozota\\Downloads\\Output";
            //Directory.CreateDirectory(OutputFolder);
            ////await _VideoSplitterServide.SplitVideo(VideoPath, OutputFolder, 3 * 60);
            //await _VideoSplitterServide.SplitVideoByNumberSplits(VideoPath, OutputFolder,3);
        }
    }
}
