using Pomodoro.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Cycles
{
    public class LongPause : ICycle
    {
        public LongPause()
        {
            Label = "Long Pause";
            Duration = Time.MinutesToMiliseconds(15);
        }

        public long Duration { get; }
        public string Label { get; }
    }
}
