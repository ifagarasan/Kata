using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro;
using Pomodoro.Cycles;
using Pomodoro.Runners;
using System.Threading;
using Pomodoro.Exceptions;
using Moq;
using System.Collections.Generic;

namespace PomodoroTests.Runners
{
    [TestClass]
    public class RunnerFunctionality
    {
        RunnerData runnerData;
        Runner runner;
        Master master;

        [TestInitialize]
        public void Setup()
        {
            runnerData = new RunnerData();
            master = new Master(new Builder());
            runner = new Runner(runnerData, master);
        }

        #region Initialisation

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RunnerThrowsArgumentNullExceptionIfRunnerDataIsNull()
        {
            Runner runner = new Runner(null, master);
        }

        [TestMethod]
        public void RunnerDataIsAsProvided()
        {
            Assert.AreSame(runnerData, runner.RunnerData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RunnerThrowsArgumentNullExceptionIfMasterCycleIsNull()
        {
            Runner runner = new Runner(runnerData, null);
        }

        [TestMethod]
        public void MasterCycleIsAsProvided()
        {
            Assert.AreSame(master, runner.MasterCycle);
        }

        [TestMethod]
        public void LastUpdatedOffsetIsMinusOne()
        {
            Assert.AreEqual(-1, runner.LastUpdatedOffset);
        }

        #endregion

        #region New

        [TestMethod]
        public void NewSetsMasterCycleIndexToZero() 
        {
            runnerData.MasterCycleIndex = 1;

            runner.New();

            Assert.AreEqual(0, runnerData.MasterCycleIndex);
        }

        [TestMethod]
        public void NewSetsLastUpdatedOffsetToMinusOne()
        {
            runner.New();

            Assert.AreEqual(-1, runner.LastUpdatedOffset);
        }

        [TestMethod]
        public void NewSetsLastUpdatedToZero()
        {
            runner.New();

            Assert.AreEqual(0, runner.LastUpdated);
        }

        [TestMethod]
        public void NewSetsStateToIdle()
        {
            runner.Start();

            runner.New();

            Assert.AreEqual(RunnerState.Idle, runner.State);
        }

        [TestMethod]
        public void NewSetsMasterCycleCurrentToZero()
        {
            Assert.AreEqual(0, runnerData.MasterCycleCurrent);
        }

        #endregion

        #region Start

        [TestMethod]
        public void StartSetsLastUpdatedToCurrentTick()
        {
            long low = Environment.TickCount;

            runner.Start();

            long high = Environment.TickCount;

            Assert.IsTrue(low <= runner.LastUpdated && high >= runner.LastUpdated);
        }

        [TestMethod]
        public void StartSetsRunnerDataStateToRunning()
        {
            runner.Start();
            Assert.AreEqual(RunnerState.Running, runner.State);
        }

        [TestMethod]
        public void StartDoesNotUpdateDataIfAlreadyRunning()
        {
            runner.Start();

            long expected = runner.LastUpdated;

            Thread.Sleep(20);

            runner.Start();

            Assert.AreEqual(expected, runner.LastUpdated);
        }

        #endregion

        #region Update

        [TestMethod]
        [ExpectedException(typeof(StateException))]
        public void UpdateThrowsStateExceptionIfRunnerDataStateIsNotRunning()
        {
            runner.Update();
        }

        [TestMethod]
        public void UpdateSetsLastUpdatedToCurrentTick()
        {
            runner.Start();

            Thread.Sleep(20);

            long low = Environment.TickCount;

            runner.Update();

            long high = Environment.TickCount;

            Assert.IsTrue(low <= runner.LastUpdated && high >= runner.LastUpdated);
        }

        [TestMethod]
        public void UpdateAddsToRunnerDataMasterCycleCurrentTheOffsetBetweenPreviousLastUpdatedAndCurrentLastUpdated()
        {
            runner.Start();

            long last = runner.LastUpdated;
            long expected = runner.RunnerData.MasterCycleCurrent;

            Thread.Sleep(20);

            runner.Update();

            long offset = runner.LastUpdated - last;

            Assert.AreEqual(expected, runner.RunnerData.MasterCycleCurrent - offset);
        }

        [TestMethod]
        public void UpdateSetsTheOffsetBetweenPreviousLastUpdatedAndCurrentLastUpdatedAsLastUpdatedOffset()
        {
            runner.Start();

            long last = runner.LastUpdated;
            long expected = runner.RunnerData.MasterCycleCurrent;

            Thread.Sleep(20);

            runner.Update();

            long offset = runner.LastUpdated - last;

            Assert.AreEqual(offset, runner.LastUpdatedOffset);
        }

        [TestMethod]
        public void UpdateIncrementsRunnerDataMasterCycleIndexWhenMasterCycleCurrentIsLargerThanCurrentIndexDuration()
        {
            Mock<ICycle> cycleMock = new Mock<ICycle>();
            cycleMock.Setup(c => c.Duration).Returns(10);

            Mock<IMaster> masterMock = new Mock<IMaster>();

            var result = new List<ICycle> { cycleMock.Object };
            masterMock.Setup(m => m.Cycles).Returns(result);

            runner = new Runner(runnerData, masterMock.Object);

            runner.Start();

            Thread.Sleep(20);

            runner.Update();

            Assert.AreEqual(1, runnerData.MasterCycleIndex);
        }

        [TestMethod]
        public void UpdateSetsRunnerDataMasterCycleCurrentToOverflowQuantityWhenOverflowing()
        {
            Mock<ICycle> cycleMock = new Mock<ICycle>();
            cycleMock.Setup(c => c.Duration).Returns(10);

            Mock<IMaster> masterMock = new Mock<IMaster>();

            var result = new List<ICycle> { cycleMock.Object };
            masterMock.Setup(m => m.Cycles).Returns(result);

            runner = new Runner(runnerData, masterMock.Object);

            runner.Start();

            Thread.Sleep(20);

            runner.Update();

            Assert.AreEqual(runner.LastUpdatedOffset-10, runnerData.MasterCycleCurrent);
        }

        #endregion
    }
}
