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
        private Mock<IRepository> _repositoryMock;
        private Mock<IPostFormatter> _postFormatterMock;
        private Mock<IConsole> _consoleMock;
        private readonly DateTime _now = DateTime.Now;

        [TestInitialize]
        public void Setup()
        {
            _consoleMock = new Mock<IConsole>();
            _consoleMock.Setup(m => m.Write(It.IsAny<string>()));

            _repositoryMock = new Mock<IRepository>();
            _postFormatterMock = new Mock<IPostFormatter>();
        }

        [TestMethod]
        public void PrintWall()
        {
            var post = new PostRecord(new User("test"), "I'm in London! (1 minute ago)", _now);
            var posts = new List<PostRecord> { post };

            _repositoryMock.Setup(m => m.RetrieveWall(It.IsAny<User>())).Returns(posts);
            _postFormatterMock.Setup(m => m.FormatWallPost(It.IsAny<PostRecord>())).Returns(post.Message);

            new DisplayWall(_repositoryMock.Object, _postFormatterMock.Object, _consoleMock.Object, post.User).Execute();

            _repositoryMock.Verify(m => m.RetrieveWall(post.User));
            _postFormatterMock.Verify(m => m.FormatWallPost(post));
            _consoleMock.Verify(m => m.Write(post.Message));
        }
    }
}
