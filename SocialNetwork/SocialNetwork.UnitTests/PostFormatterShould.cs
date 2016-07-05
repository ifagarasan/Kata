using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Time;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class PostFormatterShould
    {
        Mock<ITimeOffsetCalculator> _timeOffsetCalculatorMock;
        PostFormatter _postFormatter;
        private Post _post;

        [TestInitialize]
        public void Setup()
        {
            _post = new Post("Alice", "I love the weather today", DateTime.Now);

            _timeOffsetCalculatorMock = new Mock<ITimeOffsetCalculator>();

            _postFormatter = new PostFormatter(_timeOffsetCalculatorMock.Object);
        }

        [TestMethod]
        public void FormatTimelineMessage()
        {          
            _timeOffsetCalculatorMock.Setup(m => m.NowToDateOffset(It.IsAny<DateTime>())).Returns(new TimeSpan(0, -3, -1));

            var message = _postFormatter.FormatTimelinePost(_post);

            _timeOffsetCalculatorMock.Verify(m => m.NowToDateOffset(_post.WrittenAt));
           
            Assert.AreEqual($"{_post.Message} (4 minutes ago)", message);
        }

        [TestMethod]
        public void UsesSingularForOneMinute()
        {
            _timeOffsetCalculatorMock.Setup(m => m.NowToDateOffset(It.IsAny<DateTime>())).Returns(new TimeSpan(0, -1, 0));

            var message = _postFormatter.FormatTimelinePost(_post);

            _timeOffsetCalculatorMock.Verify(m => m.NowToDateOffset(_post.WrittenAt));

            Assert.AreEqual($"{_post.Message} (1 minute ago)", message);
        }

        [TestMethod]
        public void FormatWallMessage()
        {
            _timeOffsetCalculatorMock.Setup(m => m.NowToDateOffset(It.IsAny<DateTime>())).Returns(new TimeSpan(0, -3, -1));

            var message = _postFormatter.FormatWallPost(_post);

            _timeOffsetCalculatorMock.Verify(m => m.NowToDateOffset(_post.WrittenAt));

            Assert.AreEqual($"{_post.Username} - {_post.Message} (4 minutes ago)", message);
        }
    }
}
