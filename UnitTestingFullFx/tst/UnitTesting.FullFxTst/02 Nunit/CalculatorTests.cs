using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

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
            
            //arrage
            var calc = new Calculator();
           
            //act
            var result = calc.Add(1, 1);
            
            ///////////////multiple ways to describe the same assertion:

            //assert
            Assert.AreEqual(2, result, "Add 1+1 not 2");
            //assert style 2
            Assert.That(result, Is.EqualTo(2));
            //assert using base class
            Expect(result, EqualTo(2));
        }

        /// <summary>
        /// Results in 3 unit tests
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        [Test]
        [TestCase(1, 1)]
        [TestCase(1, -1)]
        [TestCase(1, 0)]
        public void Calculator_Add(int left, int right)
        {
            Debug.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");


            //arrage
            var calc = new Calculator();
            //act
            var result = calc.Add(left, right);
            //assert
            switch (right)
            {
                case 1:
                    Assert.AreEqual(2, result, "Add 1+1 not 2");
                    break;
                case -1:
                    Assert.AreEqual(0, result, "Add 1+-1 not 0");
                    break;
                case 0:
                    Assert.AreEqual(1, result, "Add 1+0 not 1");
                    break;
            }
        }
    }
}
