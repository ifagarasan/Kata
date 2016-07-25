using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Board.Formatter;

namespace TicTacToe.UnitTests.Board.Formatter
{
    [TestClass]
    public class StatusFormatterShould
    {
        [TestMethod]
        public void FormatsStalemate()
        {
            Assert.AreEqual("Stalemate", new StatusFormatter().FormatStalemate());
        }

        [TestMethod]
        public void FormatsInProgress()
        {
            Assert.AreEqual("In Progress", new StatusFormatter().FormatInProgress());
        }
    }
}
