using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
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
                //CTRL+ALT+E --> Break on all exceptions in CLR
                var firstLink = new Link(0);
                chain.AddRange(firstLink.AddBlueLink().AddRedLink().AddYellowLink().AddGreenLink());                
            });
        }
    }
}
