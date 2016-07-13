using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        IStatementPrinter statementPrinter;
        ITransactionRepository transactionRepository;

        public Account(ITransactionRepository transactionRepository, IStatementPrinter statementPrinter)
        {
            this.transactionRepository = transactionRepository;
            this.statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            transactionRepository.AddDeposit(amount);
        }

        public void Withdraw(int amount)
        {
            transactionRepository.AddWithdrawal(amount);
        }

        public void PrintStatement()
        {
            statementPrinter.Print(transactionRepository.GetAllTransactions());
        }
    }
}
