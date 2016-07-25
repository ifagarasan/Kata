using BankAccount.Infrastructure.Console;
using BankAccount.Model.Repository;

namespace BankAccount.Model.Statement
{
    public class RunningBalanceStatementPrinter : StatementPrinter
    {
        private readonly TransactionFormatter _formatter;
        private readonly Console _console;

        public RunningBalanceStatementPrinter(TransactionFormatter formatter, Console console)
        {
            _formatter = formatter;
            _console = console;
        }

        public void Print(Transactions transactions)
        {
            _console.Write(_formatter.FormatHeader());

            var runningBalances = ComputeRunningBalances(transactions);

            for (var i = transactions.Count() - 1; i >= 0; i--)
                _console.Write(_formatter.FormatTransaction(transactions.At(i), runningBalances[i]));
        }

        private static int[] ComputeRunningBalances(Transactions transactions)
        {
            var runningBalances = new int[transactions.Count()];
            var lastRunningBalance = 0;
            for (var i = 0; i < transactions.Count(); ++i)
            {
                runningBalances[i] = transactions.At(i).Amount + lastRunningBalance;
                lastRunningBalance = runningBalances[i];
            }

            return runningBalances;
        }
    }
}