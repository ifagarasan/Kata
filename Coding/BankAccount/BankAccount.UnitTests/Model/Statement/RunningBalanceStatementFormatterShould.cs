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
    public class RunningBalanceStatementFormatterShould
    {
        private RunningBalanceStatementFormatter _runningBalanceStatementFormatter;

        [TestInitialize]
        public void Setup()
        {
            _runningBalanceStatementFormatter = new RunningBalanceStatementFormatter();
        }

        [TestMethod]
        public void FormatStatementHeader()
        {
            Assert.AreEqual("DATE | AMOUNT | BALANCE", _runningBalanceStatementFormatter.FormatHeader());
        }

        [TestMethod]
        public void FormatTransaction()
        {
            Transaction transaction = new Transaction(new Date("10/03/2003"), 275);
            var runningBalance = 300;

            Assert.AreEqual("10/03/2003 | 275.00 | 300.00", _runningBalanceStatementFormatter.FormatTransaction(transaction, runningBalance));
        }
    }
}