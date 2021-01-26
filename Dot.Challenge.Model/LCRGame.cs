using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dot.Challenge.Model.Enums;

namespace Dot.Challenge.Model
{
    /// <summary>
    /// LCR Game to be played
    /// </summary>
    public class LCRGame
    {
        /// <summary>
        /// List of players in the game
        /// </summary>
        public List<Player> Players = new List<Player>();
        /// <summary>
        /// MAX quantity of Rolls for each player in one turn
        /// </summary>              
        public const int MAX_ROLL = 3;
        /// <summary>
        /// Turns played
        /// </summary>
        public int Turns;
        /// <summary>
        /// MIN quantity of players for LCR Game
        /// </summary>
        public const int MIN_PLAYERS = 3;

        
        public LCRGame(List<Player> players)
        {
            Players = players;
        }

        /// <summary>
        /// Returns the winner
        /// </summary>
        /// <returns></returns>
        public Player GetWinner()
        {
            return Players.FirstOrDefault(p => p.Chips > 0);
        }

        /// <summary>
        /// Returns how many players still with chips
        /// </summary>
        /// <returns></returns>
        public int GetCountPlayersWithChips()
        {
            return Players.Count(p => p.Chips > 0);
        }

        public List<Player> GetPlayersWithChips()
        {
            return Players.Where(p => p.Chips > 0).ToList();
        }

        /// <summary>
        /// This method was used to test LCR logic
        /// </summary>
        public void PrintScores()
        {
            foreach (var player in Players)
            {
                Console.WriteLine("PlayerName: " + player.PlayerName + " Chips: " + player.Chips);
            }
        }

        /// <summary>
        /// This method was used to test LCR logic
        /// </summary>
        public void PrintWinner()
        {
            Console.WriteLine("We Got a winner");
            var winner = GetWinner();
            Console.WriteLine("PlayerName: " + winner.PlayerName);
            Console.WriteLine("Chips: " + winner.Chips);
        }

        /// <summary>
        /// Starts Dot Game
        /// </summary>
        public void Start()
        {
            if (!Players.Any() || Players.Count() < MIN_PLAYERS)
                throw new Exception($"Invalid quantity of Players, you will need at least {MIN_PLAYERS} players to start LCR Game");

            while (GetCountPlayersWithChips() > 1)
            {
                //Increment turns before start players to roll
                Turns++;
                foreach (var player in Players)
                {
                    if (!player.PlayerWithChips())
                    {                        
                        continue;
                    }
                    if (player.Chips >= 3)
                    {
                        for (var roll_count = 1; roll_count <= MAX_ROLL; roll_count++)
                        {                            
                            Roll(player);
                        }
                    }
                    else if (player.Chips == 2)
                    {
                        for (var roll_count = 1; roll_count <= player.Chips; roll_count++)
                        {                            
                            Roll(player);
                        }
                    }
                    else if (player.Chips == 1)
                    {
                        for (var roll_count = 1; roll_count <= player.Chips; roll_count++)
                        {                            
                            Roll(player);
                        }
                    }
                    System.Threading.Thread.Sleep(100);
                    PrintScores();
                    if (GetCountPlayersWithChips() == 1) //We got a winner
                    {
                        //TODO
                        //Maybe adding more features to know which players won in each game
                        //PrintWinner();
                        return;
                    }
                }
            }
        }
        public Player Roll(Player player)
        {
            var randomGenerator = new Random();
            //Roll the dice
            var roll_value = randomGenerator.Next(1, 6);
            var player_index = Players.IndexOf(player);

            switch (roll_value)
            {
                case (int)Dots.Dot1:
                case (int)Dots.Dot2:
                case (int)Dots.Dot3:                    
                    break;
                case (int)Dots.L:                    
                    Players[player_index].Chips -= 1;
                    Players[(player_index + 1) % Players.Count()].Chips += 1;
                    break;
                case (int)Dots.C:                    
                    Players[player_index].Chips -= 1;
                    break;
                case (int)Dots.R:                    
                    Players[player_index].Chips -= 1;
                    Players[(player_index - 1) % Players.Count()].Chips += 1;
                    break;
                default:
                    break;
            }
            return player;
        }
    }
}
