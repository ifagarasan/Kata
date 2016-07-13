using System.Collections.Generic;

namespace SocialNetwork.Model.Post
{
    public interface IPostPrinter
    {
        void Print(IList<Post> post);
    }
}