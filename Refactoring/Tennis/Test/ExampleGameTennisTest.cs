using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tennis.Test
{
    [TestClass]
    public class ExampleGameTennisTest
    {
        public void RealisticTennisGame(TennisGame game)
        {
            String[] points = {"player1", "player1", "player2", "player2", "player1", "player1"};
            String[] expected_scores =
            {
                "Fifteen-Love", "Thirty-Love", "Thirty-Fifteen", "Thirty-All", "Forty-Thirty",
                "Win for player1"
            };
            for (int i = 0; i < 6; i++)
            {
                game.WonPoint(points[i]);
                Assert.AreEqual(expected_scores[i], game.GetScore());
            }
        }

        [TestMethod]
        public void CheckGame1()
        {
            TennisGame1 game = new TennisGame1("player1", "player2");
            RealisticTennisGame(game);
        }

        [TestMethod]
        public void CheckGame2()
        {
            TennisGame2 game = new TennisGame2("player1", "player2");
            RealisticTennisGame(game);
        }

        [TestMethod]
        public void CheckGame3()
        {
            TennisGame3 game = new TennisGame3("player1", "player2");
            RealisticTennisGame(game);
        }
    }
}