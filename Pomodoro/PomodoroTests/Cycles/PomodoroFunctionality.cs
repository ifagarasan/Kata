using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro;
using Pomodoro.Cycles;
using Pomodoro.Util;

namespace PomodoroTests.Cycles
{
    [TestClass]
    public class PomodoroFunctionality: CycleFunctionality
    {
        protected override ICycle BuildCycle()
        {
            return new Pomodoro.Cycles.Pomodoro();
        }

        #region Initialisation

        [TestMethod]
        public void TestLabelIsPomodoro()
        {
            TestLabel("Pomodoro");
        }

        [TestMethod]
        public void TestDurationIs25()
        {
            TestDuration(Time.MinutesToMiliseconds(25));
        }

        #endregion
    }
}
