using BankAccount.Infrastructure;
using BankAccount.Infrastructure.Repository;
using BankAccount.Model.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BankAccount.UnitTests.Infrastructure.Repository
{
    [TestClass]
    public class InMemoryTransactionsShould
    {
        [TestMethod]
        public void StoreTransactions()
        {
            var transaction = new Transaction(new Date("10/04/2014"), 100);
            var transactions = new InMemoryTransactions();

            transactions.Add(transaction);

            Assert.AreEqual(1, transactions.Count());
            Assert.AreEqual(transaction, transactions.At(0));
        }
    }
}