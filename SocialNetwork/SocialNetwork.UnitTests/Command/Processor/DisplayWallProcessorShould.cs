using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;
using SocialNetwork.Command.Processor;

namespace SocialNetwork.UnitTests.Command.Processor
{
    [TestClass]
    public class DisplayWallProcessorShould
    {
        [TestMethod]
        public void PrintWall()
        {
            var message = "Bob - I'm in London! (1 minute ago)";
            var userMessages = new List<string> { message };

            var socialEngineMock = new Mock<ISocialEngine>();
            socialEngineMock.Setup(m => m.RetrieveWall(It.IsAny<string>())).Returns(userMessages);

            var consoleMock = new Mock<IConsole>();

            var processor = new DisplayWallProcessor(socialEngineMock.Object, consoleMock.Object);

            var username = "test";
            var command = new DisplayWall(username);

            processor.Process(command);

            socialEngineMock.Verify(m => m.RetrieveWall(username));
            consoleMock.Verify(m => m.Write(message));
        }
    }
}
