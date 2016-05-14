using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BankAccount;

using Moq;
using System.Collections.Generic;

namespace BankAccountTests
{
    [TestClass]
    public class AccountAcceptance
    {
        [TestMethod]
        public void PrintStatementPrintsActivity()
        {
            Mock<IConsole> mockConsole = new Mock<IConsole>();
            StatementPrinter statementPrinter = new StatementPrinter(mockConsole.Object);

            string[] dates = { "01/04/2014", "02/04/2014", "10/04/2014" };
            int dateIndex = 0;
            Mock<IDateGenerator> mockDateGenerator = new Mock<IDateGenerator>();
            mockDateGenerator.Setup(m => m.TodayAsString()).Returns(() =>
            {
                return dates[dateIndex++];
            });

            TransactionRepository transactionRepository = new TransactionRepository(mockDateGenerator.Object);

            List<string> orderOfCalls = new List<string>()
            {
                "DATE | AMOUNT | BALANCE",
                string.Format("{0} | 500.00 | 1400.00", dates[2]),
                string.Format("{0} | -100.00 | 900.00", dates[1]),
                string.Format("{0} | 1000.00 | 1000.00", dates[0])
            };

            int index = 0;
            mockConsole.Setup(m => m.Write(It.IsAny<string>())).Callback((string message) =>
            {
                Assert.AreEqual(orderOfCalls[index], message);
                index++;
            });

            Account account = new Account(transactionRepository, statementPrinter);

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);

            account.PrintStatement();

            Assert.AreEqual(orderOfCalls.Count, index);
        }
    }
}
