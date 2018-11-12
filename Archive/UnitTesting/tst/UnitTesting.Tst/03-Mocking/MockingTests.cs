using System;
using System.Collections.Generic;
using System.Linq;
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
            // Arrange
            var program = new Program();
            // Act
            var results = await program.GetShapesAsync();
            // Assert, never works
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public async Task Program_ShapeCountTest()
        {
            // Arrange
            var repo = new MockRepository(new Shape[] { new Circle(1.0D), new Square(1.0D, 2.0D) });
            
            var program = new Program(repo);
            // Act
            var results = await program.GetShapesAsync();
            // Assert
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public async Task Program_ShapeAreaTest()
        {
            // Arrange
            var repo = new MockRepository(new Shape[] { new Circle(1.0D), new Square(1.0D, 2.0D) });
            
            var program = new Program(repo);
            // Act
            var results = await program.GetShapesByAreaAsync(0d);
            // Assert
            Assert.AreEqual(2, results.Count());
        }
    }

    /// <summary>
    /// Repository implementation.
    /// (Imagine that this connects to a database server on the network.)
    /// </summary>
    internal class MockRepository : IRepository
    {
        public IEnumerable<Shape> AllResults { get; }

        public Func<Task<IEnumerable<Shape>>> GetAllShapesImplementation { get; set; }

        public Func<double, Task<IEnumerable<Shape>>> GetShapeByAreaImplementation { get; set; }

        public MockRepository(IEnumerable<Shape> AllResults)
        {
            GetAllShapesImplementation = () => Task.FromResult(AllResults);
            GetShapeByAreaImplementation = area => Task.FromResult(AllResults.Where(shape => shape.Area >= area));
        }

        /// <summary>
        /// Connects to a database server on the network and returns all shapes in the store.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Shape>> GetAllShapes()
        {
            return GetAllShapesImplementation();
        }

        public Task<IEnumerable<Shape>> GetShapeByArea(double area)
        {
            return GetShapeByAreaImplementation(area);
        }
    }
}
