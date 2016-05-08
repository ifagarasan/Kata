using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro;
using Pomodoro.Cycles;
using System.Collections.Generic;
using Pomodoro.Util;
using Pomodoro.Exceptions;

namespace PomodoroTests.Cycles
{
    [TestClass]
    public class TimeFunctionality
    {
        [TestMethod]
        public void MinutesToMilisecondsReturnsZeroForZero()
        {
            Assert.AreEqual(0, Time.MinutesToMiliseconds(0));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void MinutesToMilisecondsThrowsInvalidInputExceptionForNegativeInput()
        {
            Time.MinutesToMiliseconds(-1);
        }

        [TestMethod]
        public void MinutesToMilisecondsReturnsInputMultipliedBy60000()
        {
            Assert.AreEqual(120000, Time.MinutesToMiliseconds(2));
        }
    }
}
