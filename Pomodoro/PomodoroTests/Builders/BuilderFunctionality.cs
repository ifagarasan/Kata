using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro;
using Pomodoro.Cycles;
using System.Collections.Generic;

namespace PomodoroTests.Cycles
{
    [TestClass]
    public class BuilderFunctionality
    {
        Builder builder = new Builder();
        List<ICycle> result;

        [TestInitialize]
        public void Setup()
        {
            result = builder.Build();
        }

        [TestMethod]
        public void BuilderReturnsAListOfEightElements()
        {
            Assert.AreEqual(8, result.Count);
        }

        [TestMethod]
        public void BuilderReturnsAListWithFourPomodoroCyclesAtEvenPositions()
        {
            for (int i = 0; i < 7; i += 2)
                Assert.IsInstanceOfType(result[i], typeof(Pomodoro.Cycles.Pomodoro));
        }

        [TestMethod]
        public void BuilderReturnsAListWithShortPausesInTheFirstThreeOddPositions()
        {
            for (int i = 1; i < 6; i += 2)
                Assert.IsInstanceOfType(result[i], typeof(ShortPause));
        }

        [TestMethod]
        public void BuilderReturnsAListWithLastItemALongPause()
        {
            Assert.IsInstanceOfType(result[7], typeof(LongPause));
        }
    }
}
