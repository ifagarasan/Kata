using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StatementPrinter: IStatementPrinter
    {
        IConsole console;
        string header = "DATE | AMOUNT | BALANCE";

        public StatementPrinter(IConsole console)
        {
            this.console = console;
        }

        public void Print(IList<Transaction> list)
        {
            console.Write(header);

            int runningBalance = 0;

            string[] transactionData = new string[list.Count];
            int runningIndex = list.Count - 1;

            foreach (Transaction t in list)
            {
                runningBalance += t.Amount;

                transactionData[runningIndex--] = string.Format("{0} | {1} | {2}", t.Date, ToMoney(t.Amount), ToMoney(runningBalance));
            }

            foreach (string message in transactionData)
                console.Write(message);
        }

        private string ToMoney(int value)
        {
            return value.ToString(".00");
        }
    }
}