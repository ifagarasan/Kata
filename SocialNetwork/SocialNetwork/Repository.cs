using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Date;

namespace SocialNetwork
{
    public class Repository : IRepository
    {
        private readonly IDateProvider _dateProvider;
        private readonly IList<IPost> _posts;

        public Repository(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            _posts = new List<IPost>();
        }

        public void Insert(string username, string message)
        {
            _posts.Add(new Post(username, message, _dateProvider.Now()));
        }

        public IList<IPost> RetrieveTimeline(string username)
        {
            return _posts.Where(p => p.Username.Equals(username)).Reverse().ToList();
        }

        public IList<IPost> RetrieveWall(string username)
        {
            return _posts.Where(p => p.Username.Equals(username)).Reverse().ToList();
        }
    }
}