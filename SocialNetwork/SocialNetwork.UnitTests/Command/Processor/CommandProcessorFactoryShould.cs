﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;
using SocialNetwork.Command.Processor;
using SocialNetwork.Exceptions;

namespace SocialNetwork.UnitTests.Command.Processor
{
    [TestClass]
    public class CommandProcessorFactoryShould
    {
        readonly string _username = "test";
        CommandProcessorFactory _commandProcessorFactory;

        [TestInitialize]
        public void Setup()
        {
            _commandProcessorFactory = new CommandProcessorFactory(null, null);
        }

        [TestMethod]
        public void ReturnsPostCommandProcessor()
        {
            var content = "content";
            var command = new PostMessage(_username, content);
            var commandProcessor = _commandProcessorFactory.Create(command);

            Assert.IsInstanceOfType(commandProcessor, typeof(PostProcessor));
        }

        [TestMethod]
        public void ReturnsDisplayUserPostsCommandProcessor()
        {
            var command = new DisplayUserTimeline(_username);
            var commandProcessor = _commandProcessorFactory.Create(command);

            Assert.IsInstanceOfType(commandProcessor, typeof(DisplayUserTimelineProcessor));
        }

        [TestMethod]
        public void ReturnsDisplayWallCommandProcessor()
        {
            var command = new DisplayWall(_username);
            var commandProcessor = _commandProcessorFactory.Create(command);

            Assert.IsInstanceOfType(commandProcessor, typeof(DisplayWallCommandProcessor));
        }

        [TestMethod]
        [ExpectedException(typeof(CommandProcessorNotDefinedException))]
        public void ThrowExceptionIfCommandProcessorDoesNotExistForCommandType()
        {
            _commandProcessorFactory.Create(new Exit());
        }
    }
}
