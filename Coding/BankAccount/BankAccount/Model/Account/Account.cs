using BankAccount.Model.Account.Repository;
using BankAccount.Model.Account.Statement;

namespace BankAccount.Model.Account
{
    public class Account
    {
        private readonly IRepository _repository;
        private readonly IPrinter _printer;

        public Account(IRepository repository, IPrinter printer)
        {
            _repository = repository;
            _printer = printer;
        }

        public void Deposit(decimal amount) => _repository.AddDeposit(amount);

        public void Withdraw(decimal amount) => _repository.AddWithdraw(amount);

        public void PrintStatement() => _printer.PrintStatements(_repository.Transactions);
    }
}