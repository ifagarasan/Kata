using Pomodoro.Cycles;
using Pomodoro.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Util
{
    public static class Time
    {
        public static long MinutesToMiliseconds(int minutes)
        {
            if (minutes < 0)
                throw new InvalidInputException(string.Format("expected 0 of positive value, but got {0}", minutes));

            return minutes * 60000;
        }
    }
}
