using BankAccount.Infrastructure;
using BankAccount.Infrastructure.Repository;
using BankAccount.Model.Statement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Console = BankAccount.Infrastructure.Console.Console;

namespace BankAccount.FeatureTests
{
    [TestClass]
    public class Account
    {
        [TestMethod]
        public void PrintStatements()
        {
            var console = Substitute.For<Console>();
            var clock = Substitute.For<Clock>();

            clock.Today().Returns(
                new Date("01/04/2014"),
                new Date("02/04/2014"),
                new Date("10/04/2014")
            );

            var account = CreateAccount(clock, console);
            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);

            account.PrintStatement();

            Received.InOrder(() =>
            {
                console.Write("DATE | AMOUNT | BALANCE");
                console.Write("10/04/2014 | 500.00 | 1400.00");
                console.Write("02/04/2014 | -100.00 | 900.00");
                console.Write("01/04/2014 | 1000.00 | 1000.00");
            });
        }

        private static Model.Account CreateAccount(Clock clock, Console console)
        {
            return new Model.Account(
                new InMemoryTransactionRepository(
                    new InMemoryTransactions(), clock),
                new RunningBalanceStatementPrinter(new RunningBalanceStatementFormatter(), console)
            );
        }
    }
}
