using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Model.Post.Format;

namespace SocialNetwork.UnitTests.Model.Post.Format
{
    [TestClass]
    public class TimelinePostFormatterShould
    {
        [TestMethod]
        public void FormatTimelineMessage()
        {
            var formattedTime = "(1 minute ago)";
            var postTimeFormatterMock = new Mock<IPostFormatter>();
            postTimeFormatterMock.Setup(m => m.Format(It.IsAny<SocialNetwork.Model.Post.Post>())).Returns(formattedTime);

            var timelinePostFormatter = new TimelinePostFormatter(postTimeFormatterMock.Object);

            var post = new SocialNetwork.Model.Post.Post("Alice", "I love the weather today", DateTime.Now);

            var message = timelinePostFormatter.Format(post);

            
            Assert.AreEqual($"{post.Message} {formattedTime}", message);
        }
    }
}
