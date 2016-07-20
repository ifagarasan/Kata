using System.Collections.Generic;
using BankAccount.Model.Account.Repository;

namespace BankAccount.Model.Account.Statement
{
    public interface IPrinter
    {
        void PrintStatements(List<Transaction> transactions);
    }
}