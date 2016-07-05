using System;

namespace SocialNetwork.Format
{
    public interface ITimeFormatter
    {
        string Format(TimeSpan timeSpan);
    }
}