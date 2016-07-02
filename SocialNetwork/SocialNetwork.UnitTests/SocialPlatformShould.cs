using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class SocialPlatformShould
    {
        [TestMethod]
        public void ProcessCommandsRetrievedFromTheCommandDispatcher()
        {
            Mock<IConsole> consoleMock = new Mock<IConsole>();
            Mock<ICommandDispatcher> commandDispatcherMock = new Mock<ICommandDispatcher>();
            Mock<ICommandProcessor> commandProcessorMock = new Mock<ICommandProcessor>();
            Mock<ICommand> commandMock = new Mock<ICommand>();

            commandDispatcherMock.Setup(m => m.Retrieve()).Returns(commandMock.Object);
            commandProcessorMock.Setup(m => m.Process(It.IsAny<ICommand>()));

            ISocialPlatform socialPlatform = new SocialPlatform(commandDispatcherMock.Object, commandProcessorMock.Object);

            socialPlatform.Run();

            commandDispatcherMock.Verify(m => m.Retrieve());
            commandProcessorMock.Verify(m => m.Process(commandMock.Object));
        }
    }
}
