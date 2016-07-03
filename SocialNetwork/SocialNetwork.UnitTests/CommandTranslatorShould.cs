using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class CommandTranslatorShould
    {
        private readonly string username = "Alice";
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

            var commandString = $"{username} -> {message}";

            var postCommand = _translator.Translate(commandString) as Post;

            Assert.IsNotNull(postCommand);
            Assert.AreEqual(username, postCommand.Username);
            Assert.AreEqual(message, postCommand.Message);
        }

        [TestMethod]
        public void ReturnDisplayCommand()
        {
            var displayCommand = _translator.Translate(username) as DisplayUserPosts;

            Assert.IsNotNull(displayCommand);

            Assert.AreEqual(username, displayCommand.Username);
        }
    }
}
