using NUnit.Framework;
using System.Diagnostics;
using System.Threading;

namespace UnitTesting.Tst.Nunit
{
    [TestFixture]
    public class CalculatorTests : AssertionHelper //optional base class!
    {
        //Show Output during run
        //visit https://github.com/nunit/docs/wiki/Attributes for more options

        [Test]
        [RequiresThread]
        public void Calculator_Add_OneAndOneEqualsTwo()
        {
            Debug.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            
            // Arrange
            var calc = new Calculator();
           
            // Act
            var result = calc.Add(1, 1);
            
            ///////////////multiple ways to describe the same assertion:

            // Assert
            Assert.AreEqual(2, result, "Add 1+1 not 2");
            // Assert style 2
            Assert.That(result, Is.EqualTo(2));
            // Assert using base class
            Expect(result, EqualTo(2));
        }

        /// <summary>
        /// Results in 3 unit tests
        /// </summary>
        [Test]
        [TestCase(1, 1, 2, "Add 1+1 not 2")]
        [TestCase(1, -1, 0, "Add 1+-1 not 0")]
        [TestCase(1, 0, 1, "Add 1+0 not 1")]
        public void Calculator_Add(int left, int right, int expectedResult, string message)
        {
            Debug.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");

            // Arrage
            var calc = new Calculator();
            
            // Act
            var result = calc.Add(left, right);
            
            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), message);
        }
    }
}
