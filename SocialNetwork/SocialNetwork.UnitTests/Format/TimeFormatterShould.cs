using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Format;
using SocialNetwork.Time;

namespace SocialNetwork.UnitTests.Format
{
    [TestClass]
    public class TimeFormatterShould
    {
        [TestMethod]
        public void ReturnTimeInMinutes()
        {
            ITimeFormatter formatter = new TimeFormatter();

            Assert.AreEqual("3 minutes", formatter.Format(new TimeSpan(0, 3, 0)));
        }

        [TestMethod]
        public void ReturnSingularLiteralForOneMinute()
        {
            ITimeFormatter formatter = new TimeFormatter();

            Assert.AreEqual("1 minute", formatter.Format(new TimeSpan(0, 1, 0)));
        }
    }
}