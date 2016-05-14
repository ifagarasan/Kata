using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTackToe;
using Moq;

namespace TicTackToe_Tests
{
    [TestClass]
    public class GameServiceAcceptance
    {
        [TestMethod]
        public void GameServiceReturnsWinner()
        {
            char[,] board = new char[3, 3] { { 'X', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', 'X' } };

            GameService gameService = new GameService(new BoardValidator());

            Assert.AreEqual('X', gameService.GetWinner(board));
        }
    }
}
