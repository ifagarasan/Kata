using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork
{
    public class SocialEngine : ISocialEngine
    {
        private readonly IRepository _repository;
        private readonly IPostFormatter _postFormatter;

        public SocialEngine(IRepository repository, IPostFormatter postFormatter)
        {
            _repository = repository;
            _postFormatter = postFormatter;
        }

        public void Post(string username, string message)
        {
            _repository.Insert(username, message);
        }

        public IList<string> RetrieveTimeline(string username)
        {
            return _repository.RetrieveUserMessages(username).Select(post => _postFormatter.Format(post)).ToList();
        }

        public IList<string> RetrieveWall(string username)
        {
            throw new NotImplementedException();
        }
    }
}