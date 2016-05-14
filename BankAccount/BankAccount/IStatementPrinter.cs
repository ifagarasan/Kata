using System.Collections.Generic;

namespace BankAccount
{
    public interface IStatementPrinter
    {
        void Print(IList<Transaction> list);
    }
}