using SocialNetwork.Infrastructure.Format;
using SocialNetwork.Infrastructure.Time;

namespace SocialNetwork.Model.Post.Format
{
    public class PostTimeFormatter: IPostFormatter
    {
        private readonly ITimeOffsetCalculator _timeOffsetCalculator;
        private readonly ITimeFormatter _timeFormatter;

        public PostTimeFormatter(ITimeOffsetCalculator timeOffsetCalculator, ITimeFormatter timeFormatter)
        {
            _timeOffsetCalculator = timeOffsetCalculator;
            _timeFormatter = timeFormatter;
        }

        public string Format(Post post) => $"({_timeFormatter.Format(_timeOffsetCalculator.NowToDateOffset(post.WrittenAt))} ago)";
    }
}