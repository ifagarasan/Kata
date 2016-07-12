using SocialNetwork.Infrastructure.Format;
using SocialNetwork.Infrastructure.Time;

namespace SocialNetwork.Model.Post.Format
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

        public string FormatTimelinePost(Post post)
        {
            return $"{post.Message} ({_timeFormatter.Format(_timeOffsetCalculator.NowToDateOffset(post.WrittenAt))} ago)";
        }

        public string FormatWallPost(Post post)
        {
            return $"{post.Username} - {FormatTimelinePost(post)}";
        }
    }
}