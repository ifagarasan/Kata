namespace BankAccount.Infrastructure.Repository
{
    public class Date
    {
        public Date(string date)
        {
            Short = date;
        }

        public string Short { get; }

        public override bool Equals(object obj) => Equals((Date)obj);

        protected bool Equals(Date other) => string.Equals(Short, other.Short);

        public override int GetHashCode()
        {
            return Short?.GetHashCode() ?? 0;
        }
    }
}