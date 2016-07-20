namespace BankAccount.Infrastructure.Date
{
    public class Date
    {
        public Date(string shortFormat)
        {
            ShortFormat = shortFormat;
        }

        public string ShortFormat { get; }
    }
}
