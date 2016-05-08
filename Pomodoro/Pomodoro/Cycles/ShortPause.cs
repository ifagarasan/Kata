using Pomodoro.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Cycles
{
    public class ShortPause: ICycle
    {
        public ShortPause()
        {
            Label = "Short Pause";
            Duration = Time.MinutesToMiliseconds(5);
        }

        public long Duration { get; }
        public string Label { get; }
    }
}
