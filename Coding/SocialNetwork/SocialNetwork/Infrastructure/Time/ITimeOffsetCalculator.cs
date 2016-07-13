using System;

namespace SocialNetwork.Infrastructure.Time
{
    public interface ITimeOffsetCalculator
    {
        TimeSpan NowToDateOffset(DateTime date);
    }
}