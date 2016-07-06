namespace SocialNetwork.Infrastructure
{
    public class Console: IConsole
    {
        public string Read()
        {
            return System.Console.ReadLine();
        }

        public void Write(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}