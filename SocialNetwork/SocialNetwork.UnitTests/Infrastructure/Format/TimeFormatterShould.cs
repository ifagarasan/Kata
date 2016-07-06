using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Infrastructure.Format;

namespace SocialNetwork.UnitTests.Infrastructure.Format
{
    [TestClass]
    public class TimeFormatterShould
    {
        ITimeFormatter _formatter;

        [TestInitialize]
        public void Setup()
        {
            _formatter = new TimeFormatter();
        }

        [TestMethod]
        public void ReturnTimeInMinutes()
        {
            Assert.AreEqual("3 minutes", _formatter.Format(new TimeSpan(0, 3, 0)));
        }

        [TestMethod]
        public void ReturnSingularLiteralForOneMinute()
        {
            Assert.AreEqual("1 minute", _formatter.Format(new TimeSpan(0, 1, 0)));
        }

        [TestMethod]
        public void ReturnTimeInSeconds()
        {
            Assert.AreEqual("3 seconds", _formatter.Format(new TimeSpan(0, 0, 3)));
        }
    }
}