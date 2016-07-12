using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Model.Command.Exceptions;
using SocialNetwork.Model.Command.Input;

namespace SocialNetwork.UnitTests.Model.Command.Input
{
    [TestClass]
    public class InputParserShould
    {
        private readonly string _username = "Alice";
        private readonly string _followUsername = "Bob";

        IInputParser _parser;

        [TestInitialize]
        public void Setup()
        {
            _parser = new InputParser();
        }

        [TestMethod]
        public void ReturnPost()
        {
            var message = "I love the weather today";
            var commandString = $"{_username} -> {message}";
            var command = _parser.Parse(commandString);

            Assert.AreEqual(InputType.Post, command.Type);
            Assert.AreEqual(_username, command.Arguments[0]);
            Assert.AreEqual(message, command.Arguments[1]);
        }

        [TestMethod]
        public void ReturnDisplayTimeline()
        {
            var command = _parser.Parse(_username);

            Assert.AreEqual(InputType.DisplayTimeline, command.Type);
            Assert.AreEqual(_username, command.Arguments[0]);
        }

        [TestMethod]
        public void ReturnExit()
        {
            var command = _parser.Parse("exit");

            Assert.AreEqual(InputType.Exit, command.Type);
            Assert.AreEqual(0, command.Arguments.Length);
        }

        [TestMethod]
        public void ReturnDisplayWall()
        {
            var command = _parser.Parse($"{_username} wall");

            Assert.AreEqual(InputType.DisplayWall, command.Type);
            Assert.AreEqual(_username, command.Arguments[0]);
        }

        [TestMethod]
        public void ReturnFollow()
        {
            var command = _parser.Parse($"{_username} follows {_followUsername}");

            Assert.AreEqual(InputType.Follow, command.Type);
            Assert.AreEqual(_username, command.Arguments[0]);
            Assert.AreEqual(_followUsername, command.Arguments[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(CommandTypeNotDefinedException))]
        public void ThrowExceptionIfCommandNotSupported()
        {
            _parser.Parse("Invalid Command");
        }
    }
}