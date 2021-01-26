using Dot.Challenge.Commands;
using Dot.Challenge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dot.Challenge.ViewModels
{
    public class LCRGameViewModel:BaseViewModel
    {
        /// <summary>
        /// number of players of game, remember constraint minumun 3 players
        /// </summary>
        private int playersNumber;
        /// <summary>
        /// number of games for all players previous selected
        /// </summary>
        private int gamesNumber;

        /// <summary>
        /// minimum value of players
        /// </summary>
        internal const int MIN_NUMBER_OF_PLAYERS = 3;

        /// <summary>
        /// flag used to validate inputs (games and players)
        /// </summary>
        internal bool isValidGamesNumber = true;
        internal bool isValidPlayersNumber = true;

        public bool IsValidGamesNumber
        {
            set { 
                isValidGamesNumber = value;
                GamesNumberError = (isValidGamesNumber) ? Visibility.Hidden : Visibility.Visible;                
            }
        }

        public bool IsValidPlayersNumber
        {
            set
            {
                isValidPlayersNumber = value;
                PlayersNumberError = (isValidPlayersNumber) ? Visibility.Hidden : Visibility.Visible;
                //OnPropertyChanged("gamesNumberError");
            }
        }

        /// <summary>
        /// list of games played in each simulation
        /// </summary>
        internal List<LCRGame> GamesPlayed = new List<LCRGame>();

        /// <summary>
        /// Minimum turns played per simulation
        /// </summary>
        private int mininumTurnsNumberOfSimulation = 0;
        /// <summary>
        /// Maximum turns played per simulation
        /// </summary>
        private int maximumTurnsNumberOfSimulation = 0;
        /// <summary>
        /// Average turns played per simulation
        /// </summary>
        private double averageTurnsNumberOfSimulation = 0d;

        public int MininumTurnsNumberOfSimulation
        {
            get { return mininumTurnsNumberOfSimulation; }
            set { 
                mininumTurnsNumberOfSimulation = value;
                OnPropertyChanged();
            }
        }

        public int MaximumTurnsNumberOfSimulation
        {
            get { return maximumTurnsNumberOfSimulation; }
            set
            {
                maximumTurnsNumberOfSimulation = value;
                OnPropertyChanged();
            }
        }

        public double AverageTurnsNumberOfSimulation
        {
            get { return averageTurnsNumberOfSimulation; }
            set
            {
                averageTurnsNumberOfSimulation = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// method to calculate results after all turns finished
        /// </summary>
        internal void CalculateResultsOfGame()
        {
            MininumTurnsNumberOfSimulation = GamesPlayed.Min(g => g.Turns);
            MaximumTurnsNumberOfSimulation = GamesPlayed.Max(g => g.Turns);
            AverageTurnsNumberOfSimulation = GamesPlayed.Average(g => g.Turns);
        }

        /// <summary>
        /// number of players
        /// </summary>
        public int PlayersNumber
        {
            get { return playersNumber; }
            set
            {
                IsValidPlayersNumber = value >= MIN_NUMBER_OF_PLAYERS;
                playersNumber = value;
                OnPropertyChanged(); 
            } 
        }

        /// <summary>
        /// number of games
        /// </summary>
        public int GamesNumber
        {
            get { return gamesNumber; }
            set
            {
                IsValidGamesNumber = value > 0;
                gamesNumber = value;
                OnPropertyChanged();
            }
        }

        private ICommand gameCommand;

        /// <summary>
        /// Execute the simulation
        /// </summary>
        public ICommand GameCommand => gameCommand ??= new LCGGameCommand();

        /// <summary>
        /// property to show or not the error message for number of players
        /// </summary>
        private Visibility playersNumberError;
        /// <summary>
        /// properto to show or not the error message for games number
        /// </summary>
        private Visibility gamesNumberError;

        public Visibility PlayersNumberError
        {
            get { return playersNumberError; }
            set { 
                playersNumberError = value;
                OnPropertyChanged();
            }
        }

        public Visibility GamesNumberError
        {
            get { return gamesNumberError; }
            set
            {
                gamesNumberError = value;
                OnPropertyChanged();
            }
        }

        public LCRGameViewModel()
        {
            PlayersNumber = MIN_NUMBER_OF_PLAYERS;
            GamesNumber = 1;
        }

        public void InitializeGame()
        {
            GamesPlayed = new List<LCRGame>();
            MininumTurnsNumberOfSimulation = 0;
            MaximumTurnsNumberOfSimulation = 0;
            AverageTurnsNumberOfSimulation = 0d;
        }
    }
}
