using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests.xUnit.Moq
{
    public class GameTestsStrict
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        public GameTestsStrict()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
            HighScoreServiceMock = MockRepository.Create<IHighScoreService>();

            Game = new Game(HighScoreServiceMock.Object);
        }

        [Fact]
        public async Task TestPlayerHasHighScoreAfterGamePlay()
        {
            //Arrange
            const string playerName = "Reinier";

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            var (highscoreName, highscore) = await Game.GetScoreAsync(playerName).ConfigureAwait(false);

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
        public async Task TestPlayerHasHighScoreAfterGamePlay_Alternative(string playerName, int minScore, int maxScore)
        {
            //Arrange

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            var (highscoreName, highscore) = await Game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.Equal(playerName, highscoreName);
            Assert.True(highscore > minScore);
            Assert.True(highscore < maxScore);
        }
    }
}
