using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class PlayerHighScore
    {
        public static Arbitrary<decimal> ParcelPrice() =>
            Arb.Default.Decimal().Generator.
            Where(x => x > 0 && x < 20).ToArbitrary();
    }

    public class GameTestsFsCheck
    {
        [Property(Arbitrary = new[] { typeof(PlayerHighScore) })]
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
