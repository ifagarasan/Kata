using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.User;
using Post = SocialNetwork.Action.Command.Post;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class PostShould
    {
        [TestMethod]
        public void Insert()
        {
            var user = new User("test");
            var message = "content";
            var postRepositoryMock = new Mock<IPostRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var consoleMock = new Mock<IConsole>();

            consoleMock.Setup(m => m.Write(It.IsAny<string>()));

            postRepositoryMock.Setup(m => m.Insert(It.IsAny<string>(), It.IsAny<string>()));
            userRepositoryMock.Setup(m => m.Get(It.IsAny<string>())).Returns(user);

            new Post(postRepositoryMock.Object, userRepositoryMock.Object, user.Username, message).Execute();

            postRepositoryMock.Verify(m => m.Insert(user.Username, message));
        }
    }
}
