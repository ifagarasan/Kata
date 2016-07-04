using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class CommandTranslatorShould
    {
        private readonly string _username = "Alice";
        ICommandTranslator _translator;

        [TestInitialize]
        public void Setup()
        {
            _translator = new CommandTranslator();
        }

        [TestMethod]
        public void ReturnPostCommand()
        {
            var message = "I love the weather today";
            var commandString = $"{_username} -> {message}";
            var postCommand = _translator.Translate(commandString) as PostMessage;

            Assert.IsNotNull(postCommand);
            Assert.AreEqual(_username, postCommand.Username);
            Assert.AreEqual(message, postCommand.Message);
        }

        [TestMethod]
        public void ReturnDisplayUserPosts()
        {
            var displayCommand = _translator.Translate(_username) as DisplayUserPosts;

            Assert.IsNotNull(displayCommand);
            Assert.AreEqual(_username, displayCommand.Username);
        }

        [TestMethod]
        public void ReturnExit()
        {
            Assert.IsNotNull(_translator.Translate("exit") as Exit);
        }
    }
}
