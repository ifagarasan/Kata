using System;
using BankAccount.Infrastructure.Date;
using BankAccount.Infrastructure.Repository;
using BankAccount.Model.Account.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankAccount.UnitTests.Infrastructure.Repository
{
    [TestClass]
    public class TransactionRepositoyShould
    {
        readonly Date _creationDate = new Date(DateTime.Now.ToShortDateString());
        Mock<IDateProvider> _dateProviderMock;
        TransactionRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _dateProviderMock = new Mock<IDateProvider>();
            _dateProviderMock.Setup(m => m.Now()).Returns(_creationDate);

            _repository = new TransactionRepository(_dateProviderMock.Object);
        }

        [TestMethod]
        public void AddDeposit()
        {
            var amount = 100;
            _repository.AddDeposit(amount);

            Assert.AreEqual(_repository.Transactions[0], new Transaction(_creationDate, amount));
        }

        [TestMethod]
        public void AddWithdrawal()
        {
            var amount = 100;
            _repository.AddWithdraw(amount);

            Assert.AreEqual(_repository.Transactions[0], new Transaction(_creationDate, -amount));
        }
    }
}
