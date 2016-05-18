using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Pomodoro.Exceptions;

namespace Pomodoro.Tests
{
    [TestClass]
    public class PomodoroFunctionality
    {
        Runner _runner;
        Mock<IBuilder> _mockBuilder;
        List<ICycle> _cycleList;

        [TestInitialize]
        public void Setup()
        {
            _mockBuilder = new Mock<IBuilder>();

            _cycleList = new List<ICycle>() { new Cycle("Test 1", 10), new Cycle("Test 2", 20), new Cycle("Test 3", 30) }; 

            _mockBuilder.Setup(m => m.Build()).Returns(_cycleList);

            _runner = new Runner(_mockBuilder.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsArgumentExceptionIfBuildIsNul()
        {
            _runner = new Runner(null);
        }

        [TestMethod]
        public void CallsBuildOnIBuilderAndSetsResultAsCycles()
        {
            _runner = new Runner(_mockBuilder.Object);

            _mockBuilder.Verify(m => m.Build());

            Assert.AreEqual(3, _runner.Cycles.Count);

            for (int i = 0; i < _cycleList.Count; ++i)
                Assert.AreEqual(_cycleList[i], _runner.Cycles[i]);
        }

        [TestMethod]
        public void CycleIndexIsMinusOneByDefault()
        {
            Assert.AreEqual(-1, _runner.CycleIndex);
        }

        [TestMethod]
        public void StartSetsStateToRunning()
        {
            _runner.Start();

            Assert.AreEqual(RunnerState.Running, _runner.State);
        }

        [TestMethod]
        public void StartSetsCycleIndexToZero()
        {
            _runner.Start();

            Assert.AreEqual(0, _runner.CycleIndex);
        }

        [TestMethod]
        public void StartSetsCurrentCycleTimeToZero()
        {
            _runner.Start();
            _runner.Update(3);
            _runner.Start();

            Assert.AreEqual(0u, _runner.CurrentCycleTime);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateException))]
        public void UpdateThrowsInvalidStateExceptionIfStateIsNotRunning()
        {
            _runner.Update(1);
        }

        [TestMethod]
        public void UpdateIncrementsCurrentCycleTimeBySpecifiedValue()
        {
            _runner.Start();

            uint expected = 5;
            _runner.Update(expected);

            Assert.AreEqual(expected, _runner.CurrentCycleTime);
        }

        [TestMethod]
        public void UpdateIncrementsCurrentCycleIndexIfCurrentCycleTimeIsLargerOrEqualToCurrentIndexCycleTime()
        {
            _runner.Start();

            _runner.Update(10);

            Assert.AreEqual(1, _runner.CycleIndex);
        }

        [TestMethod]
        public void UpdateSetsCurrentCycleTimeAfterCycleIndexIncrementToOverlowOffset()
        {
            _runner.Start();

            _runner.Update(15);

            Assert.AreEqual(5u, _runner.CurrentCycleTime);
        }

        [TestMethod]
        public void UpdateAdvancesMultipleCyclesIfValueIsLargerThanOneCycleDuration()
        {
            _runner.Start();

            _runner.Update(30);

            Assert.AreEqual(2, _runner.CycleIndex);
        }

        [TestMethod]
        public void UpdateSetsStateToIdleAndKeepsTimeOffsetAsCurrentCycleTimeAndCycleIndexCyclesCountIfIndexOverflows()
        {
            _runner.Start();

            _runner.Update(60);

            Assert.AreEqual(RunnerState.Idle, _runner.State);
            Assert.AreEqual(_runner.Cycles.Count, _runner.CycleIndex);
            Assert.AreEqual(0u, _runner.CurrentCycleTime);
        }
    }
}
