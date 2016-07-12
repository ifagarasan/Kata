using SocialNetwork.Infrastructure;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Infrastructure.Format;
using SocialNetwork.Infrastructure.Repository;
using SocialNetwork.Infrastructure.Time;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Command.Input;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.Social.Platform;

namespace SocialNetwork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dateProvider = new DateProvider();
            var console = new Console();

            var socialPlatform = new SocialPlatform(new InputRetriever(new InputParser(), console),
                new CommandFactory(new Repository(dateProvider),
                new PostFormatter(new TimeOffsetCalculator(dateProvider), new TimeFormatter()), console));   

            socialPlatform.Run();
        }
    }
}
