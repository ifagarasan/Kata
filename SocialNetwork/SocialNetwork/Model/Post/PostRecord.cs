using System;

namespace SocialNetwork.Model.Post
{
    public class PostRecord
    {
        public PostRecord(string username, string message, DateTime writtenAt)
        {
            Username = username;
            Message = message;
            WrittenAt = writtenAt;
        }

        public string Username { get; set; }
        public string Message { get; }
        public DateTime WrittenAt { get; }
    }
}