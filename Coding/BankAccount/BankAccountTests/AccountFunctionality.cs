using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BankAccount;

using Moq;
using System.Collections.Generic;

namespace BankAccountTests
{
    [TestClass]
    public class AccountFunctionality
    {
        Account account;
        Mock<ITransactionRepository> mockRepository;
        Mock<IStatementPrinter> mockStatementPrinter;

        [TestInitialize]
        public void Setup()
        {
            mockStatementPrinter = new Mock<IStatementPrinter>();
            mockRepository = new Mock<ITransactionRepository>();
            account = new Account(mockRepository.Object, mockStatementPrinter.Object);
        }

        [TestMethod]
        public void DepositCallsTransactionRepositoryAddDepositWithAmount()
        {
            mockRepository.Setup(m => m.AddDeposit(It.IsAny<int>()));

            int amount = 100;
            account.Deposit(amount);

            mockRepository.Verify(m => m.AddDeposit(amount));
        }

        [TestMethod]
        public void WithdrawCallsTransactionRepositoryAddWithdrawalWithAmount()
        {
            mockRepository.Setup(m => m.AddWithdrawal(It.IsAny<int>()));

            int amount = 100;
            account.Withdraw(amount);

            mockRepository.Verify(m => m.AddWithdrawal(amount));
        }

        [TestMethod]
        public void PrintStatementCallsStatementPrinterPrintPassingAllTransactions()
        {
            List<Transaction> transactions = new List<Transaction>() { new Transaction("04/03/2010", 100) };

            mockRepository.Setup(m => m.GetAllTransactions()).Returns(transactions);

            mockStatementPrinter.Setup(m => m.Print(It.IsAny<List<Transaction>>()));

            Account account = new Account(mockRepository.Object, mockStatementPrinter.Object);

            account.PrintStatement();

            mockStatementPrinter.Verify(m => m.Print(transactions));
        }
    }
}
