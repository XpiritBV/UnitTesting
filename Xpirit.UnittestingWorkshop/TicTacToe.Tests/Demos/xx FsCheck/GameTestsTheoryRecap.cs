using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsTheoryRecap
    {
        [Theory]
        [InlineData("Reinier", 1, 99)]
        [InlineData("Marc", 1, 99)]
        [InlineData("Marcel", 1, 99)]
        [InlineData("Alex", 1, 99)]
        public async Task TestPlayerHasHighScoreAfterGamePlay_Theory(string playerName, int minScore, int maxScore)
        {
            //Arrange
            var game = new GameWithoutIoC();

            //Act
            await game.PlayAsync(playerName).ConfigureAwait(false);

            var (highScoreName, highScore) = await game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            highScoreName.Should().Be(playerName, "the game should save the highscore of the player currently playing");
            highScore.Should().BeInRange(minScore, maxScore, "the score is determined with 0 and 100 as excluded boundaries");
        }
    }
}
