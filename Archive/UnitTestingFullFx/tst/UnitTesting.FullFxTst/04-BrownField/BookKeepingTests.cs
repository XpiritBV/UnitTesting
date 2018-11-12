using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.FullFx.BrownField.Tests
{
    [TestClass()]
    public class BookKeepingTests
    {
        [TestMethod()]
        public void AddAccountTest()
        {
            // Arrange
            var bookKeeping = new BookKeeping();
            var account = bookKeeping.AddAccount("first");

            // Act
            account.DebitTransactionHandler.AddTransaction(30);
            account.CreditTransactionHandler.AddTransaction(10);

            // Assert
            Assert.AreEqual(20d, account.Balance);
        }
    }
}