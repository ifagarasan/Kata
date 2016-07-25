using System.Collections.Generic;
using BankAccount.Model.Repository;

namespace BankAccount.Infrastructure.Repository
{
    public class InMemoryTransactions : Transactions
    {
        private readonly List<Transaction> _transactions;

        public InMemoryTransactions()
        {
            _transactions = new List<Transaction>();
        }

        public void Add(Transaction transaction) => _transactions.Add(transaction);

        public int Count() => _transactions.Count;

        public Transaction At(int index) => _transactions[index];
    }
}