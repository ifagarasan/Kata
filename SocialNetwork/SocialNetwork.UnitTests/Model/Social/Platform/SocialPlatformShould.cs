using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Action.Command;
using SocialNetwork.Infrastructure.Console;
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
            var timeline = "Alice";
            var wall = "Alice wall";
            var exit = "exit";

            Mock<IConsole> consoleMock = new Mock<IConsole>();
            consoleMock.SetupSequence(m => m.Read()).Returns(timeline).Returns(wall).Returns(exit);

            Mock<IInputParser> inputParserMock = new Mock<IInputParser>();

            var displayTimelineInput = new CommandInput(InputType.DisplayTimeline, new[] { "Alice" });
            var displayWallInput = new CommandInput(InputType.DisplayWall, new[] { "Alice" });
            var exitInput = new CommandInput(InputType.Exit, new string[] {});

            inputParserMock.SetupSequence(m => m.Parse(It.IsAny<string>()))
                .Returns(displayTimelineInput)
                .Returns(displayWallInput)
                .Returns(exitInput);

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(m => m.Execute());

            var commandFactoryMock = new Mock<ICommandFactory>();
            commandFactoryMock.Setup(m => m.Create(It.IsAny<CommandInput>())).Returns(commandMock.Object);

            ISocialPlatform socialPlatform = new SocialPlatform(inputParserMock.Object, consoleMock.Object, commandFactoryMock.Object);

            socialPlatform.Run();

            inputParserMock.Verify(m => m.Parse(timeline));
            inputParserMock.Verify(m => m.Parse(wall));
            inputParserMock.Verify(m => m.Parse(exit));

            commandFactoryMock.Verify(m => m.Create(displayTimelineInput));
            commandFactoryMock.Verify(m => m.Create(displayWallInput));

            commandMock.Verify(m => m.Execute(), Times.Exactly(2));
        }
    }
}