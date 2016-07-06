using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Infrastructure.Date;

namespace SocialNetwork.Model
{
    public class Repository : IRepository
    {
        private readonly IDateProvider _dateProvider;
        private readonly IList<Post> _posts;
        private readonly Dictionary<string, HashSet<string>> _followers;

        public Repository(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            _posts = new List<Post>();
            _followers = new Dictionary<string, HashSet<string>>();
        }

        public void Insert(string username, string message)
        {
            _posts.Add(new Post(username, message, _dateProvider.Now()));
        }

        public IList<Post> RetrieveTimeline(string username)
        {
            return _posts.Where(p => p.Username.Equals(username)).Reverse().ToList();
        }

        public IList<Post> RetrieveWall(string username)
        {
            return _posts.Where(p => p.Username.Equals(username) ||
                (_followers.ContainsKey(username) && _followers[username].Contains(p.Username))).Reverse().ToList();
        }

        public void Follow(string username, string followUsername)
        {
            if (!_followers.ContainsKey(username))
                _followers.Add(username, new HashSet<string>());

            _followers[username].Add(followUsername);
        }
    }
}