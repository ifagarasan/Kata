using System;

namespace SocialNetwork.Time
{
    public interface ITimeOffsetCalculator
    {
        TimeSpan NowToDateOffset(System.DateTime date);
    }
}