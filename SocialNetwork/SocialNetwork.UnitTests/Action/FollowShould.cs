using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.User;
using Follow = SocialNetwork.Action.Command.Follow;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class FollowShould
    {
        private Mock<IRepository> _repositoryMock;
        private Mock<IPostFormatter> _postFormatterMock;
        private Mock<IConsole> _consoleMock;

        [TestInitialize]
        public void Setup()
        {
            _consoleMock = new Mock<IConsole>();
            _consoleMock.Setup(m => m.Write(It.IsAny<string>()));

            _repositoryMock = new Mock<IRepository>();
            _postFormatterMock = new Mock<IPostFormatter>();
        }

        [TestMethod]
        public void Follow()
        {
            _repositoryMock.Setup(m => m.Follow(It.IsAny<User>(), It.IsAny<User>()));

            var user = new User("Alice"); 
            var followUser = new User("Bob");

            new Follow(_repositoryMock.Object, user, followUser).Execute();

            _repositoryMock.Verify(m => m.Follow(user, followUser));
        }
    }
}
