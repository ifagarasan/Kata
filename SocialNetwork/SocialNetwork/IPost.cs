using System;

namespace SocialNetwork
{
    public interface IPost
    {
        string Message { get; }
        string Username { get; }
        DateTime WrittenAt { get; }
    }
}