using BankAccount.Infrastructure.Date;

namespace BankAccount.Model.Account.Repository
{
    public class Transaction
    {
        private readonly Date _createdAt;

        public Transaction(Date createdAt, decimal amount)
        {
            _createdAt = createdAt;
            Amount = amount;
        }

        public decimal Amount { get; }

        public string CreatedAt => _createdAt.ShortFormat;

        public override bool Equals(object obj) => obj is Transaction && Equals((Transaction) obj);

        protected bool Equals(Transaction other) => Amount == other.Amount && CreatedAt.Equals(other.CreatedAt);

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount.GetHashCode()*397) ^ CreatedAt.GetHashCode();
            }
        }
    }
}