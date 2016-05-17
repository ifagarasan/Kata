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
        Runner runner;
        Mock<IBuilder> mockBuilder;
        List<ICycle> cycleList;

        [TestInitialize]
        public void Setup()
        {
            mockBuilder = new Mock<IBuilder>();

            cycleList = new List<ICycle>() { new Cycle("Test 1", 10), new Cycle("Test 2", 20), new Cycle("Test 3", 30) }; 

            mockBuilder.Setup(m => m.Build()).Returns(cycleList);

            runner = new Runner(mockBuilder.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsArgumentExceptionIfBuildIsNul()
        {
            Runner runner = new Runner(null);
        }

        [TestMethod]
        public void CallsBuildOnIBuilderAndSetsResultAsCycles()
        {
            runner = new Runner(mockBuilder.Object);

            mockBuilder.Verify(m => m.Build());

            Assert.AreEqual(3, runner.Cycles.Count);

            for (int i = 0; i < cycleList.Count; ++i)
                Assert.AreEqual(cycleList[i], runner.Cycles[i]);
        }

        [TestMethod]
        public void CycleIndexIsMinusOneByDefault()
        {
            Assert.AreEqual(-1, runner.CycleIndex);
        }

        [TestMethod]
        public void StartSetsStateToRunning()
        {
            runner.Start();

            Assert.AreEqual(RunnerState.Running, runner.State);
        }

        [TestMethod]
        public void StartSetsCycleIndexToZero()
        {
            runner.Start();

            Assert.AreEqual(0, runner.CycleIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTimeOffsetException))]
        public void UpdateThrowsInvalidTimeOffsetExceptionIfValueIsNegative()
        {
            runner.Start();
            runner.Update(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateException))]
        public void UpdateThrowsInvalidStateExceptionIfStateIsNotRunning()
        {
            runner.Update(1);
        }

        [TestMethod]
        public void UpdateIncrementsCurrentCycleTimeBySpecifiedValue()
        {
            runner.Start();

            runner.Update(5);

            Assert.AreEqual(5, runner.CurrentCycleTime);
        }

        [TestMethod]
        public void UpdateIncrementsCurrentCycleIndexIfCurrentCycleTimeIsLargerOrEqualToCurrentIndexCycleTime()
        {
            runner.Start();

            runner.Update(10);

            Assert.AreEqual(1, runner.CycleIndex);
        }

        [TestMethod]
        public void UpdateSetsCurrentCycleTimeAfterCycleIndexIncrementToOverlowOffset()
        {
            runner.Start();

            runner.Update(15);

            Assert.AreEqual(5, runner.CurrentCycleTime);
        }
    }
}
