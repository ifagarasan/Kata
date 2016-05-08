using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Cycles
{
    public class Master: IMaster
    {
        public Master(IBuilder builder)
        {
            Label = "Master";
            Cycles = builder.Build();
        }

        public long Duration { get; }
        public string Label { get; }

        public List<ICycle> Cycles { get; }
    }
}
