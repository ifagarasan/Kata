using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;
using SocialNetwork.Command.Processor;

namespace SocialNetwork.UnitTests.Command.Processor
{
    [TestClass]
    public class DisplayTimelineProcessorShould
    {
        [TestMethod]
        public void PrintTimeline()
        {
            var message = "I'm in London! (1 minute ago)";
            var userMessages = new List<string> { message };

            var socialEngineMock = new Mock<ISocialEngine>();
            socialEngineMock.Setup(m => m.RetrieveTimeline(It.IsAny<string>())).Returns(userMessages);

            var consoleMock = new Mock<IConsole>();

            var processor = new DisplayTimelineProcessor(socialEngineMock.Object, consoleMock.Object);

            var username = "test";
            var command = new DisplayTimeline(username);

            processor.Process(command);

            socialEngineMock.Verify(m => m.RetrieveTimeline(username));
            consoleMock.Verify(m => m.Write(message));
        }
    }
}
