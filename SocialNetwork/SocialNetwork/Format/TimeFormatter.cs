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
            return (int)Math.Ceiling(Math.Abs(timeSpan.TotalMinutes));
        }

        private static string GenerateTimeUnit(TimeSpan timeSpan)
        {
            var minutes = Math.Abs(timeSpan.TotalMinutes);

            return minutes <= 1 ? "minute" : "minutes";
        }
    }
}