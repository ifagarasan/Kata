using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class TransactionRepository: ITransactionRepository
    {
        List<Transaction> transactions;
        IDateGenerator dateGenerator;

        public TransactionRepository(IDateGenerator dateGenerator)
        {
            this.dateGenerator = dateGenerator;

            transactions = new List<Transaction>();
        }

        public void AddDeposit(int amount)
        {
            transactions.Add(CreateTransaction(amount));
        }

        public void AddWithdrawal(int amount)
        {
            transactions.Add(CreateTransaction(-amount));
        }

        public IList<Transaction> GetAllTransactions()
        {
            return transactions.AsReadOnly();
        }

        private Transaction CreateTransaction(int amount)
        {
            return new Transaction(dateGenerator.TodayAsString(), amount);
        }
    }
}