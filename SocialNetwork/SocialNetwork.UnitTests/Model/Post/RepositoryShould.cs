using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Model.User;

namespace SocialNetwork.UnitTests.Model.Post
{
    [TestClass]
    public class RepositoryShould
    {
        private const string Message1 = "I love the weather today";
        private const string Message2 = "Yezzer, I so do";

        private readonly DateTime _now = DateTime.Now;
        private Mock<IDateProvider> _dateProviderMock;
        private Repository _repository;

        private User _user;
        private User _userToFollow;

        [TestInitialize]
        public void Setup()
        {
            _dateProviderMock = new Mock<IDateProvider>();
            _dateProviderMock.Setup(m => m.Now()).Returns(_now);

            _repository = new Repository(_dateProviderMock.Object);

            _user = new User("Alice");
            _userToFollow = new User("Bob");
        }

        [TestMethod]
        public void Insert()
        {
            _repository.Insert(_user, Message1);

            var posts = _repository.RetrieveTimeline(_user);
            var post = posts[0];

            _dateProviderMock.Verify(m => m.Now());

            Assert.AreEqual(Message1, post.Message);
            Assert.AreEqual(_now, post.WrittenAt);
        }

        [TestMethod]
        public void ReturnTimelinePostsInReverseOrder()
        {            
            _repository.Insert(_user, Message1);
            _repository.Insert(_user, Message2);

            var posts = _repository.RetrieveTimeline(_user);

            Assert.AreEqual(Message2, posts[0].Message);
            Assert.AreEqual(Message1, posts[1].Message);
        }

        [TestMethod]
        public void ReturnWallPostsInReverseOrder()
        {
            _repository.Insert(_user, Message1);
            _repository.Insert(_user, Message2);

            var posts = _repository.RetrieveWall(_user);

            Assert.AreEqual(Message2, posts[0].Message);
            Assert.AreEqual(Message1, posts[1].Message);
        }

        [TestMethod]
        public void Follow()
        {
            _repository.Insert(_user, Message1);
            _repository.Insert(_userToFollow, Message2);

            _repository.Follow(_user, _userToFollow);

            var posts = _repository.RetrieveWall(_user);

            Assert.AreEqual(Message2, posts[0].Message);
            Assert.AreEqual(Message1, posts[1].Message);
        }
    }
}
