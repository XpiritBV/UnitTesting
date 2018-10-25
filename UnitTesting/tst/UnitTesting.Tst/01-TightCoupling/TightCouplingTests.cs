using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting.ClassLibrary.TightCoupling;

namespace UnitTesting.Tst.TightCoupling
{
    /// <summary>
    /// Tests for <see cref="Client"/>. 
    /// Change the code to reliably test Client code.
    /// </summary>
    [TestClass]
    public class TightCouplingTests
    {
        [TestMethod]
        public async Task ClientGetUsersTest()
        {
            // Arrange
            var client = new Client();
           
            // Act
            var users = await client.GetUsersAsync("Graham");
            
            // Assert
            Assert.AreEqual(1, users.Count(), "Unexpected amount of users matched last name 'Graham'.");
        }
    }
}
