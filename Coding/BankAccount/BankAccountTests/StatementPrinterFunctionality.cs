using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BankAccount;

using Moq;
using System.Collections.Generic;

namespace BankAccountTests
{
    [TestClass]
    public class StatementPrinterFunctionality
    {
        Mock<IConsole> mockConsole;
        StatementPrinter printer;

        [TestInitialize]
        public void Setup()
        {
            mockConsole = new Mock<IConsole>();
            printer = new StatementPrinter(mockConsole.Object);
        }


        [TestMethod]
        public void PrintWritesHeaderEvenIfListIsEmpty()
        {
            mockConsole.Setup(m => m.Write(It.IsAny<string>()));

            printer.Print(new List<Transaction>());

            mockConsole.Verify(m => m.Write("DATE | AMOUNT | BALANCE"));
        }
        
        [TestMethod]
        public void PrintWritesTransactionInReverseChronologialOrderAndIncludesRunningBalance()
        {
            int index = 0;

            List<string> orderOfCalls = new List<string>()
            {
                "DATE | AMOUNT | BALANCE",
                "03/04/2014 | 300.00 | 400.00",
                "02/04/2014 | -100.00 | 100.00",
                "01/04/2014 | 200.00 | 200.00"
            };

            mockConsole.Setup(m => m.Write(It.IsAny<string>())).Callback((string message) =>
            {
                Assert.AreEqual(orderOfCalls[index++], message);
            });

            List<Transaction> transactions = new List<Transaction>()
            {
                new Transaction("01/04/2014", 200),
                new Transaction("02/04/2014", -100),
                new Transaction("03/04/2014", 300)
            };

            printer.Print(transactions);

            Assert.AreEqual(orderOfCalls.Count, index);
        }
    }
}
