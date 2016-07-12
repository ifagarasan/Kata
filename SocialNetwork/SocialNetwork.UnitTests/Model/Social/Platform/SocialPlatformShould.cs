using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Command.Input;
using SocialNetwork.Model.Social.Platform;

namespace SocialNetwork.UnitTests.Model.Social.Platform
{
    [TestClass]
    public class SocialPlatformShould
    {
        [TestMethod]
        public void ExecuteCommands()
        {
            Mock<IInputRetriever> taskDispatcherMock = new Mock<IInputRetriever>();
            Mock<ICommand> commandMock = new Mock<ICommand>();

            Mock<ICommandFactory> commandFactoryMock = new Mock<ICommandFactory>();
            commandFactoryMock.Setup(m => m.Create(It.IsAny<CommandInput>())).Returns(commandMock.Object);

            var displayTimeline = new CommandInput(InputType.DisplayTimeline, new[] {"Alice"});
            var exit = new CommandInput(InputType.Exit, new string[] {});

            taskDispatcherMock.SetupSequence(m => m.Retrieve()).Returns(displayTimeline).Returns(displayTimeline).Returns(exit);
            commandMock.Setup(m => m.Execute());

            ISocialPlatform socialPlatform = new SocialPlatform(taskDispatcherMock.Object, commandFactoryMock.Object);

            socialPlatform.Run();

            taskDispatcherMock.Verify(m => m.Retrieve(), Times.Exactly(3));
            commandFactoryMock.Verify(m => m.Create(displayTimeline), Times.Exactly(2));
            commandMock.Verify(m => m.Execute(), Times.Exactly(2));
        }
    }
}