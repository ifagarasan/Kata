using Pomodoro.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Cycles
{
    public class Pomodoro: ICycle
    {
        public Pomodoro()
        {
            Label = "Pomodoro";
            Duration = Time.MinutesToMiliseconds(25);
        }

        public long Duration { get; }
        public string Label { get; }
    }
}
