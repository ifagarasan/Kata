using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.User;
using IPostRepository = SocialNetwork.Model.Post.IPostRepository;

namespace SocialNetwork.Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IDateProvider _dateProvider;
        private readonly IList<Post> _posts;

        public PostRepository(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            _posts = new List<Post>();
        }

        public void Insert(string username, string message)
        {
            _posts.Add(new Post(username, message, _dateProvider.Now()));
        }

        public IList<Post> RetrieveTimeline(string username)
        {
            return _posts.Where(p => p.Username.Equals(username)).Reverse().ToList().AsReadOnly();
        }

        public IList<Post> RetrieveWall(User user)
        {
            return _posts.Where(p => p.Username.Equals(user.Username) || user.Follows.Contains(p.Username)).Reverse().ToList().AsReadOnly();
        }
    }
}