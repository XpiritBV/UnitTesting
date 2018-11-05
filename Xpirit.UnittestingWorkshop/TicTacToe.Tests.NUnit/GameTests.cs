using NUnit.Framework;

namespace TicTacToe.Tests.NUnit
{
    public class GameTests
    {
        private Game Game { get; set; }

        [SetUp]
        public void TestInitialize()
        {
            Game = new Game();
        }

        [Test]
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
