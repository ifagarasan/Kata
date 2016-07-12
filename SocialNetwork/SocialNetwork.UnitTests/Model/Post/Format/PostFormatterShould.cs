using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Format;
using SocialNetwork.Infrastructure.Time;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.User;

namespace SocialNetwork.UnitTests.Model.Post.Format
{
    [TestClass]
    public class PostFormatterShould
    {
        Mock<ITimeOffsetCalculator> _timeOffsetCalculatorMock;
        PostFormatter _postFormatter;
        private Mock<ITimeFormatter> _timeFormatterMock;
        private PostRecord _postRecord;

        [TestInitialize]
        public void Setup()
        {
            _postRecord = new PostRecord(new User("Alice"), "I love the weather today", DateTime.Now);

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

            var message = _postFormatter.FormatTimelinePost(_postRecord);

            _timeOffsetCalculatorMock.Verify(m => m.NowToDateOffset(_postRecord.WrittenAt));
            _timeFormatterMock.Verify(m => m.Format(timeSpan));
           
            Assert.AreEqual($"{_postRecord.Message} ({time} ago)", message);
        }

        [TestMethod]
        public void FormatWallMessage()
        {
            var time = "4 minutes";
            var timeSpan = new TimeSpan(0, -3, -1);

            _timeFormatterMock.Setup(m => m.Format(It.IsAny<TimeSpan>())).Returns(time);
            _timeOffsetCalculatorMock.Setup(m => m.NowToDateOffset(It.IsAny<DateTime>())).Returns(timeSpan);

            var message = _postFormatter.FormatWallPost(_postRecord);

            _timeOffsetCalculatorMock.Verify(m => m.NowToDateOffset(_postRecord.WrittenAt));
            _timeFormatterMock.Verify(m => m.Format(timeSpan));

            Assert.AreEqual($"{_postRecord.User.Username} - {_postRecord.Message} ({time} ago)", message);
        }
    }
}
