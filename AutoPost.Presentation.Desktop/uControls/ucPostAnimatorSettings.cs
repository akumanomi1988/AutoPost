using AutoPost.AnimationCanvas.Elements;
using AutoPost.Presentation.Desktop.Controllers;
using AutoPost.Presentation.Desktop.Models;
using AutoPost.Presentation.Desktop.ViewModel;
using System.ComponentModel;
using System.Linq;
using TikTokLiveSharp.Client;
using TikTokLiveSharp.Client.Config;
using TikTokLiveSharp.Errors.Connections;
using TikTokLiveSharp.Events;

namespace AutoPost.Presentation.Desktop.uControls
{
    public partial class ucPostAnimatorSettings : UserControl
    {
       

        private List<UserInfo> users = new List<UserInfo>();
        private TikTokLiveClient? client;
        private CancellationTokenSource? cancellationTokenSource;

        public event EventHandler? BallNumberChangedInUCPost;
        private PostAnimatorSettings _ViewModel { get; set; }
        private PostAnimatorController _Controller { get; set; }
        private int _ballsNumber;
        private UserInfoController _userInfoController;
        public int BallsNumber
        {
            get { return _ballsNumber; }
            set
            {
                if (_ballsNumber != value)
                {
                    _ballsNumber = value;
                    OnBallsNumberChanged();
                }
            }
        }
        public ucPostAnimatorSettings()
        {

            InitializeComponent();
            _Controller = new();
            _ViewModel = _Controller.Load() ?? new PostAnimatorSettings();
            _ = numDuracionVideo.DataBindings.Add("Value", _ViewModel, nameof(_ViewModel.Duration), false, DataSourceUpdateMode.OnPropertyChanged);
            _ = txtMusicPath.DataBindings.Add("Text", _ViewModel, "MusicPath", false, DataSourceUpdateMode.OnPropertyChanged);
            _ = txtSoundsPath.DataBindings.Add("Text", _ViewModel, "SoundsPath", false, DataSourceUpdateMode.OnPropertyChanged);
            _ = numBallsNumber.DataBindings.Add("Value", _ViewModel, "BallsNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            _ = numWindowWidth.DataBindings.Add("Value", _ViewModel, nameof(_ViewModel.WindowWidth), false, DataSourceUpdateMode.OnPropertyChanged);
            _ = numWindowHeight.DataBindings.Add("Value", _ViewModel, nameof(_ViewModel.WindowHeight), false, DataSourceUpdateMode.OnPropertyChanged);
            _ = txtHostId.DataBindings.Add("Text", _ViewModel, "HostId");
            _ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            _ballsNumber = (int)numBallsNumber.Value;
            _userInfoController = new UserInfoController("user_info_database.db");
            button1.BackColor = Color.Red;
        }
        #region TIKTOK_EVENTS


        private void OnBallsNumberChanged()
        {
            if (numBallsNumber.InvokeRequired)
            {
                numBallsNumber.Invoke(new Action(() =>
                {
                    numBallsNumber.Value = _ballsNumber;
                }));
            }
            else
            {
                numBallsNumber.Value = _ballsNumber;
            }
        }
        private void Client_OnConnected(TikTokLiveClient sender, bool e)
        {
            //SetConsoleColor(ConsoleColor.White);
            //Console.WriteLine($"Connected to Room! [Connected:{e}]");

            SafeInvoke(() =>
            {
                button1.BackColor = Color.Green;
            });
        }

        private void Client_OnDisconnected(TikTokLiveClient sender, bool e)
        {
            SafeInvoke(() =>
            {
                button1.BackColor = Color.Red;
            });
        }


        private void Client_OnViewerData(TikTokLiveClient sender, RoomUpdate e)
        {
            SafeInvoke(() =>
            {
                // Actualizar el estado activo de los usuarios
                int activeCount = users.Count(u => u.IsActive);
                if (activeCount > e.NumberOfViewers)
                {
                    // Marcar usuarios como inactivos si el número de espectadores disminuye
                    int excessUsers = activeCount - (int) e.NumberOfViewers;
                    foreach (var user in users.Where(u => u.IsActive).Take(excessUsers))
                    {
                        user.IsActive = false;
                    }
                }
                else
                {
                    // Si el número de viewers aumenta, simplemente actualiza la cuenta
                    BallsNumber = (int) e.NumberOfViewers;
                }

                // Actualizar el número de bolas al número de espectadores
                BallsNumber = users.Count(u => u.IsActive);
            });
        }

        private void Client_OnLiveEnded(TikTokLiveClient sender, ControlMessage e)
        {
            SafeInvoke(() =>
            {
                // Limpiar la lista de usuarios cuando termina la transmisión
                users.Clear();
                BallsNumber = 0;
                Console.WriteLine("Host ended Stream!");
            });
        }

        private void Client_OnJoin(TikTokLiveClient sender, Join e)
        {
            SafeInvoke(() =>
            {
                var user = users.FirstOrDefault(u => u.UserId == e.User.UniqueId);
                if (user == null)
                {
                    // Si el usuario no existe, crear un nuevo UserInfo
                    user = new UserInfo
                    {
                        UserId = e.User.UniqueId,
                        Likes = 0,
                        IsSubscribed = e.User.IsFollowing,
                        IsActive = true
                    };
                    users.Add(user);
                }
                else
                {
                    // Si el usuario ya existe, marcarlo como activo
                    user.IsActive = true;
                }

                // Guardar o actualizar en la base de datos
                _userInfoController.SaveUserInfo(user);

                // Asegurarse de que BallsNumber sea igual al número de espectadores activos
                BallsNumber = users.Count(u => u.IsActive);
            });
        }



        private void Client_OnComment(TikTokLiveClient sender, Chat e)
        {
            SafeInvoke(() =>
            {
                var user = users.FirstOrDefault(u => u.UserId == e.Sender.UniqueId);
                if (user != null)
                {
                    user.Comments += 1;
                    user.IsActive = true;

                    // Guardar o actualizar en la base de datos
                    _userInfoController.SaveUserInfo(user);
                }
            });
        }


        private void Client_OnFollow(TikTokLiveClient sender, Follow e)
        {
            SafeInvoke(() =>
            {
                var user = users.FirstOrDefault(u => u.UserId == e.User.UniqueId);
                if (user != null)
                {
                    user.Follows += 1;
                    user.IsActive = true;

                    // Guardar o actualizar en la base de datos
                    _userInfoController.SaveUserInfo(user);
                }
            });
        }


        private void Client_OnShare(TikTokLiveClient sender, Share e)
        {
            SafeInvoke(() =>
            {
                var user = users.FirstOrDefault(u => u.UserId == e.User.UniqueId);
                if (user != null)
                {
                    user.Shares += 1;
                    user.IsActive = true;

                    // Guardar o actualizar en la base de datos
                    _userInfoController.SaveUserInfo(user);
                }
            });
        }

        private void Client_OnSubscribe(TikTokLiveClient sender, Subscribe e)
        {
            SafeInvoke(() =>
            {
                var user = users.FirstOrDefault(u => u.UserId == e.User.UniqueId);
                if (user != null)
                {
                    user.IsSubscribed = true;
                    user.IsActive = true;

                    // Guardar o actualizar en la base de datos
                    _userInfoController.SaveUserInfo(user);
                }
            });
        }

        private void Client_OnLike(TikTokLiveClient sender, Like e)
        {
            SafeInvoke(() =>
            {
                var user = users.FirstOrDefault(u => u.UserId == e.Sender.UniqueId);
                if (user != null)
                {
                    user.Likes += e.Count;
                    user.IsActive = true;

                    // Guardar o actualizar en la base de datos
                    _userInfoController.SaveUserInfo(user);
                }
            });
        }
        private void Client_OnGiftMessage(TikTokLiveClient sender, GiftMessage e)
        {
            SafeInvoke(() =>
            {
                var user = users.FirstOrDefault(u => u.UserId == e.User.UniqueId);
                if (user != null)
                {
                    user.Gifts +=(int) e.Amount;
                    user.IsActive = true;

                    // Guardar o actualizar en la base de datos
                    _userInfoController.SaveUserInfo(user);
                }
            });
        }

        private void Client_OnEmote(TikTokLiveClient sender, EmoteChat e)
        {
            SafeInvoke(() =>
            {
                var user = users.FirstOrDefault(u => u.UserId == e.User.UniqueId);
                if (user != null)
                {
                    user.Emotes += 1;
                    user.IsActive = true;

                    // Guardar o actualizar en la base de datos
                    _userInfoController.SaveUserInfo(user);
                }
            });
        }

        private void SetConsoleColor(ConsoleColor color)
        {
            if (Console.ForegroundColor != color)
                Console.ForegroundColor = color;
        }
        #endregion
        private void SafeInvoke(Action action)
        {
            if (InvokeRequired)
            {
                BeginInvoke(action);
            }
            else
            {
                action();
            }
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "BallsNumber")
            {
                HandleBallNumberChanged();
            }
        }
        private void HandleBallNumberChanged()
        {
            BallNumberChangedInUCPost?.Invoke(this, EventArgs.Empty);
        }
        public PostAnimatorSettings GetSettingsViewModel()
        {
            return _ViewModel;
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
            if (_ViewModel == null) { return; }
            _Controller.Save(_ViewModel);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string hostId = txtHostId.Text;
            if (string.IsNullOrEmpty(hostId)) return;

            // Si el cliente ya está conectado
            if (client != null)
            {
                if (client.Connected)
                {
                    // Cancelar la tarea en ejecución
                    cancellationTokenSource?.Cancel();
                    // Esperar a que la tarea se cancele (opcional)
                     Task.Delay(500).Wait(); // Ajusta el tiempo según sea necesario
                }

                // Desuscribir de los eventos
                client.OnConnected -= Client_OnConnected;
                client.OnDisconnected -= Client_OnDisconnected;
                client.OnRoomUpdate -= Client_OnViewerData;
                client.OnLiveEnded -= Client_OnLiveEnded;
                client.OnJoin -= Client_OnJoin;
                client.OnChatMessage -= Client_OnComment;
                client.OnFollow -= Client_OnFollow;
                client.OnShare -= Client_OnShare;
                client.OnSubscribe -= Client_OnSubscribe;
                client.OnLike -= Client_OnLike;
                client.OnGiftMessage -= Client_OnGiftMessage;
                client.OnEmoteChat -= Client_OnEmote;

                // Limpiar recursos si es necesario
                client = null;
                cancellationTokenSource?.Dispose();
            }

            // Crear un nuevo CancellationTokenSource
            cancellationTokenSource = new CancellationTokenSource();

            // Inicializar el cliente
            client = new TikTokLiveClient(hostId, "", new ClientSettings() { EnableCompression = false });

            button1.BackColor = Color.Blue;

            // Suscribir eventos
            client.OnConnected += Client_OnConnected;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnRoomUpdate += Client_OnViewerData;
            client.OnLiveEnded += Client_OnLiveEnded;
            client.OnJoin += Client_OnJoin;
            client.OnChatMessage += Client_OnComment;
            client.OnFollow += Client_OnFollow;
            client.OnShare += Client_OnShare;
            client.OnSubscribe += Client_OnSubscribe;
            client.OnLike += Client_OnLike;
            client.OnGiftMessage += Client_OnGiftMessage;
            client.OnEmoteChat += Client_OnEmote;
            try
            {
                // Iniciar la tarea Run con el CancellationToken
                Task.Run(() => client.Run(cancellationTokenSource.Token, null, true));
            }catch(LiveNotFoundException ex)
            {
                MessageBox.Show($"El usuarion no está en directo --> {ex}");
            }catch(Exception ex)
            {
                MessageBox.Show($"Error --> {ex}");
            }
           
        }

    }
}
