using Xunit;

namespace TicTacToe.Tests.xUnit
{
    public class GameTests
    {
        private Game Game { get; }

        public GameTests()
        {
            Game = new Game();
        }

        [Fact]
        public void TestPlayerHasHighScoreAfterGamePlay()
        {
            //Arrange
            const string playerName = "Reinier";

            //Act
            Game.Play(playerName);

            var (highscoreName, highscore) = Game.GetScore(playerName);

            //Assert
            Assert.Equal(playerName, highscoreName);
            Assert.True(highscore > 0);
            Assert.True(highscore < 100);
        }

        [Theory]
        [InlineData("Reinier", 0, 100)]
        [InlineData("Marc", 0, 100)]
        [InlineData("Marcel", 0, 100)]
        [InlineData("Alex", 0, 100)]
        public void TestPlayerHasHighScoreAfterGamePlay_Alternative(string playerName, int minScore, int maxScore)
        {
            //Arrange

            //Act
            Game.Play(playerName);

            var (highscoreName, highscore) = Game.GetScore(playerName);

            //Assert
            Assert.Equal(playerName, highscoreName);
            Assert.True(highscore > minScore);
            Assert.True(highscore < maxScore);
        }
    }
}
