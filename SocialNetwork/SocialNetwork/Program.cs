using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Infrastructure.Format;
using SocialNetwork.Infrastructure.Repository;
using SocialNetwork.Infrastructure.Time;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Command.Input;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.Post.Printer;
using SocialNetwork.Model.Social.Platform;

namespace SocialNetwork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dateProvider = new DateProvider();
            var console = new Console();

            var postTimeFormatter = new PostTimeFormatter(new TimeOffsetCalculator(dateProvider), new TimeFormatter());

            var wallPrinter = new PostPrinter(new WallPostFormatter(postTimeFormatter), console);
            var timelinePrinter = new PostPrinter(new TimelinePostFormatter(postTimeFormatter), console);

            var socialPlatform = new SocialPlatform(new InputParser(), console, new CommandFactory(new PostRepository(dateProvider),
                new UserRepository(), wallPrinter, timelinePrinter));   

            socialPlatform.Run();
        }
    }
}
