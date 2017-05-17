using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using UnitTesting.ClassLibrary.Mocking;

namespace UnitTesting.Tst.Mocking
{
    [TestClass]
    public class NSubstituteTests
    {
        [TestMethod]
        public async Task Program_ShapeCountTest()
        {
            //arrange
            var mock = Substitute.For<IRepository>();
            IEnumerable<Shape> fixedResults = new Shape[] { new Circle(1.0D), new Square(1.0D, 2.0D) };
            mock.GetAllShapes().Returns(Task.FromResult(fixedResults));
            var program = new Program(mock);
            //act
            var results = await program.GetShapesAsync();
            //assert
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public async Task Program_ShapeAreaTest()
        {
            //arrange
            var mock = Substitute.For<IRepository>();
            IEnumerable<Shape> fixedResults = new Shape[] { new Circle(1.0D), new Square(1.0D, 2.0D) };
            mock.GetShapeByArea(Arg.Is<double>(i => i >= 2D && i <= 4D)).Returns(Task.FromResult(fixedResults));
            var program = new Program(mock);
            
            //act
            var results = await program.GetShapesByAreaAsync(2D);
            //assert
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public async Task Program_ShapeAreaEmptyTest()
        {
            //arrange
            var mock = Substitute.For<IRepository>();
            mock.GetShapeByArea(Arg.Is<double>(i => i >= 2D && i <= 4D)).Returns(Task.FromResult(Enumerable.Empty<Shape>()));
            var program = new Program(mock);

            //act
            var results = await program.GetShapesByAreaAsync(2D);
            //assert
            Assert.AreEqual(0, results.Count());

            //special asserts
            await mock.Received().GetShapeByArea(2D);
            await mock.DidNotReceive().GetShapeByArea(1D);
            await mock.Received().GetShapeByArea(Arg.Any<double>());
        }
    }
}
