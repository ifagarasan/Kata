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

            var displayTimeline = new DisplayTimeline("Alice");
            var exit = new Exit();

            commandDispatcherMock.SetupSequence(m => m.Retrieve()).Returns(displayTimeline).Returns(displayTimeline).Returns(exit);
            commandProcessorMock.Setup(m => m.Process(It.IsAny<DisplayTimeline>()));

            ISocialPlatform socialPlatform = new SocialPlatform(commandDispatcherMock.Object, commandProcessorFactoryMock.Object);

            socialPlatform.Run();

            commandDispatcherMock.Verify(m => m.Retrieve(), Times.Exactly(3));
            commandProcessorFactoryMock.Verify(m => m.Create(displayTimeline), Times.Exactly(2));
            commandProcessorMock.Verify(m => m.Process(displayTimeline), Times.Exactly(2));
        }
    }
}
