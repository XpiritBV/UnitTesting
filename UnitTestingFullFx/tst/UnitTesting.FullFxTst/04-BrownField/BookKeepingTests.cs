using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting.FullFx.BrownField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.FullFx.BrownField.Tests
{
    [TestClass()]
    public class BookKeepingTests
    {
        [TestMethod()]
        public void AddAccountTest()
        {
            //arrange
            var bookKeeping = new BookKeeping();
            var account = bookKeeping.AddAccount("first");

            //act
            account.DebitTransactionHandler.AddTransaction(30);
            account.CreditTransactionHandler.AddTransaction(10);

            //assert
            Assert.AreEqual(20d, account.Balance);
        }
    }
}