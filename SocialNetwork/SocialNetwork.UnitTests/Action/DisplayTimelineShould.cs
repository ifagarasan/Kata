using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Model.Post;
using DisplayTimeline = SocialNetwork.Action.Command.DisplayTimeline;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class DisplayTimelineShould
    {
        [TestMethod]
        public void PrintTimeline()
        {
            var username = "test";
            var now = DateTime.Now;
            var post = new Post(username, "I'm in London! (1 minute ago)", now);
            var posts = new List<Post> { post };

            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(m => m.RetrieveTimeline(It.IsAny<string>())).Returns(posts);
            
            var postPrinter = new Mock<IPostPrinter>();
            postPrinter.Setup(m => m.Print(It.IsAny<List<Post>>()));

            new DisplayTimeline(postRepositoryMock.Object, postPrinter.Object , post.Username).Execute();

            postRepositoryMock.Verify(m => m.RetrieveTimeline(post.Username));
            postPrinter.Verify(m => m.Print(posts));
        }
    }
}
