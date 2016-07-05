using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Format;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class SocialEngineShould
    {
        private readonly DateTime _now = DateTime.Now;
        private const string Username = "Alice";
        private const string FollowUsername = "Bob";
        private const string Message = "I love the weather today";

        Post _post1;
        List<IPost> _posts;
        Mock<IRepository> _repositoryMock;
        ISocialEngine _socialEngine;
        Mock<IPostFormatter> _postFormatterMock;

        [TestInitialize]
        public void Setup()
        {
            _post1 = new Post(Username, Message, _now);
            _posts = new List<IPost> { _post1 };

            _postFormatterMock = new Mock<IPostFormatter>();
            _repositoryMock = new Mock<IRepository>();
            _socialEngine = new SocialEngine(_repositoryMock.Object, _postFormatterMock.Object);
        }

        [TestMethod]
        public void InsertPost()
        {
            _repositoryMock.Setup(m => m.Insert(It.IsAny<string>(), It.IsAny<string>()));

            _socialEngine.Post(Username, Message);

            _repositoryMock.Verify(m => m.Insert(Username, Message));
        }

        [TestMethod]
        public void RetrieveTimeline()
        {
            _repositoryMock.Setup(m => m.RetrieveTimeline(It.IsAny<string>())).Returns(_posts);
            _postFormatterMock.Setup(m => m.FormatTimelinePost(It.IsAny<IPost>())).Returns(string.Empty);

            var formattedOutput = _socialEngine.RetrieveTimeline(Username);

            _repositoryMock.Verify(m => m.RetrieveTimeline(Username));
            _postFormatterMock.Verify(m => m.FormatTimelinePost(_post1));

            Assert.AreEqual(1, formattedOutput.Count);
        }

        [TestMethod]
        public void RetrieveWall()
        {
            _repositoryMock.Setup(m => m.RetrieveWall(It.IsAny<string>())).Returns(_posts);
            _postFormatterMock.Setup(m => m.FormatWallPost(It.IsAny<IPost>())).Returns(string.Empty);

            var formattedOutput = _socialEngine.RetrieveWall(Username);

            _repositoryMock.Verify(m => m.RetrieveWall(Username));
            _postFormatterMock.Verify(m => m.FormatWallPost(_post1));

            Assert.AreEqual(1, formattedOutput.Count);
        }

        [TestMethod]
        public void Follow()
        {
            _repositoryMock.Setup(m => m.Follow(It.IsAny<string>(), It.IsAny<string>()));

            _socialEngine.Follow(Username, FollowUsername);

            _repositoryMock.Verify(m => m.Follow(Username, FollowUsername));
        }
    }
}