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

        public int CurrentCycleTime { get; private set; }

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
        }

        public void Update(int value)
        {
            if (State != RunnerState.Running)
                throw new InvalidStateException();

            if (value < 0)
                throw new InvalidTimeOffsetException();

            CurrentCycleTime += value;

            int duration = Cycles[CycleIndex].DurationInMiliseconds;

            if (CurrentCycleTime >= duration)
            {
                CycleIndex++;
                CurrentCycleTime -= duration;
            }
        }
    }
}