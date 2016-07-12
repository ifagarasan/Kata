using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Action.Command;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Social.Engine;
using SocialNetwork.UnitTests.Model.Command;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class PostShould
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
        public void Insert()
        {
            _socialEngineMock.Setup(m => m.Post(It.IsAny<string>(), It.IsAny<string>()));

            var username = "test";
            var message = "content";

            new Post(_socialEngineMock.Object, username, message).Execute();

            _socialEngineMock.Verify(m => m.Post(username, message));
        }
    }
}
