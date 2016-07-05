using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Command;
using SocialNetwork.Exceptions;

namespace SocialNetwork.UnitTests.Command
{
    [TestClass]
    public class CommandTranslatorShould
    {
        private readonly string _username = "Alice";
        private readonly string _followUsername = "Bob";

        ICommandTranslator _translator;

        [TestInitialize]
        public void Setup()
        {
            _translator = new CommandTranslator();
        }

        [TestMethod]
        public void ReturnPostMessage()
        {
            var message = "I love the weather today";
            var commandString = $"{_username} -> {message}";
            var command = _translator.Translate(commandString) as PostMessage;

            Assert.IsNotNull(command);
            Assert.AreEqual(_username, command.Username);
            Assert.AreEqual(message, command.Message);
        }

        [TestMethod]
        public void ReturnDisplayTimeline()
        {
            var command = _translator.Translate(_username) as DisplayTimeline;

            Assert.IsNotNull(command);
            Assert.AreEqual(_username, command.Username);
        }

        [TestMethod]
        public void ReturnExit()
        {
            Assert.IsNotNull(_translator.Translate("exit") as Exit);
        }

        [TestMethod]
        public void ReturnDisplayWall()
        {
            var command = _translator.Translate($"{_username} wall") as DisplayWall;

            Assert.IsNotNull(command);
            Assert.AreEqual(_username, command.Username);
        }

        [TestMethod]
        public void ReturnFollow()
        {
            var command = _translator.Translate($"{_username} follows {_followUsername}") as Follow;

            Assert.IsNotNull(command);
            Assert.AreEqual(_username, command.Username);
            Assert.AreEqual(_followUsername, command.FollowUsername);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void ThrowExceptionIfCommandNotSupported()
        {
            _translator.Translate("Invalid Command");
        }
    }
}
