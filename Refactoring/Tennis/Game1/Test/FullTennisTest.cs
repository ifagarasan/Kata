using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Tennis;

namespace Tennis.Test
{
    [TestClass]
    public class FullTennisTest
    {
        public void RealisticTennisGame(ITennisGame game)
        {
            var points = new[] {"player1", "player1", "player2", "player2", "player1", "player1"};
            var expectedScores = new []
            {
                "Fifteen-Love",
                "Thirty-Love",
                "Thirty-Fifteen",
                "Thirty-All",
                "Forty-Thirty",
                "Win for player1"
            };

            for (var i = 0; i < 6; i++)
            {
                game.WonPoint(points[i]);

                Assert.AreEqual(expectedScores[i], game.GetScore());
            }
        }

        [TestMethod]
        public void CheckGame1()
        {
            RealisticTennisGame(new TennisGame1("player1", "player2"));
        }
    }
}