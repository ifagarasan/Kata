using Pomodoro.Cycles;
using Pomodoro.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Runners
{
    public enum RunnerState
    {
        Idle = 0,
        Running,
        Paused
    }

    public class Runner: IRunner
    {
        RunnerData runnerData;
        IMaster masterCycle;

        public Runner(RunnerData runnerData, IMaster masterCycle)
        {
            if (runnerData == null)
                throw new ArgumentNullException("runnerData");

            if (masterCycle == null)
                throw new ArgumentNullException("masterCycle");

            this.runnerData = runnerData;
            this.masterCycle = masterCycle;

            Initialise();
        }

        public long LastUpdated { get; private set; }

        public long LastUpdatedOffset { get; private set; }

        public IMaster MasterCycle
        {
            get
            {
                return masterCycle;
            }
        }

        public RunnerData RunnerData
        {
            get
            {
                return runnerData;
            }
        }

        public RunnerState State { get; private set; }

        public void New()
        {
            Initialise();
        }

        private void Initialise()
        {
            RunnerData.MasterCycleIndex = 0;
            RunnerData.MasterCycleCurrent = 0;
            LastUpdatedOffset = -1;
            LastUpdated = 0;
            State = RunnerState.Idle;
        }

        public void Start()
        {
            if (State == RunnerState.Running)
                return;

            SetLastUpdated();
            State = RunnerState.Running;
        }

        public void Update()
        {
            if (State != RunnerState.Running)
                throw new StateException(string.Format("cannot update when state is {0}, expected Running", State.ToString()));

            SetLastUpdated();

            RunnerData.MasterCycleCurrent += LastUpdatedOffset;

            long currentDuration = MasterCycle.Cycles[RunnerData.MasterCycleIndex].Duration;

            if (RunnerData.MasterCycleCurrent > currentDuration)
            {
                RunnerData.MasterCycleCurrent -= currentDuration;
                RunnerData.MasterCycleIndex++;
            }
        }

        private void SetLastUpdated()
        {
            long previousLastUpdated = LastUpdated;
            LastUpdated = Environment.TickCount;
            LastUpdatedOffset = LastUpdated - previousLastUpdated;
        }
    }
}
