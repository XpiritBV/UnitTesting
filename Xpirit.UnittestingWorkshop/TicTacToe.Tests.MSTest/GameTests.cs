using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Tests.MSTest
{
    [TestClass]
    public class GameTests
    {
        private Game Game { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Game = new Game();
        }

        [TestMethod]
        public void TestPlayerHasHighScoreAfterGamePlay()
        {
            //Arrange
            const string playerName = "Reinier";

            //Act
            Game.Play(playerName);

            var (highscoreName, highscore) = Game.GetScore(playerName);

            //Assert
            Assert.AreEqual(playerName, highscoreName);
            Assert.IsTrue(highscore > 0);
            Assert.IsTrue(highscore < 100);
        }
    }
}
