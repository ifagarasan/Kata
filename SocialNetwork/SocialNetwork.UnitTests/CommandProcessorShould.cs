using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class CommandProcessorShould
    {
        [TestMethod]
        public void InsertOnPost()
        {
            Mock<ISocialEngine> socialEngineMock = new Mock<ISocialEngine>();
            socialEngineMock.Setup(m => m.Post(It.IsAny<string>(), It.IsAny<string>()));

            Mock<IConsole> consoleMock = new Mock<IConsole>();

            ICommandProcessor processor = new CommandProcessor(socialEngineMock.Object, consoleMock.Object);

            var username = "test";
            var content = "content";

            PostCommand command = new PostCommand(username, content);

            processor.Process(command);
        }
    }
}
