using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Writer;
using SocialNetwork.Model.User;
using DisplayWall = SocialNetwork.Action.Command.DisplayWall;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class DisplayWallShould
    {
        [TestMethod]
        public void PrintWall()
        {
            var now = DateTime.Now;
            var user = new User("test");
            var post = new Post(user.Username, "I'm in London! (1 minute ago)", now);
            var posts = new List<Post> { post };

            var postRepositoryMock = new Mock<IPostRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var postPrinterMock = new Mock<IPostWriter>();

            postRepositoryMock.Setup(m => m.RetrieveWall(It.IsAny<User>())).Returns(posts);
            userRepositoryMock.Setup(m => m.Get(It.IsAny<string>())).Returns(user);
            postPrinterMock.Setup(m => m.Print(It.IsAny<IList<Post>>()));

            new DisplayWall(postRepositoryMock.Object, userRepositoryMock.Object, postPrinterMock.Object, post.Username).Execute();

            postRepositoryMock.Verify(m => m.RetrieveWall(user));
            postPrinterMock.Verify(m => m.Print(posts));
        }
    }
}
