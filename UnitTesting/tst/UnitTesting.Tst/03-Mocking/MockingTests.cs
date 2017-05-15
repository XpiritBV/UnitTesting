using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting.ClassLibrary.Mocking;

namespace UnitTesting.Tst.Mocking
{
    [TestClass]
    public class MockingTests
    {
        [TestMethod] //this will always fail
        public async Task Program_FailingShapeCountTest()
        {
            //arrange
            var program = new Program();
            //act
            var results = await program.GetShapesAsync();
            //assert, never works
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public async Task Program_ShapeCountTest()
        {
            //arrange
            var repo = new MockRepository();
            var program = new Program(repo);
            //act
            var results = await program.GetShapesAsync();
            //assert
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public async Task Program_ShapeAreaTest()
        {
            //arrange
            var repo = new MockRepository();
            var program = new Program(repo);
            //act
            var results = await program.GetShapesAsync();
            //assert
            Assert.AreEqual(2, results.Count());
        }
    }

    /// <summary>
    /// Repository implementation.
    /// (Imagine that this connects to a database server on the network.)
    /// </summary>
    internal class MockRepository : IRepository
    {
        private IEnumerable<Shape> _allResults = new Shape[] { new Circle(1.0D), new Square(1.0D, 2.0D) };

        /// <summary>
        /// Connects to a database server on the network and returns all shapes in the store.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Shape>> GetAllShapes()
        {            
            return Task.FromResult(_allResults);
        }

        public Task<IEnumerable<Shape>> GetShapeByArea(double area)
        {
            return Task.FromResult(_allResults.Where(shape => shape.Area == area));
        }
    }
}
