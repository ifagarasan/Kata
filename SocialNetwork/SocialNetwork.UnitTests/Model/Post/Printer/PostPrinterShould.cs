using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.Post.Printer;

namespace SocialNetwork.UnitTests.Model.Post.Printer
{
    [TestClass]
    public class PostPrinterShould
    {
        [TestMethod]
        public void PrintPosts()
        {
            var username = "test";
            var now = DateTime.Now;
            var post1 = new SocialNetwork.Model.Post.Post(username, "Me, too! (1 minute ago)", now);
            var post2 = new SocialNetwork.Model.Post.Post(username, "I'm in London! (2 minutes ago)", now);
            var posts = new List<SocialNetwork.Model.Post.Post> { post2, post1 };

            var postFormatterMock = new Mock<IPostFormatter>();
            var consoleMock = new Mock<IConsole>();

            consoleMock.Setup(m => m.Write(It.IsAny<string>()));

            var index = 0;
            postFormatterMock.Setup(m => m.Format(It.IsAny<SocialNetwork.Model.Post.Post>())).Callback(
                (SocialNetwork.Model.Post.Post post) =>
                {
                    Assert.AreEqual(posts[index++], post);
                });

            var postPrinter = new PostPrinter(postFormatterMock.Object, consoleMock.Object);

            postPrinter.Print(posts);

            postFormatterMock.Verify(m => m.Format(It.IsAny<SocialNetwork.Model.Post.Post>()), Times.Exactly(2));

        }
    }
}
