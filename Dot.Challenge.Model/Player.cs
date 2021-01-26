using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot.Challenge.Model
{
    /// <summary>
    /// Represents a player in LCR Game
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Player Name
        /// Not required for this challenge
        /// </summary>
        public string PlayerName { set; get; }
        /// <summary>
        /// Quantity of Chips remaining per player
        /// </summary>
        public int Chips { set; get; }

        public Player()
        {
            //Max rolls are the same that initial quantity of chips
            Chips = LCRGame.MAX_ROLL;
        }

        /// <summary>
        /// If this player still able to roll the dice
        /// </summary>
        /// <returns></returns>
        public bool PlayerWithChips()
        {
            return Chips > 0;
        }

    }
}
