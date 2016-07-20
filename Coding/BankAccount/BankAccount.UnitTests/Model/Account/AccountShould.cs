using System.Collections.Generic;
using BankAccount.Model.Account.Repository;
using BankAccount.Model.Account.Statement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankAccount.UnitTests.Model.Account
{
    [TestClass]
    public class AccountShould
    {
        Mock<IRepository> _repositoryMock;
        Mock<IPrinter> _statementPrinterMock;
        BankAccount.Model.Account.Account _account;

        [TestInitialize]
        public void Setup()
        {
            _statementPrinterMock = new Mock<IPrinter>();
            _repositoryMock = new Mock<IRepository>();

            _account = new BankAccount.Model.Account.Account(_repositoryMock.Object, _statementPrinterMock.Object);
        }

        [TestMethod]
        public void Deposit()
        {
            var amount = 100;
            _repositoryMock.Setup(m => m.AddDeposit(It.IsAny<decimal>()));

            _account.Deposit(amount);

            _repositoryMock.Verify(m => m.AddDeposit(amount));
        }

        [TestMethod]
        public void Withdraw()
        {
            var amount = 100;
            _repositoryMock.Setup(m => m.AddWithdraw(It.IsAny<decimal>()));

            _account.Withdraw(amount);

            _repositoryMock.Verify(m => m.AddWithdraw(amount));
        }

        [TestMethod]
        public void PrintStatement()
        {
            var transactions = new List<Transaction>();

            _repositoryMock.Setup(m => m.Transactions).Returns(transactions);
            _statementPrinterMock.Setup(m => m.PrintStatements(It.IsAny<List<Transaction>>()));

            _account.PrintStatement();

            _statementPrinterMock.Verify(m => m.PrintStatements(transactions));
        }
    }
}
