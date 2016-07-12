using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.User;
using DisplayTimeline = SocialNetwork.Action.Command.DisplayTimeline;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class DisplayTimelineShould
    {
        private Mock<IPostRepository> _postRepositoryMock;
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
        }

        [TestMethod]
        public void PrintTimeline()
        {
            var username = "test";
            var post = new Post(username, "I'm in London! (1 minute ago)", _now);
            var posts = new List<Post> { post };

            _postRepositoryMock.Setup(m => m.RetrieveTimeline(It.IsAny<string>())).Returns(posts);
            _postFormatterMock.Setup(m => m.FormatTimelinePost(It.IsAny<Post>())).Returns(post.Message);

            new DisplayTimeline(_postRepositoryMock.Object, _postFormatterMock.Object, _consoleMock.Object, post.Username).Execute();

            _postRepositoryMock.Verify(m => m.RetrieveTimeline(post.Username));
            _postFormatterMock.Verify(m => m.FormatTimelinePost(post));
            _consoleMock.Verify(m => m.Write(post.Message));
        }
    }
}
