using System;

namespace SocialNetwork.Model.Post
{
    public class PostRecord
    {
        public PostRecord(User.User user, string message, DateTime writtenAt)
        {
            User = user;
            Message = message;
            WrittenAt = writtenAt;
        }

        public User.User User { get; }
        public string Message { get; }
        public DateTime WrittenAt { get; }
    }
}