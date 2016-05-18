using Pomodoro.Exceptions;
using System;
using System.Collections.Generic;

namespace Pomodoro
{
    public enum RunnerState
    {
        Idle,
        Running
    }

    public class Runner
    {
        private IBuilder builder;

        private List<ICycle> cycles;

        public Runner(IBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");

            this.builder = builder;
            CycleIndex = -1;

            cycles = builder.Build();
        }

        public uint CurrentCycleTime { get; private set; }

        public int CycleIndex { get; private set; }

        public IList<ICycle> Cycles
        {
            get
            {
                return cycles.AsReadOnly();
            }
        }

        public RunnerState State { get; set; }

        public void Start()
        {
            State = RunnerState.Running;
            CycleIndex = 0;
            CurrentCycleTime = 0;
        }

        public void Update(uint value)
        {
            if (State != RunnerState.Running)
                throw new InvalidStateException();

            CurrentCycleTime += value;

            while (CurrentCycleTime >= Cycles[CycleIndex].DurationInMiliseconds)
            {
                CurrentCycleTime -= Cycles[CycleIndex].DurationInMiliseconds;
                CycleIndex++;

                if (CycleIndex == Cycles.Count)
                {
                    State = RunnerState.Idle;
                    break;
                }
            }
        }

        public void Stop()
        {
            State = RunnerState.Idle;
        }
    }
}