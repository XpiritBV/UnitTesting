using Xunit;
using System.Diagnostics;
using System.Threading;

namespace UnitTesting.Tst.XUnit
{
    public class CalculatorTests
    {
        //Show Output during run
        //visit https://xunit.github.io/ for more options

        [Fact]
        public void Calculator_Add_OneAndOneEqualsTwo()
        {
            Debug.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            
            // Arrange
            var calc = new Calculator();
           
            // Act
            var result = calc.Add(1, 1);
            
            // Assert
            Assert.Equal(2, result);           
        }

        /// <summary>
        /// Results in 3 unit tests
        /// </summary>
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, -1, 0)]
        [InlineData(1, 0, 1)]
        public void Calculator_Add(int left, int right, int expectedResult)
        {
            Debug.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");

            // Arrage
            var calc = new Calculator();
            
            // Act
            var result = calc.Add(left, right);
            
            // Assert
            Assert.Equal(expectedResult, result);
           
        }
    }
}
