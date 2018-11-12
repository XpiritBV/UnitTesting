using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTesting.ClassLibrary;

namespace UnitTesting.Tst
{
    [TestClass]
    public class VisualStudioTests
    {
        [TestMethod]
        public void ExceptionHelperTest()
        {
            var chain = new Chain();
            Assert.ThrowsException<NullReferenceException>(() => 
            {
                chain.AddLink(LinkFactory.CreateOne()).AddLink(LinkFactory.CreateTwo()).AddLink(LinkFactory.CreateThree());                
            });
        }
    }
}
