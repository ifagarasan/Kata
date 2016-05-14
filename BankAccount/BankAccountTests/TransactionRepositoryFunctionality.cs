using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BankAccount;

using Moq;
using System.Collections.Generic;

namespace BankAccountTests
{
    [TestClass]
    public class TransactionRepositoryFunctionality
    {
        Mock<IDateGenerator> mockDateGenerator;
        TransactionRepository repository;
        string date = "04/02/2016";

        [TestInitialize]
        public void Setup()
        {
            mockDateGenerator = new Mock<IDateGenerator>();
            mockDateGenerator.Setup(m => m.TodayAsString()).Returns(date);
            repository = new TransactionRepository(mockDateGenerator.Object);
        }

        [TestMethod]
        public void AddDepositInsertsAddsTransaction()
        {
            int amount = 100;

            repository.AddDeposit(amount);

            IList<Transaction> transactions = repository.GetAllTransactions();

            Assert.AreEqual(1, transactions.Count);

            Transaction expected = new Transaction(date, amount);
            Assert.IsTrue(expected.Equals(transactions[0]));
        }

        [TestMethod]
        public void AddWithdrawalInsertsAddsTransactionWIthNegativeAmount()
        {
            int amount = 100;

            repository.AddWithdrawal(amount);

            IList<Transaction> transactions = repository.GetAllTransactions();

            Assert.AreEqual(1, transactions.Count);

            Transaction expected = new Transaction(date, -amount);
            Assert.IsTrue(expected.Equals(transactions[0]));
        }
    }
}
