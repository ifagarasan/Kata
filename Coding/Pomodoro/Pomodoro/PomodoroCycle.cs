using System;

namespace Pomodoro
{
    public class PomodoroCycle : Cycle
    {
        public PomodoroCycle() : base("Pomodoro", Util.MinutesToMiliseconds(25)) { }
    }
}