using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Infrastructure.Time;

namespace SocialNetwork.UnitTests.Infrastructure.Time
{
    [TestClass]
    public class TimeOffsetCalculatorShould
    {
        [TestMethod]
        public void ReturnNegativeAmountIfDateIsInThePast()
        {
            var mockDateProvider = new Mock<IDateProvider>();

            var now = DateTime.Now;

            mockDateProvider.Setup(m => m.Now()).Returns(now);

            var current = now.AddMinutes(-5);

            var timeOffsetCalculator = new TimeOffsetCalculator(mockDateProvider.Object);

            Assert.AreEqual(-5, timeOffsetCalculator.NowToDateOffset(current).TotalMinutes);
        }
    }
}
