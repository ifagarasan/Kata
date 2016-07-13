using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Model.Post.Format;

namespace SocialNetwork.UnitTests.Model.Post.Format
{
    [TestClass]
    public class WallPostFormatterShould
    {
        [TestMethod]
        public void FormatTimelineMessage()
        {
            var formattedTime = "(1 minute ago)";
            var postTimeFormatterMock = new Mock<IPostFormatter>();
            postTimeFormatterMock.Setup(m => m.Format(It.IsAny<SocialNetwork.Model.Post.Post>())).Returns(formattedTime);

            var wallPostFormatter = new WallPostFormatter(postTimeFormatterMock.Object);

            var post = new SocialNetwork.Model.Post.Post("Alice", "I love the weather today", DateTime.Now);

            var message = wallPostFormatter.Format(post);


            Assert.AreEqual($"{post.Username} - {post.Message} {formattedTime}", message);
        }
    }
}
