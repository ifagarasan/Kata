using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro;
using Pomodoro.Cycles;
using Moq;

namespace PomodoroTests.Cycles
{
    [TestClass]
    public class MasterFunctionality : CycleFunctionality
    {
        protected override ICycle BuildCycle()
        {
            return new Master(new Builder());
        }

        #region Initialisation

        [TestMethod]
        public void TestLabelIsMaster()
        {
            TestLabel("Master");
        }

        [TestMethod]
        public void CallsBuilderBuildExactlyOnce()
        {
            Mock<IBuilder> mock = new Mock<IBuilder>();

            mock.Setup(m => m.Build());

            cycle = new Master(mock.Object);

            mock.Verify(m => m.Build(), Times.Exactly(1));
        }

        #endregion
    }
}
