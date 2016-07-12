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

        const string Username = "test";

        [TestInitialize]
        public void Setup()
        {
            _commandFactory = new CommandFactory(null, null);
        }

        [TestMethod]
        public void ReturnsPostCommand()
        {
            var message = "message";

            var command = _commandFactory.Create(new CommandInput(InputType.Post, new [] {Username, message})) as SocialNetwork.Action.Command.Post;

            Assert.IsNotNull(command);
            Assert.AreEqual(Username, command.User.Username);
            Assert.AreEqual(message, command.Message);
        }

        [TestMethod]
        public void ReturnsDisplayTImelineCommand()
        {
            var command = _commandFactory.Create(new CommandInput(InputType.DisplayTimeline, new[] {Username})) as DisplayTimeline;

            Assert.IsNotNull(command);
            Assert.AreEqual(Username, command.User.Username);
        }

        [TestMethod]
        public void ReturnsDisplayWallCommand()
        {
            var command = _commandFactory.Create(new CommandInput(InputType.DisplayWall, new[] { Username })) as DisplayWall;

            Assert.IsNotNull(command);
            Assert.AreEqual(Username, command.User.Username);
        }

        [TestMethod]
        public void ReturnsFollowCommand()
        {
            string usernameToFollow = "Bob";

            var command = _commandFactory.Create(new CommandInput(InputType.Follow, new[] { Username, usernameToFollow })) as Follow;

            Assert.IsNotNull(command);
            Assert.AreEqual(Username, command.User.Username);
            Assert.AreEqual(usernameToFollow, command.FollowUser.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(CommandNotDefinedException))]
        public void ThrowExceptionIfCommandDoesNotExistForTaskType()
        {
            _commandFactory.Create(new CommandInput(InputType.Exit, new string[] { }));
        }
    }
}