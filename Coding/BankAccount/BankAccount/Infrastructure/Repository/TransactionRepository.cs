using System.Collections.Generic;
using BankAccount.Infrastructure.Date;
using BankAccount.Model.Account.Repository;

namespace BankAccount.Infrastructure.Repository
{
    public class TransactionRepository : IRepository
    {
        private readonly IDateProvider _dateProvider;

        private readonly List<Transaction> _transactions;

        public TransactionRepository(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            _transactions = new List<Transaction>();
        }

        public IList<Transaction> Transactions => _transactions.AsReadOnly();

        public void AddDeposit(decimal amount) => AddTransaction(amount);

        public void AddWithdraw(decimal amount) => AddTransaction(-amount);

        private void AddTransaction(decimal amount) => _transactions.Add(new Transaction(_dateProvider.Now(), amount));
    }
}