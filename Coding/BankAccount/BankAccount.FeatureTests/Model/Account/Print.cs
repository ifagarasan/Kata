using BankAccount.Infrastructure.Console;
using BankAccount.Infrastructure.Date;
using BankAccount.Infrastructure.Repository;
using BankAccount.Model.Account.Statement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankAccount.FeatureTests.Model.Account
{
    [TestClass]
    public class Print
    {
        [TestMethod]
        public void PrintStatement()
        {
            var expectations = new[] {
                "DATE | AMOUNT | BALANCE",
                "10/04/2014 | 500.00 | 1400.00",
                "02/04/2014 | -100.00 | 900.00",
                "01/04/2014 | 1000.00 | 1000.00"
            };

            var index = 0;
            var consoleMock = new Mock<IConsole>();

            consoleMock.Setup(m => m.Write(It.IsAny<string>())).Callback((string message) =>
            {
                Assert.AreEqual(expectations[index++], message);
            });

            var mockDateProvider = new Mock<IDateProvider>();
            mockDateProvider.SetupSequence(m => m.Now())
                .Returns(new Date("01/04/2014"))
                .Returns(new Date("02/04/2014"))
                .Returns(new Date("10/04/2014"));

            var account = new BankAccount.Model.Account.Account(new TransactionRepository(mockDateProvider.Object),
                new Printer(consoleMock.Object));

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);

            account.PrintStatement();

            consoleMock.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(4));
        }
    }
}
