using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Infrastructure.Repository;

namespace SocialNetwork.UnitTests.Infrastructure.Repository
{
    [TestClass]
    public class UserRepositoryShould
    {
        [TestMethod]
        public void Insert()
        {
            var username = "test";
            var repository = new UserRepository();

            repository.Insert(username);

            Assert.AreSame(username, repository.Get(username).Username);
        }
    }
}
