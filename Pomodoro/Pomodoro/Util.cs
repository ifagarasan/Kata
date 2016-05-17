using System;

namespace Pomodoro
{
    public static class Util
    {
        public const int MilisecondsInAMinute = 60000;

        public static int MinutesToMiliseconds(int minutes)
        {
            return minutes * MilisecondsInAMinute;
        }
    }
}