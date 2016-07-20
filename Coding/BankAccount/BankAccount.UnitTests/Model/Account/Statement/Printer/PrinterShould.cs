using System.Collections.Generic;
using BankAccount.Infrastructure.Console;
using BankAccount.Infrastructure.Date;
using BankAccount.Model.Account.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankAccount.UnitTests.Model.Account.Printer
{
    [TestClass]
    public class PrinterShould
    {
        BankAccount.Model.Account.Statement.Printer _printer;
        Mock<IConsole> _consoleMock;

        [TestInitialize]
        public void Setup()
        {
            _consoleMock = new Mock<IConsole>();
            _consoleMock.Setup(m => m.Write(It.IsAny<string>()));

            _printer = new BankAccount.Model.Account.Statement.Printer(_consoleMock.Object);
        }

        [TestMethod]
        public void PrintHeader()
        {
            _printer.PrintStatements(new List<Transaction>());

            _consoleMock.Verify(m => m.Write("DATE | AMOUNT | BALANCE"));
        }

        [TestMethod]
        public void PrintStatementsInOrder()
        {
            var transactions = new List<Transaction>
            {
                new Transaction(new Date("20/04/2012"), 100),
                new Transaction(new Date("21/04/2012"), -50),
            };

            var expectedList = new ExpectedList(new []
            {
                "DATE | AMOUNT | BALANCE",
                "21/04/2012 | -50.00 | 50.00",
                "20/04/2012 | 100.00 | 100.00",
            });

            _consoleMock.Setup(m => m.Write(It.IsAny<string>())).Callback((string message) =>
            {
                Assert.AreEqual(expectedList.Current, message);
            });

            _printer.PrintStatements(transactions);

            _consoleMock.Verify(m => m.Write(It.IsAny<string>()));
        }
    }

    internal class ExpectedList
    {
        private readonly Queue<string> _expected;

        public ExpectedList(string[] expected)
        {
            _expected = new Queue<string>(expected);   
        }

        public string Current => _expected.Dequeue();
    }
}
