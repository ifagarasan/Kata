using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro;
using Pomodoro.Cycles;
using Pomodoro.Util;

namespace PomodoroTests.Cycles
{
    [TestClass]
    public class ShortPauseFunctionality : CycleFunctionality
    {
        protected override ICycle BuildCycle()
        {
            return new ShortPause();
        }

        #region Initialisation

        [TestMethod]
        public void TestLabelIsShortPause()
        {
            TestLabel("Short Pause");
        }

        [TestMethod]
        public void TestDurationIs5()
        {
            TestDuration(Time.MinutesToMiliseconds(5));
        }

        #endregion
    }
}
