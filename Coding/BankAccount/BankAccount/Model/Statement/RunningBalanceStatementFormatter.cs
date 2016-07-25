using BankAccount.Infrastructure.Repository;

namespace BankAccount.Model.Statement
{
    public class RunningBalanceStatementFormatter : TransactionFormatter
    {
        public string FormatHeader() => "DATE | AMOUNT | BALANCE";

        public string FormatTransaction(Transaction transaction, int runningBalance)
            => $"{transaction.CreatedAt.Short} | {Money(transaction.Amount)} | {Money(runningBalance)}";

        private static string Money(int amount) => amount.ToString(".00");
    }
}