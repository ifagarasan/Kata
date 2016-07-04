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

        [TestMethod]
        public void Insert()
        {
            var message = "I love the weather today";

            var now = DateTime.Now;
            var dateProviderMock = new Mock<IDateProvider>();
            dateProviderMock.Setup(m => m.Now()).Returns(now);

            var repository = new Repository(dateProviderMock.Object);

            repository.Insert(_username, message);

            var posts = repository.RetrieveUserMessages(_username);
            var post = posts[0];

            dateProviderMock.Verify(m => m.Now());

            Assert.AreEqual(message, post.Message);
            Assert.AreEqual(now, post.WrittenAt);
        }

        [TestMethod]
        public void ReturnPostsInReverseOrder()
        {            
            var message1 = "I love the weather today";
            var message2 = "Yezzer, I so do";

            var now = DateTime.Now;
            var dateProviderMock = new Mock<IDateProvider>();
            dateProviderMock.Setup(m => m.Now()).Returns(now);

            var repository = new Repository(dateProviderMock.Object);

            repository.Insert(_username, message1);
            repository.Insert(_username, message2);

            var posts = repository.RetrieveUserMessages(_username);

            Assert.AreEqual(message2, posts[0].Message);
            Assert.AreEqual(message1, posts[1].Message);
        }
    }
}
