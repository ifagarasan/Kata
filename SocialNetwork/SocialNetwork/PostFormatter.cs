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

        public string Format(IPost post)
        {
            var timeOffset = _timeOffsetCalculator.NowToDateOffset(post.WrittenAt);

            return $"{post.Message} ({-timeOffset.TotalMinutes} minutes ago)";
        }
    }
}