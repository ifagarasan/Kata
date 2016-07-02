using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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

            var repository = new Repository();

            repository.Insert(username, message);

            var posts = repository.Get(username);

            Assert.AreEqual(message, posts[0]);
        }
    }
}
