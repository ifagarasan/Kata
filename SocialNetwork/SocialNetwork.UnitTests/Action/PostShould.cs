using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Action.Command;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.User;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class PostShould
    {
        private Mock<IRepository> _repositoryMock;
        private Mock<IConsole> _consoleMock;

        [TestInitialize]
        public void Setup()
        {
            _consoleMock = new Mock<IConsole>();
            _consoleMock.Setup(m => m.Write(It.IsAny<string>()));

            _repositoryMock = new Mock<IRepository>();
        }

        [TestMethod]
        public void Insert()
        {
            _repositoryMock.Setup(m => m.Insert(It.IsAny<User>(), It.IsAny<string>()));

            var user = new User("test");
            var message = "content";

            new Post(_repositoryMock.Object, user, message).Execute();

            _repositoryMock.Verify(m => m.Insert(user, message));
        }
    }
}
