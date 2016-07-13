using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Model.User;

namespace SocialNetwork.UnitTests.Infrastructure.Repository
{
    [TestClass]
    public class PostRepositoryShould
    {
        private const string Message1 = "I love the weather today";
        private const string Message2 = "Yezzer, I so do";

        private readonly DateTime _now = DateTime.Now;
        private Mock<IDateProvider> _dateProviderMock;
        private SocialNetwork.Infrastructure.Repository.PostRepository _postRepository;

        private User _user;

        [TestInitialize]
        public void Setup()
        {
            _user = new User("Alice");

            _dateProviderMock = new Mock<IDateProvider>();
            _dateProviderMock.Setup(m => m.Now()).Returns(_now);

            _postRepository = new SocialNetwork.Infrastructure.Repository.PostRepository(_dateProviderMock.Object);

            _postRepository.Insert(_user.Username, Message1);
            _postRepository.Insert(_user.Username, Message2);
        }

        [TestMethod]
        public void ReturnTimelinePostsInReverseOrder()
        {            
            var posts = _postRepository.RetrieveTimeline(_user.Username);

            Assert.AreEqual(Message2, posts[0].Message);
            Assert.AreEqual(Message1, posts[1].Message);
        }

        [TestMethod]
        public void ReturnWallPostsInReverseOrder()
        {
            var posts = _postRepository.RetrieveWall(_user);

            Assert.AreEqual(Message2, posts[0].Message);
            Assert.AreEqual(Message1, posts[1].Message);
        }
    }
}
