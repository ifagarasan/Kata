using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Action.Format;
using SocialNetwork.Infrastructure.Format;
using SocialNetwork.Infrastructure.Time;
using SocialNetwork.Model;

namespace SocialNetwork.UnitTests.Action.Format
{
    [TestClass]
    public class PostFormatterShould
    {
        Mock<ITimeOffsetCalculator> _timeOffsetCalculatorMock;
        PostFormatter _postFormatter;
        private Mock<ITimeFormatter> _timeFormatterMock;
        private Post _post;

        [TestInitialize]
        public void Setup()
        {
            _post = new Post("Alice", "I love the weather today", DateTime.Now);

            _timeOffsetCalculatorMock = new Mock<ITimeOffsetCalculator>();
            _timeFormatterMock = new Mock<ITimeFormatter>();

            _postFormatter = new PostFormatter(_timeOffsetCalculatorMock.Object, _timeFormatterMock.Object);
        }

        [TestMethod]
        public void FormatTimelineMessage()
        {
            var time = "4 minutes";
            var timeSpan = new TimeSpan(0, -3, -1);

            _timeFormatterMock.Setup(m => m.Format(It.IsAny<TimeSpan>())).Returns(time);
            _timeOffsetCalculatorMock.Setup(m => m.NowToDateOffset(It.IsAny<DateTime>())).Returns(timeSpan);

            var message = _postFormatter.FormatTimelinePost(_post);

            _timeOffsetCalculatorMock.Verify(m => m.NowToDateOffset(_post.WrittenAt));
            _timeFormatterMock.Verify(m => m.Format(timeSpan));
           
            Assert.AreEqual($"{_post.Message} ({time} ago)", message);
        }

        [TestMethod]
        public void FormatWallMessage()
        {
            var time = "4 minutes";
            var timeSpan = new TimeSpan(0, -3, -1);

            _timeFormatterMock.Setup(m => m.Format(It.IsAny<TimeSpan>())).Returns(time);
            _timeOffsetCalculatorMock.Setup(m => m.NowToDateOffset(It.IsAny<DateTime>())).Returns(timeSpan);

            var message = _postFormatter.FormatWallPost(_post);

            _timeOffsetCalculatorMock.Verify(m => m.NowToDateOffset(_post.WrittenAt));
            _timeFormatterMock.Verify(m => m.Format(timeSpan));

            Assert.AreEqual($"{_post.Username} - {_post.Message} ({time} ago)", message);
        }
    }
}
