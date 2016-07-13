using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tennis.Test
{
    [TestClass]
    public class TennisShould
    {
        [TestMethod]
        public void ReturnScore()
        {
            new TestScenario(0, 0, "Love-All").Validate();
            new TestScenario(1, 1, "Fifteen-All").Validate();
            new TestScenario(2, 2, "Thirty-All").Validate();
            new TestScenario(3, 3, "Deuce").Validate();
            new TestScenario(4, 4, "Deuce").Validate();
            new TestScenario(1, 0, "Fifteen-Love").Validate();
            new TestScenario(0, 1, "Love-Fifteen").Validate();
            new TestScenario(2, 0, "Thirty-Love").Validate();
            new TestScenario(0, 2, "Love-Thirty").Validate();
            new TestScenario(3, 0, "Forty-Love").Validate();
            new TestScenario(0, 3, "Love-Forty").Validate();
            new TestScenario(4, 0, "Win for player1").Validate();
            new TestScenario(0, 4, "Win for player2").Validate();
            new TestScenario(2, 1, "Thirty-Fifteen").Validate();
            new TestScenario(1, 2, "Fifteen-Thirty").Validate();
            new TestScenario(3, 1, "Forty-Fifteen").Validate();
            new TestScenario(1, 3, "Fifteen-Forty").Validate();
            new TestScenario(4, 1, "Win for player1").Validate();
            new TestScenario(1, 4, "Win for player2").Validate();
            new TestScenario(3, 2, "Forty-Thirty").Validate();
            new TestScenario(2, 3, "Thirty-Forty").Validate();
            new TestScenario(4, 2, "Win for player1").Validate();
            new TestScenario(2, 4, "Win for player2").Validate();
            new TestScenario(4, 3, "Advantage player1").Validate();
            new TestScenario(3, 4, "Advantage player2").Validate();
            new TestScenario(5, 4, "Advantage player1").Validate();
            new TestScenario(4, 5, "Advantage player2").Validate();
            new TestScenario(15, 14, "Advantage player1").Validate();
            new TestScenario(14, 15, "Advantage player2").Validate();
            new TestScenario(6, 4, "Win for player1").Validate();
            new TestScenario(4, 6, "Win for player2").Validate();
            new TestScenario(16, 14, "Win for player1").Validate();
            new TestScenario(14, 16, "Win for player2").Validate();
        }

        public class TestScenario
        {
            private readonly int _player1Score;
            private readonly int _player2Score;
            private readonly string _expectedScore;

            public TestScenario(int player1Score, int player2Score, string expectedScore)
            {
                _player1Score = player1Score;
                _player2Score = player2Score;
                _expectedScore = expectedScore;
            }

            public void Validate()
            {
                CheckAllScores(new TennisGame1("player1", "player2"));
                CheckAllScores(new TennisGame2("player1", "player2"));
                CheckAllScores(new TennisGame3("player1", "player2"));
            }

            private void CheckAllScores(TennisGame game)
            {
                int highestScore = Math.Max(this._player1Score, this._player2Score);

                for (int i = 0; i < highestScore; i++)
                {
                    if (i < _player1Score)
                        game.WonPoint("player1");
                    if (i < _player2Score)
                        game.WonPoint("player2");
                }

                Assert.AreEqual(_expectedScore, game.GetScore());
            }
        }
    }
}