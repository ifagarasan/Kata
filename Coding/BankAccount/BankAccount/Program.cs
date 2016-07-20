using BankAccount.Infrastructure.Console;
using BankAccount.Infrastructure.Date;
using BankAccount.Infrastructure.Repository;
using BankAccount.Model.Account.Statement;

namespace BankAccount
{
    class Program
    {
        static void Main()
        {
            var account = Account();

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);

            account.PrintStatement();
        }

        private static Model.Account.Account Account() => new Model.Account.Account(
                new TransactionRepository(new DateProvider()),
                new Printer(new Console())
            );
    }
}
