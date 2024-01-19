using AutoPost.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoPost.Presentation.Desktop.ViewModel
{
  
    [Serializable]
    public class PostAnimatorSettings:INotifyPropertyChanged
    {
        public PostAnimatorSettings()
        {

            Duration = 60; // Podrías usar 0 como valor predeterminado o cualquier otro valor que tenga sentido en tu contexto
            MusicPath = string.Empty;
            SoundsPath = string.Empty;
            BallsNumber = 10;
            WindowWidth = 720; // Valor predeterminado para el ancho de la ventana
            WindowHeight = 720; // Valor predeterminado para la altura de la ventana
            BackGroundColor = Color.White;
        }
        public PostAnimatorSettings( int duracionVideo, string musicPath, string soundsPath, int ballsNumber, int windowWidth, int windowHeight)
        {

            Duration = duracionVideo;
            MusicPath = musicPath;
            SoundsPath = soundsPath;
            BallsNumber = ballsNumber;
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;

        }

        public int Duration { get; set; }
        public string MusicPath { get; set; }
        public Color BackGroundColor { get; set; }
        public string SoundsPath { get; set; }
        [Range(1, 100, ErrorMessage = "El valor para BallsNumber debe estar entre 1 y 100.")]
        private int ballsNumber;
        public int BallsNumber { get { return ballsNumber; } set { if (ballsNumber != value) { ballsNumber = value; OnPropertyChanged(nameof(BallsNumber)); } } }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
