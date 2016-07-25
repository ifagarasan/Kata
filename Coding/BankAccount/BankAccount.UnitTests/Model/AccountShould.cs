using BankAccount.Infrastructure.Repository;
using BankAccount.Model;
using BankAccount.Model.Repository;
using BankAccount.Model.Statement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BankAccount.UnitTests.Model
{
    [TestClass]
    public class AccountShould
    {
        const int Amount = 100;
        TransactionRepository _transactionRepository;
        Account _account;
        Transactions _transactions;
        StatementPrinter _statementPrinter;

        [TestInitialize]
        public void Setup()
        {
            _statementPrinter = Substitute.For<StatementPrinter>();
            _transactions = new InMemoryTransactions();
            _transactionRepository = Substitute.For<TransactionRepository>();
            _transactionRepository.Transactions().Returns(_transactions);
            _account = new Account(_transactionRepository, _statementPrinter);
        }

        [TestMethod]
        public void StoreDepositTransaction()
        {
            _account.Deposit(Amount);
            
            _transactionRepository.Received().AddDeposit(Amount);
        }

        [TestMethod]
        public void StoreWithdrawTransaction()
        {
            _account.Withdraw(Amount);

            _transactionRepository.Received().AddWithdraw(Amount);
        }

        [TestMethod]
        public void PrintStatement()
        {
            _account.PrintStatement();

            _statementPrinter.Received().Print(_transactions);
        }
    }
}