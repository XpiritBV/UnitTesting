using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting.ClassLibrary;
using UnitTesting.ClassLibrary.TestDriven;

namespace UnitTesting.Tst.TestDriven
{
    [TestClass]
    public class TightCouplingTests
    {
        [TestMethod]   //this will fail until the DUT is implemented.
        public void GivenOneAndOneWhenAddingThenOutcomeEqualsTwo()
        {
            //given
            int left = 1;
            int right = 1;
            var calculator = new Calculator();
            //when
            int result = calculator.Add(left, right);
            //then
            Assert.AreEqual(2, result, "Adding 1 and 1 should return 2.");
        }


        [TestMethod]    //this will fail until the DUT is implemented.
        public void GivenOneAndNegativeOneWhenAddingThenOutcomeEqualsTwo()
        {
            //given
            int left = 1;
            int right = 1;
            var calculator = new Calculator();
            //when
            int result = calculator.Add(left, right);
            //then
            Assert.AreEqual(0, result, "Adding 1 and -1 should return 0.");
        }
    }
}
