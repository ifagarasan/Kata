using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Infrastructure.Date;

namespace SocialNetwork.Model
{
    public class Repository : IRepository
    {
        private readonly IDateProvider _dateProvider;
        private readonly IList<Post> _posts;
        private readonly Dictionary<string, HashSet<string>> _followInfo;

        public Repository(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            _posts = new List<Post>();
            _followInfo = new Dictionary<string, HashSet<string>>();
        }

        public void Insert(string username, string message)
        {
            _posts.Add(new Post(username, message, _dateProvider.Now()));
        }

        public IList<Post> RetrieveTimeline(string username)
        {
            return _posts.Where(p => p.Username.Equals(username)).Reverse().ToList().AsReadOnly();
        }

        public IList<Post> RetrieveWall(string username)
        {
            return _posts.Where(IsAuthorOrFollowed(username)).Reverse().ToList().AsReadOnly();
        }

        public void Follow(string username, string followUsername)
        {
            if (!_followInfo.ContainsKey(username))
                _followInfo.Add(username, new HashSet<string>());

            _followInfo[username].Add(followUsername);
        }

        private System.Func<Post, bool> IsAuthorOrFollowed(string username)
        {
            return p => p.Username.Equals(username) || (_followInfo.ContainsKey(username) && _followInfo[username].Contains(p.Username));
        }
    }
}