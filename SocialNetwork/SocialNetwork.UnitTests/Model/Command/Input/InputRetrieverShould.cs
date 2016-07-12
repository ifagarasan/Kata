using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Command.Input;

namespace SocialNetwork.UnitTests.Model.Command.Input
{
    [TestClass]
    public class InputRetrieverShould
    {
        [TestMethod]
        public void RetrieveCommandInput()
        {
            var input = "exit";
            var commandInput = new CommandInput(InputType.Exit, new string[] {});

            Mock<IConsole> consoleMock = new Mock<IConsole>();
            consoleMock.Setup(m => m.Read()).Returns(input);

            Mock<IInputParser> commandTranslatorMock = new Mock<IInputParser>();
            commandTranslatorMock.Setup(m => m.Parse(It.IsAny<string>())).Returns(commandInput);
            
            InputRetriever commandInputRetriever = new InputRetriever(commandTranslatorMock.Object, consoleMock.Object);

            var command = commandInputRetriever.Retrieve();

            consoleMock.Verify(m => m.Read());
            commandTranslatorMock.Verify(m => m.Parse(input));

            Assert.AreSame(commandInput, command);
        }
    }
}
