using System;

namespace SocialNetwork.Format
{
    public class TimeFormatter : ITimeFormatter
    {
        public string Format(TimeSpan timeSpan)
        {
            return $"{GenerateTimeValue(timeSpan)} {GenerateTimeUnit(timeSpan)}";
        }

        private static int GenerateTimeValue(TimeSpan timeSpan)
        {
            return (int)Math.Ceiling(Math.Abs(LessThanOneMinute(timeSpan) ? timeSpan.TotalSeconds : timeSpan.TotalMinutes));
        }

        private static bool LessThanOneMinute(TimeSpan timeSpan)
        {
            return Math.Abs(timeSpan.TotalSeconds) <= 59;
        }

        private static string GenerateTimeUnit(TimeSpan timeSpan)
        {
            var literal = LessThanOneMinute(timeSpan) ? "second" : "minute";

            return GenerateTimeValue(timeSpan) == 1 ? literal : $"{literal}s";
        }
    }
}