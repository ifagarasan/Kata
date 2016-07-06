using System;

namespace SocialNetwork.Infrastructure.Format
{
    public interface ITimeFormatter
    {
        string Format(TimeSpan timeSpan);
    }
}