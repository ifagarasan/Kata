using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class SocialEngineShould
    {
        readonly string _username = "Alice";
        Mock<IRepository> _repositoryMock;
        ISocialEngine _socialEngine;
        Mock<IPostFormatter> _postFormatterMock;

        [TestInitialize]
        public void Setup()
        {
            _postFormatterMock = new Mock<IPostFormatter>();
            _repositoryMock = new Mock<IRepository>();
            _socialEngine = new SocialEngine(_repositoryMock.Object, _postFormatterMock.Object);
        }

        [TestMethod]
        public void InsertPost()
        {
            var message = "I love the weather today";

            _repositoryMock.Setup(m => m.Insert(It.IsAny<string>(), It.IsAny<string>()));

            _socialEngine.Post(_username, message);

            _repositoryMock.Verify(m => m.Insert(_username, message));
        }

        [TestMethod]
        public void RetrieveUserMessages()
        {
            var now = DateTime.Now;
            
            var post1 = new Post(_username, "message 1", now);
            var post2 = new Post(_username, "message 2", now);

            var posts = new List<IPost> { post1, post2 };

            _repositoryMock.Setup(m => m.RetrieveUserMessages(It.IsAny<string>())).Returns(posts);

            _postFormatterMock.Setup(m => m.Format(It.IsAny<IPost>())).Returns(string.Empty);

            var formattedOutput = _socialEngine.RetrieveTimeline(_username);

            _repositoryMock.Verify(m => m.RetrieveUserMessages(_username));
            _postFormatterMock.Verify(m => m.Format(post1));
            _postFormatterMock.Verify(m => m.Format(post2));

            Assert.AreEqual(2, formattedOutput.Count);
        }
    }
}
