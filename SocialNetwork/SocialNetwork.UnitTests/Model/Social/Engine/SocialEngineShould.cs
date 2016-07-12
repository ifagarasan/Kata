using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.Social.Engine;
using SocialNetwork.Model.User;

namespace SocialNetwork.UnitTests.Model.Social.Engine
{
    [TestClass]
    public class SocialEngineShould
    {
        private readonly DateTime _now = DateTime.Now;
        private const string Message = "I love the weather today";

        private User _user;
        private User _followUser;

        PostRecord _post1;
        List<PostRecord> _posts;
        Mock<IRepository> _repositoryMock;
        ISocialEngine _socialEngine;
        Mock<IPostFormatter> _postFormatterMock;

        [TestInitialize]
        public void Setup()
        {
            _post1 = new PostRecord(_user, Message, _now);
            _posts = new List<PostRecord> { _post1 };

            _postFormatterMock = new Mock<IPostFormatter>();
            _repositoryMock = new Mock<IRepository>();
            _socialEngine = new SocialEngine(_repositoryMock.Object, _postFormatterMock.Object);

            _user = new User("Alice");
            _followUser = new User("Bob");
        }

        [TestMethod]
        public void InsertPost()
        {
            _repositoryMock.Setup(m => m.Insert(It.IsAny<User>(), It.IsAny<string>()));

            _socialEngine.Post(_user, Message);

            _repositoryMock.Verify(m => m.Insert(_user, Message));
        }

        [TestMethod]
        public void RetrieveTimeline()
        {
            _repositoryMock.Setup(m => m.RetrieveTimeline(It.IsAny<User>())).Returns(_posts);
            _postFormatterMock.Setup(m => m.FormatTimelinePost(It.IsAny<PostRecord>())).Returns(string.Empty);

            var formattedOutput = _socialEngine.RetrieveTimeline(_user);

            _repositoryMock.Verify(m => m.RetrieveTimeline(_user));
            _postFormatterMock.Verify(m => m.FormatTimelinePost(_post1));

            Assert.AreEqual(1, formattedOutput.Count);
        }

        [TestMethod]
        public void RetrieveWall()
        {
            _repositoryMock.Setup(m => m.RetrieveWall(It.IsAny<User>())).Returns(_posts);
            _postFormatterMock.Setup(m => m.FormatWallPost(It.IsAny<PostRecord>())).Returns(string.Empty);

            var formattedOutput = _socialEngine.RetrieveWall(_user);

            _repositoryMock.Verify(m => m.RetrieveWall(_user));
            _postFormatterMock.Verify(m => m.FormatWallPost(_post1));

            Assert.AreEqual(1, formattedOutput.Count);
        }

        [TestMethod]
        public void Follow()
        {
            _repositoryMock.Setup(m => m.Follow(It.IsAny<User>(), It.IsAny<User>()));

            _socialEngine.Follow(_user, _followUser);

            _repositoryMock.Verify(m => m.Follow(_user, _followUser));
        }
    }
}