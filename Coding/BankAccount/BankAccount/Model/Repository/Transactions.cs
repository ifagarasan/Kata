using System.Collections.Generic;
using BankAccount.Infrastructure.Repository;

namespace BankAccount.Model.Repository
{
    public interface Transactions
    {
        void Add(Transaction transaction);
        int Count();
        Transaction At(int index);
    }
}