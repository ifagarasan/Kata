namespace BankAccount.Infrastructure.Console
{
    public class Console : IConsole
    {
        public void Write(string message) => System.Console.WriteLine(message);
    }
}