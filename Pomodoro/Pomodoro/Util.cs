using System;

namespace Pomodoro
{
    public static class Util
    {
        public const uint MilisecondsInAMinute = 60000;

        public static uint MinutesToMiliseconds(uint minutes)
        {
            return minutes * MilisecondsInAMinute;
        }
    }
}