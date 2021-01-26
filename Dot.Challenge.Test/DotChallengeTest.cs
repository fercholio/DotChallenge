using Dot.Challenge.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;

namespace Dot.Challenge.Test
{
    [TestClass]
    public class DotChallengeTest
    {
        private List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player { PlayerName = "Brian" });
            players.Add(new Player { PlayerName = "John" });
            players.Add(new Player { PlayerName = "Carl" });

            return players;
        }

        [TestMethod]        
        public void PlayOneLCRGame()
        {
            var players = GetPlayers();
            var lcrGame = new LCRGame(players);

            lcrGame.Start();

            Assert.AreEqual(players.Count, lcrGame.Players.Count);
            //Validate that after game ends, there is just 1 winner.
            Assert.AreEqual(1, lcrGame.GetCountPlayersWithChips());
            
        }
    }
}
