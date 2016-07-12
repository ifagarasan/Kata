using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Action.Command;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.User;
using Post = SocialNetwork.Action.Command.Post;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class PostShould
    {
        private Mock<IPostRepository> _postRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IConsole> _consoleMock;

        [TestInitialize]
        public void Setup()
        {
            _consoleMock = new Mock<IConsole>();
            _consoleMock.Setup(m => m.Write(It.IsAny<string>()));

            _postRepositoryMock = new Mock<IPostRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [TestMethod]
        public void Insert()
        {
            var user = new User("test");
            var message = "content";

            _postRepositoryMock.Setup(m => m.Insert(It.IsAny<string>(), It.IsAny<string>()));
            _userRepositoryMock.Setup(m => m.Get(It.IsAny<string>())).Returns(user);

            new Post(_postRepositoryMock.Object, _userRepositoryMock.Object, user.Username, message).Execute();

            _postRepositoryMock.Verify(m => m.Insert(user.Username, message));
        }
    }
}
