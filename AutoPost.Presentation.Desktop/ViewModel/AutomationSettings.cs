using System.ComponentModel;
namespace AutoPost.Presentation.Desktop.ViewModel
{
    [Serializable]
    public class AutomationSettings : INotifyPropertyChanged
    {
        public int NumberOfRepetitions { get; set; }
        public bool AllowAutomaticBallAddition { get; set; }
        public int BallAdditionIntervalInSeconds { get; set; }
        public int MinimumNumberOfBalls { get; set; }
        public int MaximumNumberOfBalls { get; set; }
        public int TimeBetweenRepetitionsInMinutes { get; set; }

        // Constructor sin parámetros que inicializa valores por defecto
        public AutomationSettings()
        {
            NumberOfRepetitions = 1; // Default to 1 repetition
            AllowAutomaticBallAddition = false; // Default to not allowing automatic ball addition
            BallAdditionIntervalInSeconds = 5; // Default interval of 5 seconds
            MinimumNumberOfBalls = 1; // Default minimum number of balls to 1
            MaximumNumberOfBalls = 10; // Default maximum number of balls to 10
        }

        public AutomationSettings(int numberOfRepetitions, bool allowAutomaticBallAddition, int ballAdditionIntervalInSeconds, int minimumNumberOfBalls, int maximumNumberOfBalls)
        {
            NumberOfRepetitions = numberOfRepetitions;
            AllowAutomaticBallAddition = allowAutomaticBallAddition;
            BallAdditionIntervalInSeconds = ballAdditionIntervalInSeconds;
            MinimumNumberOfBalls = minimumNumberOfBalls;
            MaximumNumberOfBalls = maximumNumberOfBalls;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
