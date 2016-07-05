using System;
using SocialNetwork.Time;

namespace SocialNetwork
{
    public class PostFormatter : IPostFormatter
    {
        private readonly ITimeOffsetCalculator _timeOffsetCalculator;

        public PostFormatter(ITimeOffsetCalculator timeOffsetCalculator)
        {
            _timeOffsetCalculator = timeOffsetCalculator;
        }

        public string FormatTimelinePost(IPost post)
        {
            var timeOffset = _timeOffsetCalculator.NowToDateOffset(post.WrittenAt);
            var minutes = (int)Math.Ceiling(-timeOffset.TotalMinutes);
            var minuteLiteral = minutes == 1 ? "minute" : "minutes";

            return $"{post.Message} ({minutes} {minuteLiteral} ago)";
        }

        public string FormatWallPost(IPost post)
        {
            return $"{post.Username} - {FormatTimelinePost(post)}";
        }
    }
}