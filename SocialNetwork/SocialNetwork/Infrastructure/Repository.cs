using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Model.Post;

namespace SocialNetwork.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly IDateProvider _dateProvider;
        private readonly IList<PostRecord> _posts;
        private readonly Dictionary<string, HashSet<string>> _followInfo;

        public Repository(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            _posts = new List<PostRecord>();
            _followInfo = new Dictionary<string, HashSet<string>>();
        }

        public void Insert(string username, string message)
        {
            _posts.Add(new PostRecord(username, message, _dateProvider.Now()));
        }

        public IList<PostRecord> RetrieveTimeline(string username)
        {
            return _posts.Where(p => p.Username.Equals(username)).Reverse().ToList().AsReadOnly();
        }

        public IList<PostRecord> RetrieveWall(string username)
        {
            return _posts.Where(IsAuthorOrFollowed(username)).Reverse().ToList().AsReadOnly();
        }

        public void Follow(string username, string followUsername)
        {
            if (!_followInfo.ContainsKey(username))
                _followInfo.Add(username, new HashSet<string>());

            _followInfo[username].Add(followUsername);
        }

        private System.Func<PostRecord, bool> IsAuthorOrFollowed(string username)
        {
            return p => p.Username.Equals(username) || (_followInfo.ContainsKey(username) && _followInfo[username].Contains(p.Username));
        }
    }
}