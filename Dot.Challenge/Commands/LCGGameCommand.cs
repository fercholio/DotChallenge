using Dot.Challenge.Model;
using Dot.Challenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dot.Challenge.Commands
{
    public class LCGGameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var lcrGame = (LCRGameViewModel)parameter;

            if ((!lcrGame.isValidGamesNumber && lcrGame.isValidPlayersNumber))
                return; //game paramters not valid

            //initialize elements in each call            
            lcrGame.InitializeGame();

            var players = new List<Player>();
            for(int i = 0; i < lcrGame.PlayersNumber; i++)
            {
                var player = new Player();
                player.PlayerName = "Player " + i;
                players.Add(player);
            }
                        
            for(int g = 0; g < lcrGame.GamesNumber; g++)
            {
                var game = new LCRGame(players);

                game.Start();
                lcrGame.GamesPlayed.Add(game);

                //each player will start with MAX ROLL chips.
                foreach(var player in players)
                {
                    player.Chips = LCRGame.MAX_ROLL;
                }
            }
            //After all games, we will calculate the results.

            lcrGame.CalculateResultsOfGame();
            
        }
    }
}
