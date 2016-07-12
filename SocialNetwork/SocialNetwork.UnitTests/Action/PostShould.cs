using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Action.Command;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Social.Engine;
using SocialNetwork.Model.User;
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
            _socialEngineMock.Setup(m => m.Post(It.IsAny<User>(), It.IsAny<string>()));

            var user = new User("test");
            var message = "content";

            new Post(_socialEngineMock.Object, user, message).Execute();

            _socialEngineMock.Verify(m => m.Post(user, message));
        }
    }
}
