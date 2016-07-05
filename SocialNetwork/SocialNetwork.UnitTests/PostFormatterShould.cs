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

        [TestInitialize]
        public void Setup()
        {
            _timeOffsetCalculatorMock = new Mock<ITimeOffsetCalculator>();

            _postFormatter = new PostFormatter(_timeOffsetCalculatorMock.Object);
        }

        [TestMethod]
        public void Format()
        {
            var post = new Post("Alice", "I love the weather today", DateTime.Now);

            _timeOffsetCalculatorMock.Setup(m => m.NowToDateOffset(It.IsAny<DateTime>())).Returns(new TimeSpan(0, -3, -1));

            var message = _postFormatter.Format(post);

            _timeOffsetCalculatorMock.Verify(m => m.NowToDateOffset(post.WrittenAt));
           
            Assert.AreEqual($"{post.Message} (4 minutes ago)", message);
        }

        [TestMethod]
        public void UsesSingularForOneMinute()
        {
            var post = new Post("Alice", "I love the weather today", DateTime.Now);

            _timeOffsetCalculatorMock.Setup(m => m.NowToDateOffset(It.IsAny<DateTime>())).Returns(new TimeSpan(0, -1, 0));

            var message = _postFormatter.Format(post);

            _timeOffsetCalculatorMock.Verify(m => m.NowToDateOffset(post.WrittenAt));

            Assert.AreEqual($"{post.Message} (1 minute ago)", message);
        }
    }
}
