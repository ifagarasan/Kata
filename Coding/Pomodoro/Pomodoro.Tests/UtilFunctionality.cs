using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Pomodoro.Exceptions;

namespace Pomodoro.Tests
{
    [TestClass]
    public class UtilFunctionality
    {
        [TestMethod]
        public void MinutesToMilisecondsReturnsValueMultipliedBy60000()
        {
            uint minutes = 10;
            Assert.AreEqual(60000*minutes, Util.MinutesToMiliseconds(minutes));
        }
    }
}
