using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Date;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class RepositoryShould
    {
        readonly string _username = "Alice";
        readonly string _message = "I love the weather today";

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
            _repository.Insert(_username, _message);

            var posts = _repository.RetrieveTimeline(_username);
            var post = posts[0];

            _dateProviderMock.Verify(m => m.Now());

            Assert.AreEqual(_message, post.Message);
            Assert.AreEqual(_now, post.WrittenAt);
        }

        [TestMethod]
        public void ReturnTimelinePostsInReverseOrder()
        {            
            var message2 = "Yezzer, I so do";

            _repository.Insert(_username, _message);
            _repository.Insert(_username, message2);

            var posts = _repository.RetrieveTimeline(_username);

            Assert.AreEqual(message2, posts[0].Message);
            Assert.AreEqual(_message, posts[1].Message);
        }

        [TestMethod]
        public void ReturnWallPostsInReverseOrder()
        {
            var message2 = "Yezzer, I so do";

            _repository.Insert(_username, _message);
            _repository.Insert(_username, message2);

            var posts = _repository.RetrieveWall(_username);

            Assert.AreEqual(message2, posts[0].Message);
            Assert.AreEqual(_message, posts[1].Message);
        }
    }
}
