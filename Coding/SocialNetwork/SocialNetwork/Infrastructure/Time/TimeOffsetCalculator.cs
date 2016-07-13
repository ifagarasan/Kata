using System;
using SocialNetwork.Infrastructure.Date;

namespace SocialNetwork.Infrastructure.Time
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