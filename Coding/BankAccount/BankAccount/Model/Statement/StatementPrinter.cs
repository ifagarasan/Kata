using BankAccount.Model.Repository;

namespace BankAccount.Model.Statement
{
    public interface StatementPrinter
    {
        void Print(Transactions transactions);
    }
}