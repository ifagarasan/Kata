using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Social.Engine;
using SocialNetwork.Model.User;
using SocialNetwork.UnitTests.Model.Command;
using Follow = SocialNetwork.Action.Command.Follow;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class FollowShould
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
        public void Follow()
        {
            _socialEngineMock.Setup(m => m.Follow(It.IsAny<User>(), It.IsAny<User>()));

            var user = new User("Alice"); 
            var followUser = new User("Bob");

            new Follow(_socialEngineMock.Object, user, followUser).Execute();

            _socialEngineMock.Verify(m => m.Follow(user, followUser));
        }
    }
}
