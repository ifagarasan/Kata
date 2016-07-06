using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Model.Command.Exceptions;
using SocialNetwork.Model.Command.Input;

namespace SocialNetwork.UnitTests.Model.Command.Input
{
    [TestClass]
    public class InputBuilderShould
    {
        private readonly string _username = "Alice";
        private readonly string _followUsername = "Bob";

        IInputBuilder _builder;

        [TestInitialize]
        public void Setup()
        {
            _builder = new InputBuilder();
        }

        [TestMethod]
        public void ReturnPost()
        {
            var message = "I love the weather today";
            var commandString = $"{_username} -> {message}";
            var command = _builder.Build(commandString);

            Assert.AreEqual(CommandType.Post, command.Type);
            Assert.AreEqual(_username, command.Arguments[0]);
            Assert.AreEqual(message, command.Arguments[1]);
        }

        [TestMethod]
        public void ReturnDisplayTimeline()
        {
            var command = _builder.Build(_username);

            Assert.AreEqual(CommandType.DisplayTimeline, command.Type);
            Assert.AreEqual(_username, command.Arguments[0]);
        }

        [TestMethod]
        public void ReturnExit()
        {
            var command = _builder.Build("exit");

            Assert.AreEqual(CommandType.Exit, command.Type);
            Assert.AreEqual(0, command.Arguments.Length);
        }

        [TestMethod]
        public void ReturnDisplayWall()
        {
            var command = _builder.Build($"{_username} wall");

            Assert.AreEqual(CommandType.DisplayWall, command.Type);
            Assert.AreEqual(_username, command.Arguments[0]);
        }

        [TestMethod]
        public void ReturnFollow()
        {
            var command = _builder.Build($"{_username} follows {_followUsername}");

            Assert.AreEqual(CommandType.Follow, command.Type);
            Assert.AreEqual(_username, command.Arguments[0]);
            Assert.AreEqual(_followUsername, command.Arguments[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(CommandTypeNotDefinedException))]
        public void ThrowExceptionIfCommandNotSupported()
        {
            _builder.Build("Invalid Command");
        }
    }
}