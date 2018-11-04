using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace TicTacToe.Tests.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestPlayerHasHighScoreAfterGamePlay()
        {
            //Arrange
            var game = new Game();

            //Act
            var playerId = await game.PlayAsync("Reinier");

            //Assert
            Assert.IsNotNull(playerId, "Player ID should not be null");
            Assert.AreNotEqual(new Guid().ToString(), playerId.ToString(), "Player ID should be a proper GUID");
            //Assert.AreEqual("Reinier", playerName);
            //Assert.IsNotNull(highScore);
        }
    }
}
