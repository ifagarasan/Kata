using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro;
using Pomodoro.Cycles;
using Pomodoro.Util;

namespace PomodoroTests.Cycles
{
    [TestClass]
    public class LongPauseFunctionality : CycleFunctionality
    {
        protected override ICycle BuildCycle()
        {
            return new LongPause();
        }

        #region Initialisation

        [TestMethod]
        public void TestLabelIsLongPause()
        {
            TestLabel("Long Pause");
        }

        [TestMethod]
        public void TestDurationIs15()
        {
            TestDuration(Time.MinutesToMiliseconds(15));
        }

        #endregion
    }
}
