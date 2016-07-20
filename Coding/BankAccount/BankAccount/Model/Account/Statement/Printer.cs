using System.Collections.Generic;
using BankAccount.Infrastructure.Console;
using BankAccount.Model.Account.Repository;

namespace BankAccount.Model.Account.Statement
{
    public class Printer : IPrinter
    {
        private const string Header = "DATE | AMOUNT | BALANCE";

        private readonly IConsole _console;

        public Printer(IConsole console)
        {
            _console = console;
        }

        public void PrintStatements(IList<Transaction> transactions)
        {
            _console.Write(Header);

            var runningBalances = ComputeRunningBalances(transactions);

            for (var i = transactions.Count - 1; i >= 0; i--)
                _console.Write(FormatStatement(transactions[i], runningBalances[i]));
        }

        private static decimal[] ComputeRunningBalances(IList<Transaction> transactions)
        {
            var runningBalances = new decimal[transactions.Count];

            var lastRunningBalance = 0m;

            for (var i = 0; i < transactions.Count; ++i)
            {
                runningBalances[i] = lastRunningBalance + transactions[i].Amount;
                lastRunningBalance = runningBalances[i];
            }

            return runningBalances;
        }

        private static string FormatStatement(Transaction transactions, decimal current)
            => $"{transactions.CreatedAt} | {FormatMoney(transactions.Amount)} | {FormatMoney(current)}";

        private static string FormatMoney(decimal amount) => amount.ToString(".00");
    }
}