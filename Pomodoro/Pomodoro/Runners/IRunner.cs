using Pomodoro.Cycles;
using Pomodoro.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Runners
{
    public interface IRunner
    {
        long LastUpdated { get; }

        long LastUpdatedOffset { get; }

        IMaster MasterCycle { get; }

        RunnerData RunnerData { get; }

        RunnerState State { get; }

        void New();

        void Start();

        void Update();
    }
}
