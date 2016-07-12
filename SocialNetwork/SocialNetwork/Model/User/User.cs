using System.Collections.Generic;

namespace SocialNetwork.Model.User
{
    public class User
    {
        private readonly List<User> _follows;

        public User(string username): this(username, new List<User>())
        {
        }

        public User(string username, List<User> follows)
        {
            Username = username;
            _follows = follows;
        }

        public string Username { get; }

        public IList<User> Follows => _follows.AsReadOnly();
    }
}
