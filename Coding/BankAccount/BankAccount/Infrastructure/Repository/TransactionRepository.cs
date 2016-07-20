using System.Collections.Generic;
using BankAccount.Infrastructure.Date;
using BankAccount.Model.Account.Repository;

namespace BankAccount.Infrastructure.Repository
{
    public class TransactionRepository : IRepository
    {
        private readonly IDateProvider _dateProvider;

        public TransactionRepository(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            Transactions = new List<Transaction>();
        }

        public List<Transaction> Transactions { get; }

        public void AddDeposit(decimal amount) => Transactions.Add(Transaction(amount));

        public void AddWithdraw(decimal amount) => Transactions.Add(Transaction(-amount));

        private Transaction Transaction(decimal amount) => new Transaction(_dateProvider.Now(), amount);
    }
}