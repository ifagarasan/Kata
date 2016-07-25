using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TicTacToe.Board.Cell;
using TicTacToe.FeatureTests.Test;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TicTacToe.UnitTests.Board
{
    [TestClass]
    public class BoardShould
    {
        [TestMethod]
        public void DetectFull()
        {
            IsFalse(BoardMother.MakeEmpty().Full());
            IsTrue(BoardMother.MakeStalemate().Full());
        }

        [TestMethod]
        public void DetectHasWinner()
        {
            IsFalse(BoardMother.MakeEmpty().HasWinner());
            IsTrue(BoardMother.MakeLineWinner(Index.One, Symbol.O).HasWinner());
        }

        [TestMethod]
        public void DetectLineWinner()
        {
            AreEqual(Symbol.O, BoardMother.MakeLineWinner(Index.One, Symbol.O).Winner());
            AreEqual(Symbol.Cross, BoardMother.MakeLineWinner(Index.Two, Symbol.Cross).Winner());
            AreEqual(Symbol.O, BoardMother.MakeLineWinner(Index.Three, Symbol.O).Winner());
        }

        [TestMethod]
        public void DetectColumnWinner()
        {
            AreEqual(Symbol.O, BoardMother.MakeColumnWinner(Index.One, Symbol.O).Winner());
            AreEqual(Symbol.Cross, BoardMother.MakeColumnWinner(Index.Two, Symbol.Cross).Winner());
            AreEqual(Symbol.O, BoardMother.MakeColumnWinner(Index.Three, Symbol.O).Winner());
        }

        [TestMethod]
        public void DetectDiagonalWinner()
        {
            AreEqual(Symbol.O, BoardMother.MakeMainDiagonalWinner(Symbol.O).Winner());
            AreEqual(Symbol.Cross, BoardMother.MakeSecondaryDiagonalWinner(Symbol.Cross).Winner());
        }
    }
}
