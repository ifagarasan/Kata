using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using System.Collections.Generic;

namespace Pomodoro.Tests.Integration
{
    [TestClass]
    public class PomodoroAcceptance
    {
        private Builder _builder;
        private Runner _runner; 

        [TestInitialize]
        public void Setup()
        {
            _builder = new Builder();
            _runner = new Runner(_builder);
        }

        [TestMethod]
        public void PomodoroRunsThroughAllPomodoroCyclesAndThenCompletes()
        {
            _runner.Start();
            _runner.Update(2 * 3600 * 1000);

            Assert.AreEqual(_runner.Cycles.Count, _runner.CycleIndex);
            Assert.AreEqual(_runner.State, RunnerState.Idle);
        }

        [TestMethod]
        public void PomodoroIsAbleToRestartAfterItFinishes()
        {
            _runner.Start();
            _runner.Update(2 * 3600 * 1000 + 3);

            _runner.Start();

            Assert.AreEqual(0u, _runner.CurrentCycleTime);
            Assert.AreEqual(0, _runner.CycleIndex);
        }
    }
}
