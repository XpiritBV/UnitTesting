using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting.FullFx.BrownField;

namespace UnitTesting.FullFxTst
{
    [TestClass]
    public class CalculatorTests
    {
        //TODO: delete this and create unit tests that don't rely on Shims.

        [TestMethod]
        public void GivenCalculator_WhenAddingOneAndOneForDutch_ThenResultIsTwo()
        {
            //arrange
            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2017, 5, 31);

                //act
                var result = MultiCulturalCalculator.Calculate("NL", 1, 1, Operator.Add);

                //assert
                Assert.AreEqual("Resultaat is 2 (31-5-2017 00:00:00)", result);
            }
        }
    }
   
}