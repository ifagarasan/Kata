using System;
using SocialNetwork.Date;

namespace SocialNetwork.Time
{
    public class TimeOffsetCalculator : ITimeOffsetCalculator
    {
        private readonly IDateProvider _dateProvider;
        
        public TimeOffsetCalculator(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
        }

        public TimeSpan NowToDateOffset(DateTime date)
        {
            return date.Subtract(_dateProvider.Now());
        }
    }
}