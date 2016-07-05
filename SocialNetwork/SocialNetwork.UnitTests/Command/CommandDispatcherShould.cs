using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;

namespace SocialNetwork.UnitTests.Command
{
    [TestClass]
    public class CommandDispatcherShould
    {
        [TestMethod]
        public void RetrieveTranslatedCommandFromConsole()
        {
            var commandString = "command";
            Mock<ICommand> commandMock = new Mock<ICommand>();

            Mock<IConsole> consoleMock = new Mock<IConsole>();
            consoleMock.Setup(m => m.Read()).Returns(commandString);

            Mock<ICommandTranslator> commandTranslatorMock = new Mock<ICommandTranslator>();
            commandTranslatorMock.Setup(m => m.Translate(It.IsAny<string>())).Returns(commandMock.Object);
            
            CommandDispatcher commandDispatcher = new CommandDispatcher(commandTranslatorMock.Object, consoleMock.Object);

            var command = commandDispatcher.Retrieve();

            consoleMock.Verify(m => m.Read());
            commandTranslatorMock.Verify(m => m.Translate(commandString));

            Assert.AreSame(commandMock.Object, command);
        }
    }
}
