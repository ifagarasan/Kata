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
        private readonly IList<IPost> posts;

        public Repository(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            posts = new List<IPost>();
        }

        public void Insert(string username, string message)
        {
            posts.Add(new Post(username, message, _dateProvider.Now()));
        }

        public IList<IPost> RetrieveUserMessages(string username)
        {
            return posts.Where(p => p.Username.Equals(username)).ToList();
        }
    }
}