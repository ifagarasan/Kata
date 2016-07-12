using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Social.Engine;
using SocialNetwork.UnitTests.Model.Command;
using DisplayTimeline = SocialNetwork.Action.Command.DisplayTimeline;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class DisplayTimelineShould
    {
        private Mock<ISocialEngine> _socialEngineMock;
        private Mock<IConsole> _consoleMock;

        [TestInitialize]
        public void Setup()
        {
            _consoleMock = new Mock<IConsole>();
            _consoleMock.Setup(m => m.Write(It.IsAny<string>()));

            _socialEngineMock = new Mock<ISocialEngine>();
        }

        [TestMethod]
        public void PrintTimeline()
        {
            var username = "test";
            var message = "I'm in London! (1 minute ago)";
            var userMessages = new List<string> { message };

            _socialEngineMock.Setup(m => m.RetrieveTimeline(It.IsAny<string>())).Returns(userMessages);

            new DisplayTimeline(_socialEngineMock.Object, _consoleMock.Object, username).Execute();

            _socialEngineMock.Verify(m => m.RetrieveTimeline(username));
            _consoleMock.Verify(m => m.Write(message));
        }
    }
}
