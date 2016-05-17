using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using System.Collections.Generic;

namespace Pomodoro.Tests.Integration
{
    [TestClass]
    public class PomodoroAcceptance
    {
        [TestMethod]
        public void PomodoroRunsThroughAllPomodoroCyclesAndThenCompletes()
        {
            Runner runner = new Runner(new Builder());

            runner.Start();
            runner.Update(2 * 3600 * 1000);

            Assert.AreEqual(runner.Cycles.Count, runner.CycleIndex);
            Assert.AreEqual(runner.State, RunnerState.Idle);
        }
    }
}
