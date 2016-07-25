using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TicTacToe.Board;
using TicTacToe.Board.Formatter;
using TicTacToe.Board.Rule;
using TicTacToe.Board.Rule.Status;
using static TicTacToe.Board.Cell.Symbol;

namespace TicTacToe.UnitTests.Board
{
    [TestClass]
    public class ServiceShould
    {
        [TestMethod]
        public void CallApplyOnAllRulesAndReturnNonEmptyResult()
        {
            var board = Substitute.For<IBoard>();
            var ruleFactory = Substitute.For<IRulesFactory>();
            var appliableRule = Substitute.For<IRule>();
            var nonAppliableRule = Substitute.For<IRule>();
            ruleFactory.Make().Returns(new List<IRule>
            {
                appliableRule,
                nonAppliableRule
            });
            var result = "result";
            appliableRule.Apply(Arg.Any<IBoard>()).Returns(result);
            nonAppliableRule.Apply(Arg.Any<IBoard>()).Returns(string.Empty);
            var service = new Service(ruleFactory);

            Assert.AreEqual(result, service.Status(board));
            nonAppliableRule.Received().Apply(board);
            appliableRule.Received().Apply(board);
        }
    }
}
