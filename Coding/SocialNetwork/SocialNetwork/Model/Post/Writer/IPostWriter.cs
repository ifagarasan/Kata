using System.Collections.Generic;

namespace SocialNetwork.Model.Post.Writer
{
    public interface IPostWriter
    {
        void Print(IList<Post> post);
    }
}