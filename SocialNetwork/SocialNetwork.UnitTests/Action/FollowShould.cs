using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Model.User;
using Follow = SocialNetwork.Action.Command.Follow;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class FollowShould
    {
        [TestMethod]
        public void Follow()
        {
            var user = new User("Alice");
            var followUsername = "Bob";

            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock.SetupSequence(m => m.Get(It.IsAny<string>())).Returns(user);

            new Follow(userRepositoryMock.Object, user.Username, followUsername).Execute();

            Assert.IsTrue(user.Follows.Contains(followUsername));
        }
    }
}
