using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro;
using Pomodoro.Cycles;

namespace PomodoroTests.Cycles
{
    [TestClass]
    public abstract class CycleFunctionality
    {
        protected ICycle cycle;

        [TestInitialize]
        public virtual void Setup()
        {
            cycle = BuildCycle();
        }

        protected abstract ICycle BuildCycle();

        #region Initialisation

        protected void TestLabel(string expected)
        {
            Assert.AreEqual(expected, cycle.Label);
        }

        protected void TestDuration(long expected)
        {
            Assert.AreEqual(expected, cycle.Duration);
        }

        #endregion
    }
}
