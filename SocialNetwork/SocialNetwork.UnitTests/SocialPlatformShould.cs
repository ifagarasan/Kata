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

            commandDispatcherMock.Setup(m => m.Retrieve()).Returns(displayUserPosts);
            commandProcessorMock.Setup(m => m.Process(It.IsAny<DisplayUserPosts>()));

            ISocialPlatform socialPlatform = new SocialPlatform(commandDispatcherMock.Object, commandProcessorFactoryMock.Object);

            socialPlatform.Run();

            commandDispatcherMock.Verify(m => m.Retrieve());
            commandProcessorFactoryMock.Verify(m => m.Create(displayUserPosts));
            commandProcessorMock.Verify(m => m.Process(displayUserPosts));
        }
    }
}
