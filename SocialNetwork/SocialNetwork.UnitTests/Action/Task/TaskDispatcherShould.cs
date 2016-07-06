using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Action.Command.Input;
using SocialNetwork.Infrastructure;

namespace SocialNetwork.UnitTests.Action.Task
{
    [TestClass]
    public class CommandDispatcherShould
    {
        [TestMethod]
        public void RetrieveCommandInput()
        {
            var input = "exit";
            var commandInput = new CommandInput(CommandType.Exit, new string[] {});

            Mock<IConsole> consoleMock = new Mock<IConsole>();
            consoleMock.Setup(m => m.Read()).Returns(input);

            Mock<IInputBuilder> commandTranslatorMock = new Mock<IInputBuilder>();
            commandTranslatorMock.Setup(m => m.Build(It.IsAny<string>())).Returns(commandInput);
            
            TaskDispatcher taskDispatcher = new TaskDispatcher(commandTranslatorMock.Object, consoleMock.Object);

            var command = taskDispatcher.Retrieve();

            consoleMock.Verify(m => m.Read());
            commandTranslatorMock.Verify(m => m.Build(input));

            Assert.AreSame(commandInput, command);
        }
    }
}
