using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;
using SocialNetwork.Command.Processor;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class SocialPlatformShould
    {
        [TestMethod]
        public void ProcessCommandsRetrievedFromTheCommandDispatcher()
        {
            Mock<ICommandDispatcher> commandDispatcherMock = new Mock<ICommandDispatcher>();
            Mock<ICommandProcessor> commandProcessorMock = new Mock<ICommandProcessor>();

            Mock<ICommandProcessorFactory> commandProcessorFactoryMock = new Mock<ICommandProcessorFactory>();
            commandProcessorFactoryMock.Setup(m => m.Create(It.IsAny<ICommand>())).Returns(commandProcessorMock.Object);

            var displayUserPosts = new DisplayUserPosts("Alice");
            var exit = new Exit();

            commandDispatcherMock.SetupSequence(m => m.Retrieve()).Returns(displayUserPosts).Returns(displayUserPosts).Returns(exit);
            commandProcessorMock.Setup(m => m.Process(It.IsAny<DisplayUserPosts>()));

            ISocialPlatform socialPlatform = new SocialPlatform(commandDispatcherMock.Object, commandProcessorFactoryMock.Object);

            socialPlatform.Run();

            commandDispatcherMock.Verify(m => m.Retrieve(), Times.Exactly(3));
            commandProcessorFactoryMock.Verify(m => m.Create(displayUserPosts), Times.Exactly(2));
            commandProcessorMock.Verify(m => m.Process(displayUserPosts), Times.Exactly(2));
        }
    }
}
