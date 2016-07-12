using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.User;

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

        public void Insert(User user, string message)
        {
            _posts.Add(new PostRecord(user, message, _dateProvider.Now()));
        }

        public IList<PostRecord> RetrieveTimeline(User user)
        {
            return _posts.Where(p => p.User.Username.Equals(user.Username)).Reverse().ToList().AsReadOnly();
        }

        public IList<PostRecord> RetrieveWall(User user)
        {
            return _posts.Where(IsAuthorOrFollowed(user.Username)).Reverse().ToList().AsReadOnly();
        }

        public void Follow(User user1, User user2)
        {
            if (!_followInfo.ContainsKey(user1.Username))
                _followInfo.Add(user1.Username, new HashSet<string>());

            _followInfo[user1.Username].Add(user2.Username);
        }

        private System.Func<PostRecord, bool> IsAuthorOrFollowed(string username)
        {
            return p => p.User.Username.Equals(username) || (_followInfo.ContainsKey(username) && _followInfo[username].Contains(p.User.Username));
        }
    }
}