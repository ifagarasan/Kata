using System.Collections.Generic;

namespace BankAccount.Model.Account.Repository
{
    public interface IRepository
    {
        IList<Transaction> Transactions { get; }

        void AddDeposit(decimal amount);
        void AddWithdraw(decimal amount);
    }
}