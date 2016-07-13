using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Format;
using SocialNetwork.Infrastructure.Time;
using SocialNetwork.Model.Post.Format;

namespace SocialNetwork.UnitTests.Model.Post.Format
{
    [TestClass]
    public class PostTimeFormatterShould
    {
        [TestMethod]
        public void Format()
        {
            var timeOffsetCalculatorMock = new Mock<ITimeOffsetCalculator>();
            var timeFormatterMock = new Mock<ITimeFormatter>();
            var postTimeFormatter = new PostTimeFormatter(timeOffsetCalculatorMock.Object, timeFormatterMock.Object);

            var post = new SocialNetwork.Model.Post.Post("Alice", "I love the weather today", DateTime.Now);

            var time = "4 minutes";
            var timeSpan = new TimeSpan(0, -3, -1);

            timeFormatterMock.Setup(m => m.Format(It.IsAny<TimeSpan>())).Returns(time);
            timeOffsetCalculatorMock.Setup(m => m.NowToDateOffset(It.IsAny<DateTime>())).Returns(timeSpan);

            var formtted = postTimeFormatter.Format(post);

            timeOffsetCalculatorMock.Verify(m => m.NowToDateOffset(post.WrittenAt));
            timeFormatterMock.Verify(m => m.Format(timeSpan));
           
            Assert.AreEqual($"({time} ago)", formtted);
        }
    }
}
