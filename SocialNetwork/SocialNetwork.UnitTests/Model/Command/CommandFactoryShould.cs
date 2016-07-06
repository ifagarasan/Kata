using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Command.Exceptions;
using SocialNetwork.Model.Command.Input;
using DisplayTimeline = SocialNetwork.Action.Command.DisplayTimeline;
using DisplayWall = SocialNetwork.Action.Command.DisplayWall;
using Follow = SocialNetwork.Action.Command.Follow;

namespace SocialNetwork.UnitTests.Model.Command
{
    [TestClass]
    public class CommandFactoryShould
    {
        private CommandFactory _commandFactory;

        [TestInitialize]
        public void Setup()
        {
            _commandFactory = new CommandFactory(null, null);
        }

        [TestMethod]
        public void ReturnsPostCommand()
        {
            Assert.IsInstanceOfType(_commandFactory.Create(new CommandInput(CommandType.Post, new string[] { })), typeof(SocialNetwork.Action.Command.Post));
        }

        [TestMethod]
        public void ReturnsDisplayTImelineCommand()
        {
            Assert.IsInstanceOfType(_commandFactory.Create(new CommandInput(CommandType.DisplayTimeline, new string[] { })), typeof(DisplayTimeline));
        }

        [TestMethod]
        public void ReturnsDisplayWallCommand()
        {
            Assert.IsInstanceOfType(_commandFactory.Create(new CommandInput(CommandType.DisplayWall, new string[] {})), typeof(DisplayWall));
        }

        [TestMethod]
        public void ReturnsFollowCommand()
        {
            Assert.IsInstanceOfType(_commandFactory.Create(new CommandInput(CommandType.Follow, new string[] { })), typeof(Follow));
        }

        [TestMethod]
        [ExpectedException(typeof(CommandNotDefinedException))]
        public void ThrowExceptionIfCommandDoesNotExistForTaskType()
        {
            _commandFactory.Create(new CommandInput(CommandType.Exit, new string[] { }));
        }
    }
}