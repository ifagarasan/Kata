﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Time;

namespace SocialNetwork.UnitTests
{
    [TestClass]
    public class PostFormatterShould
    {
        [TestMethod]
        public void Format()
        {
            var post = new Post("Alice", "I love the weather today", DateTime.Now);

            var timeOffsetCalculatorMock = new Mock<ITimeOffsetCalculator>();
            timeOffsetCalculatorMock.Setup(m => m.NowToDateOffset(It.IsAny<DateTime>())).Returns(new TimeSpan(0, -3, 0));

            var postFormatter = new PostFormatter(timeOffsetCalculatorMock.Object);
            var message = postFormatter.Format(post);

            timeOffsetCalculatorMock.Verify(m => m.NowToDateOffset(post.WrittenAt));
           
            Assert.AreEqual($"{post.Message} (3 minutes ago)", message);
        }
    }
}
