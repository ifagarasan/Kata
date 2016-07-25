using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Board.Formatter;
using TicTacToe.Board.Rule;
using TicTacToe.Board.Rule.Status;
using TicTacToe.FeatureTests.Test;

namespace TicTacToe.FeatureTests.Board
{
    [TestClass]
    public class Service
    {
        TicTacToe.Board.Service _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new TicTacToe.Board.Service(new RulesFactory(new StatusFormatter()));
        }

        [TestMethod]
        public void DetectsStalemate()
        {
            Assert.AreEqual("Stalemate", _service.Status(BoardMother.MakeStalemate()));
        }

        [TestMethod]
        public void DetectsInProgress()
        {
            Assert.AreEqual("In Progress", _service.Status(BoardMother.MakeInProgress()));
        }

        [TestMethod]
        public void DetectsWin()
        {
            Assert.AreEqual("Win for Cross", _service.Status(BoardMother.MakeCrossWin()));
        }
    }
}
