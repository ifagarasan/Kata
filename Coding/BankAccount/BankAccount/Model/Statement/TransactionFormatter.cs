using BankAccount.Infrastructure.Repository;

namespace BankAccount.Model.Statement
{
    public interface TransactionFormatter
    {
        string FormatHeader();
        string FormatTransaction(Transaction transaction, int runningBalance);
    }
}