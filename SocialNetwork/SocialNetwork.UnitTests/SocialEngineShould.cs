using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class SocialEngineShould
    {
        [TestMethod]
        public void InsertPost()
        {
            var username = "Alice";
            var message = "I love the weather today";

            Mock<IRepository> repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(m => m.Insert(It.IsAny<string>(), It.IsAny<string>()));

            ISocialEngine socialEngine = new SocialEngine(repositoryMock.Object);

            socialEngine.Post(username, message);

            repositoryMock.Verify(m => m.Insert(username, message));
        }
    }
}
