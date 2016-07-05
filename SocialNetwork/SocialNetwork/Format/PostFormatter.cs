using System;
using SocialNetwork.Time;

namespace SocialNetwork.Format
{
    public class PostFormatter : IPostFormatter
    {
        private readonly ITimeOffsetCalculator _timeOffsetCalculator;
        private readonly ITimeFormatter _timeFormatter;

        public PostFormatter(ITimeOffsetCalculator timeOffsetCalculator, ITimeFormatter timeFormatter)
        {
            _timeOffsetCalculator = timeOffsetCalculator;
            _timeFormatter = timeFormatter;
        }

        public string FormatTimelinePost(IPost post)
        {
            return $"{post.Message} ({_timeFormatter.Format(_timeOffsetCalculator.NowToDateOffset(post.WrittenAt))} ago)";
        }

        public string FormatWallPost(IPost post)
        {
            return $"{post.Username} - {FormatTimelinePost(post)}";
        }
    }
}