using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Format;

namespace SocialNetwork.Model.Social.Engine
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

        public void Post(User.User user, string message)
        {
            _repository.Insert(user, message);
        }

        public IList<string> RetrieveTimeline(User.User user)
        {
            return _repository.RetrieveTimeline(user).Select(post => _postFormatter.FormatTimelinePost(post)).ToList().AsReadOnly();
        }

        public IList<string> RetrieveWall(User.User user)
        {
            return _repository.RetrieveWall(user).Select(post => _postFormatter.FormatWallPost(post)).ToList().AsReadOnly();
        }

        public void Follow(User.User user, User.User userToFollow)
        {
            _repository.Follow(user, userToFollow);
        }
    }
}