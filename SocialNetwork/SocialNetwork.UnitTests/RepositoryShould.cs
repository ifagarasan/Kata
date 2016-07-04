using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Date;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class RepositoryShould
    {
        [TestMethod]
        public void Insert()
        {
            var username = "Alice";
            var message = "I love the weather today";

            var now = DateTime.Now;
            var dateProviderMock = new Mock<IDateProvider>();
            dateProviderMock.Setup(m => m.Now()).Returns(now);

            var repository = new Repository(dateProviderMock.Object);

            repository.Insert(username, message);

            var posts = repository.RetrieveUserMessages(username);
            var post = posts[0];

            dateProviderMock.Verify(m => m.Now());

            Assert.AreEqual(message, post.Message);
            Assert.AreEqual(now, post.WrittenAt);
        }
    }
}
