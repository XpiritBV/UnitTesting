using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsFluent
    {
        [Fact]
        public async Task ShouldHaveHighScoreAfterPlaying()
        {
            //Arrange
            var game = new GameWithoutIoC();

            const string playerName = "Reinier";

            //Act
            await game.PlayAsync(playerName).ConfigureAwait(false);

            var (highScoreName, highScore) = await game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            highScoreName.Should().Be(playerName, "the game should save the highscore of the player currently playing");
            highScoreName.Should().Be(playerName, because: "the game should save the highscore of the player currently playing");
            highScoreName.Should().Be(playerName, "because the game should save the highscore of the player currently playing");

            highScore.Should().BeInRange(0, 100, "the score is determined with 0 and 100 as excluded boundaries");

            highScoreName.Should().StartWith("R").And.Contain("einie").And.EndWith("r").And.HaveLength(7);
        }
    }
}
