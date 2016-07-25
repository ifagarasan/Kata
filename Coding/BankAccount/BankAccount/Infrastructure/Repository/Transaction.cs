namespace BankAccount.Infrastructure.Repository
{
    public class Transaction
    {
        public int Amount { get; }
        public Date CreatedAt { get; }

        public Transaction(Date createdAt, int amount)
        {
            CreatedAt = createdAt;
            Amount = amount;
        }

        protected bool Equals(Transaction other)
            => Amount == other.Amount && Equals(CreatedAt, other.CreatedAt);

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount*397) ^ (CreatedAt?.GetHashCode() ?? 0);
            }
        }

        public override bool Equals(object obj) => Equals((Transaction)obj);
    }
}