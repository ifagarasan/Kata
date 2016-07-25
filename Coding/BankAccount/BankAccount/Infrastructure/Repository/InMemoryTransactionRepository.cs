using System;
using BankAccount.Model;
using BankAccount.Model.Repository;

namespace BankAccount.Infrastructure.Repository
{
    public class InMemoryTransactionRepository : TransactionRepository
    {
        private readonly Transactions _transactions;
        private readonly Clock _clock;

        public InMemoryTransactionRepository(Transactions transactions, Clock clock)
        {
            _transactions = transactions;
            _clock = clock;
        }

        public void AddDeposit(int amount) => _transactions.Add(Transaction(amount));

        public void AddWithdraw(int amount) => _transactions.Add(new Transaction(_clock.Today(), -amount));

        public Transactions Transactions() => _transactions;

        private Transaction Transaction(int amount) => new Transaction(_clock.Today(), amount);
    }
}