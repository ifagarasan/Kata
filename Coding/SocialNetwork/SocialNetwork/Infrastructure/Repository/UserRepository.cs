using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Model.User;

namespace SocialNetwork.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
        }

        public User Insert(string username)
        {
            var user = new User(username);

            _users.Add(user);

            return user;
        }

        public User Get(string username) => _users.SingleOrDefault(u => u.Username.Equals(username));
    }
}