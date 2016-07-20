using BankAccount.Infrastructure.Date;

namespace BankAccount.Model.Account.Repository
{
    public class Transaction
    {
        public Transaction(Date createdAt, decimal amount)
        {
            Amount = amount;
            CreatedAt = createdAt;
        }

        public decimal Amount { get; }

        public Date CreatedAt { get; }

        public override bool Equals(object obj) => obj is Transaction && Equals((Transaction) obj);

        protected bool Equals(Transaction other) => Amount == other.Amount && CreatedAt.ShortFormat.Equals(other.CreatedAt.ShortFormat);

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount.GetHashCode()*397) ^ CreatedAt.GetHashCode();
            }
        }
    }
}