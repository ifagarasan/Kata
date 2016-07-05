using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Date;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class RepositoryShould
    {
        private const string Username = "Alice";
        private const string FollowUsername = "Bob";
        private const string Message1 = "I love the weather today";
        private const string Message2 = "Yezzer, I so do";

        private readonly DateTime _now = DateTime.Now;
        private Mock<IDateProvider> _dateProviderMock;
        private Repository _repository;

        [TestInitialize]
        public void Setup()
        {
            _dateProviderMock = new Mock<IDateProvider>();
            _dateProviderMock.Setup(m => m.Now()).Returns(_now);

            _repository = new Repository(_dateProviderMock.Object);
        }

        [TestMethod]
        public void Insert()
        {
            _repository.Insert(Username, Message1);

            var posts = _repository.RetrieveTimeline(Username);
            var post = posts[0];

            _dateProviderMock.Verify(m => m.Now());

            Assert.AreEqual(Message1, post.Message);
            Assert.AreEqual(_now, post.WrittenAt);
        }

        [TestMethod]
        public void ReturnTimelinePostsInReverseOrder()
        {            
            _repository.Insert(Username, Message1);
            _repository.Insert(Username, Message2);

            var posts = _repository.RetrieveTimeline(Username);

            Assert.AreEqual(Message2, posts[0].Message);
            Assert.AreEqual(Message1, posts[1].Message);
        }

        [TestMethod]
        public void ReturnWallPostsInReverseOrder()
        {
            _repository.Insert(Username, Message1);
            _repository.Insert(Username, Message2);

            var posts = _repository.RetrieveWall(Username);

            Assert.AreEqual(Message2, posts[0].Message);
            Assert.AreEqual(Message1, posts[1].Message);
        }

        [TestMethod]
        public void Follow()
        {
            _repository.Insert(Username, Message1);
            _repository.Insert(FollowUsername, Message2);

            _repository.Follow(Username, FollowUsername);

            var posts = _repository.RetrieveWall(Username);

            Assert.AreEqual(Message2, posts[0].Message);
            Assert.AreEqual(Message1, posts[1].Message);
        }
    }
}
