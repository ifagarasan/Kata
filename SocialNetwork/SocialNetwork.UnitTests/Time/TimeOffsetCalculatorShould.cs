using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;
using SocialNetwork.Date;
using SocialNetwork.Time;

namespace SocialNetwork.UnitTests.Time
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

            var current = now.AddMinutes(-2);

            var timeOffsetCalculator = new TimeOffsetCalculator(mockDateProvider.Object);

            Assert.AreEqual(-2, timeOffsetCalculator.NowToDateOffset(current).TotalMinutes);
        }
    }
}
