using BankAccount.Infrastructure.Console;
using BankAccount.Infrastructure.Repository;
using BankAccount.Model;
using BankAccount.Model.Repository;
using BankAccount.Model.Statement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BankAccount.UnitTests.Model.Statement
{
    [TestClass]
    public class RunningBalanceStatementPrinterShould
    {
        private const string Header = "DATE | AMOUNT | BALANCE";

        Console _console;
        TransactionFormatter _formatter;
        private RunningBalanceStatementPrinter _runningBalanceStatementPrinter;

        [TestInitialize]
        public void Setup()
        {
            _console = Substitute.For<Console>();
            _formatter = Substitute.For<TransactionFormatter>();
            _runningBalanceStatementPrinter = new RunningBalanceStatementPrinter(_formatter, _console);
        }

        [TestMethod]
        public void AlwaysPrintStatementHeader()
        {
            _formatter.FormatHeader().Returns(Header);

            _runningBalanceStatementPrinter.Print(new InMemoryTransactions());

            _formatter.Received().FormatHeader();
            _console.Received().Write(Header);
        }

        [TestMethod]
        public void PrintTransactionsInReverseOrder()
        {
            var transactions = new InMemoryTransactions();
            transactions.Add(new Transaction(new Date("10/02/2014"), 500));
            transactions.Add(new Transaction(new Date("11/02/2014"), -100));

            _runningBalanceStatementPrinter.Print(transactions);

            Received.InOrder(() =>
            {
                _formatter.FormatHeader();
                _formatter.FormatTransaction(transactions.At(1), 400);
                _formatter.FormatTransaction(transactions.At(0), 500);
            });
        }
    }
}