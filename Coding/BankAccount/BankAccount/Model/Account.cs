using BankAccount.Model.Repository;
using BankAccount.Model.Statement;

namespace BankAccount.Model
{
    public class Account
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly StatementPrinter _statementPrinter;

        public Account(TransactionRepository transactionRepository, StatementPrinter statementPrinter)
        {
            _transactionRepository = transactionRepository;
            _statementPrinter = statementPrinter;
        }

        public void Deposit(int amount) => _transactionRepository.AddDeposit(amount);

        public void Withdraw(int amount) => _transactionRepository.AddWithdraw(amount);

        public void PrintStatement() => _statementPrinter.Print(_transactionRepository.Transactions());
    }
}