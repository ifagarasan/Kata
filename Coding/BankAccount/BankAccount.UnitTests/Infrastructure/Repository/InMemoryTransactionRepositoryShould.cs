using BankAccount.Infrastructure;
using BankAccount.Infrastructure.Repository;
using BankAccount.Model.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Extensions;

namespace BankAccount.UnitTests.Infrastructure.Repository
{
    [TestClass]
    public class InMemoryTransactionRepositoryShould
    {
        Transactions _transactions;
        Clock _clock;
        private const int Amount = 100;
        readonly Date _createdAt = new Date("10/11/2004");
        private InMemoryTransactionRepository _transactionRepository;

        [TestInitialize]
        public void Setup()
        {
            _transactions = Substitute.For<Transactions>();
            _clock = Substitute.For<Clock>();
            _clock.Today().Returns(_createdAt);
            _transactionRepository = new InMemoryTransactionRepository(_transactions, _clock);
        }

        [TestMethod]
        public void CreateAndStoreADepositTransaction()
        {
            _transactionRepository.AddDeposit(Amount);

            _transactions.Received().Add(new Transaction(_createdAt, Amount));
        }

        [TestMethod]
        public void CreateAndStoreWithdrawTransaction()
        {
            _transactionRepository.AddWithdraw(Amount);

            _transactions.Received().Add(new Transaction(_createdAt, -Amount));
        }

        [TestMethod]
        public void RetrieveTransactions()
        {
            Assert.AreEqual(_transactions, _transactionRepository.Transactions());
        }
    }
}