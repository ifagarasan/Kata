using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.User;
using DisplayWall = SocialNetwork.Action.Command.DisplayWall;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class DisplayWallShould
    {
        private Mock<IPostRepository> _postRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IPostFormatter> _postFormatterMock;
        private Mock<IConsole> _consoleMock;
        private readonly DateTime _now = DateTime.Now;

        [TestInitialize]
        public void Setup()
        {
            _consoleMock = new Mock<IConsole>();
            _consoleMock.Setup(m => m.Write(It.IsAny<string>()));

            _postRepositoryMock = new Mock<IPostRepository>();
            _postFormatterMock = new Mock<IPostFormatter>();
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [TestMethod]
        public void PrintWall()
        {
            var user = new User("test");
            var post = new Post(user.Username, "I'm in London! (1 minute ago)", _now);
            var posts = new List<Post> { post };

            _postRepositoryMock.Setup(m => m.RetrieveWall(It.IsAny<User>())).Returns(posts);
            _postFormatterMock.Setup(m => m.FormatWallPost(It.IsAny<Post>())).Returns(post.Message);
            _userRepositoryMock.Setup(m => m.Get(It.IsAny<string>())).Returns(user);

            new DisplayWall(_postRepositoryMock.Object, _userRepositoryMock.Object, _postFormatterMock.Object, _consoleMock.Object, post.Username).Execute();

            _postRepositoryMock.Verify(m => m.RetrieveWall(user));
            _postFormatterMock.Verify(m => m.FormatWallPost(post));
            _consoleMock.Verify(m => m.Write(post.Message));
        }
    }
}
