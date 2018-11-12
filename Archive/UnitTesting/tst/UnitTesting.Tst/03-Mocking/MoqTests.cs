using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTesting.ClassLibrary.Mocking;

namespace UnitTesting.Tst.Mocking
{
    [TestClass]
    public class MoqTests
    {
        [TestMethod]
        public async Task Program_ShapeCountTest()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            IEnumerable<Shape> fixedResults = new Shape[] { new Circle(1.0D), new Square(1.0D, 2.0D) };
            mock.Setup(m => m.GetAllShapes()).Returns(Task.FromResult(fixedResults));
            var program = new Program(mock.Object);
            // Act
            var results = await program.GetShapesAsync();
            // Assert
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public async Task Program_ShapeAreaTest()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            IEnumerable<Shape> fixedResults = new Shape[] { new Circle(1.0D), new Square(1.0D, 2.0D) };
            mock.Setup(m => m.GetShapeByArea(It.IsInRange(2D, 4D, Range.Inclusive))).Returns(Task.FromResult(fixedResults));
            var program = new Program(mock.Object);
            
            // Act
            var results = await program.GetShapesByAreaAsync(2D);
            // Assert
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public async Task Program_ShapeAreaEmptyTest()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            int callCounter = 0;
            mock.Setup(m => m.GetShapeByArea(It.IsInRange(0D, 2D, Range.Inclusive)))
                .Returns(Task.FromResult(Enumerable.Empty<Shape>())).Callback(()=> callCounter++);

            var program = new Program(mock.Object);

            // Act
            var results = await program.GetShapesByAreaAsync(2D);
            // Assert
            Assert.AreEqual(0, results.Count());

            //special asserts
            Assert.AreEqual(1, callCounter);
            mock.Verify(m => m.GetShapeByArea(It.IsAny<double>()), Times.AtMostOnce);
        }
    }
}
