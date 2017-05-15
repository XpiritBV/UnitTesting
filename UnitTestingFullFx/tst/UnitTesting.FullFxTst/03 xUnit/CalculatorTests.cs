using Xunit;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTesting.Tst.XUnit
{
    public class CalculatorTests
    {
        //Show Output during run
        //visit https://github.com/nunit/docs/wiki/Attributes for more options

        [Fact]
        //[RequiresThread]
        public void Calculator_Add_OneAndOneEqualsTwo()
        {
            Debug.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            
            //arrage
            var calc = new Calculator();
           
            //act
            var result = calc.Add(1, 1);
            
            //assert
            Assert.Equal(2, result);           
        }

        /// <summary>
        /// Results in 3 unit tests
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, -1)]
        [InlineData(1, 0)]
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
                    Assert.Equal(2, result);
                    break;
                case -1:
                    Assert.Equal(0, result);
                    break;
                case 0:
                    Assert.Equal(1, result);
                    break;
            }
        }
    }
}
