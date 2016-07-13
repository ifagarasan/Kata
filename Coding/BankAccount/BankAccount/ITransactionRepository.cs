using System;
using System.Collections.Generic;

namespace BankAccount
{
    public interface ITransactionRepository
    {
        void AddDeposit(int amount);
        void AddWithdrawal(int amount);
        IList<Transaction> GetAllTransactions();
    }
}