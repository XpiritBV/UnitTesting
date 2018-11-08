using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsRegular
    {
        [Fact]
        public async Task TestPlayerHasHighScoreAfterGamePlay()
        {
            //Arrange
            var game = new GameWithoutIoC();

            const string playerName = "Reinier";

            //Act
            await game.PlayAsync(playerName).ConfigureAwait(false);

            var (highScoreName, highScore) = await game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.True(highScoreName == playerName); //What is wrong with this?

            Assert.Equal(playerName, highScoreName);

            //Statement below might be better, but isn't possible with xUnit
            //Assert.Equal(playerName, highScoreName, "because the highscore belongs to the player playing the game");

            //NUnit:
            //Assert.That(playerName, Is.EqualTo(highScoreName), “Playername and highscorename should be equal because the highscore belongs to the player playing the game”);

            Assert.InRange(highScore, 0, 100);
        }
    }
}
