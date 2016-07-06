﻿using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Action.Format;
using SocialNetwork.Model;

namespace SocialNetwork.Action
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
            return _repository.RetrieveTimeline(username).Select(post => _postFormatter.FormatTimelinePost(post)).ToList();
        }

        public IList<string> RetrieveWall(string username)
        {
            return _repository.RetrieveWall(username).Select(post => _postFormatter.FormatWallPost(post)).ToList();
        }

        public void Follow(string username, string followUsername)
        {
            _repository.Follow(username, followUsername);
        }
    }
}