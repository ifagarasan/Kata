using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTackToe;
using Moq;

namespace TicTackToe_Tests
{
    [TestClass]
    public class GameServiceFunctionality
    {
        GameService gameService;
        Mock<IBoardValidator> mockBoardValidator;
        char[,] board;

        [TestInitialize]
        public void Setup()
        {
            mockBoardValidator = new Mock<IBoardValidator>();
            gameService = new GameService(mockBoardValidator.Object);
            board = CreateBoard();
        }

        private char[,] CreateBoard()
        {
            return new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        }

        [TestMethod]
        public void ReturnsSpaceIfNoWinner()
        {
            Assert.AreEqual(' ', gameService.GetWinner(board));
        }

        [TestMethod]
        public void ReturnsWinnerIfSymbolCoversHorizontalLine()
        {
            char expected = 'X';

            for (int i = 0; i < 3; ++i)
            {
                board = CreateBoard();

                for (int j = 0; j < 3; ++j)
                    board[i, j] = 'X';

                Assert.AreEqual(expected, gameService.GetWinner(board));
            }
        }

        [TestMethod]
        public void ReturnsWinnerIfSymbolCoversVerticalLine()
        {
            char expected = '0';

            for (int j = 0; j < 3; ++j)
            {
                board = CreateBoard();

                for (int i = 0; i < 3; ++i)
                    board[i, j] = expected;

                Assert.AreEqual(expected, gameService.GetWinner(board));
            }
        }

        [TestMethod]
        public void ReturnsWinnerIfSymbolCoversMainDiagonal()
        {
            char expected = 'X';

            for (int i = 0; i < 3; ++i)
                board[i, i] = expected;

            Assert.AreEqual(expected, gameService.GetWinner(board));
        }

        [TestMethod]
        public void ReturnsWinnerIfSymbolCoversSecondaryDiagonal()
        {
            char expected = '0';

            for (int i = 0; i < 3; ++i)
                board[i, 2-i] = expected;

            Assert.AreEqual(expected, gameService.GetWinner(board));
        }

        [TestMethod]
        public void CallsBoardValidatorValidate()
        {
            mockBoardValidator.Setup(m => m.Validate(It.IsAny<BoardData>()));

            gameService.GetWinner(board);

            mockBoardValidator.Verify(m => m.Validate(It.IsAny<BoardData>()));
        }
    }
}
