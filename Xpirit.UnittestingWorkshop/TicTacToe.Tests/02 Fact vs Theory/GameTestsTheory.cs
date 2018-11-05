using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsTheory
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        public GameTestsTheory()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
            HighScoreServiceMock = MockRepository.Create<IHighScoreService>();

            Game = new Game(HighScoreServiceMock.Object);
        }

        [Theory]
        [InlineData("Reinier", 0, 100)]
        [InlineData("Marc", 0, 100)]
        [InlineData("Marcel", 0, 100)]
        [InlineData("Alex", 0, 100)]
        public async Task TestPlayerHasHighScoreAfterGamePlay_Theory(string playerName, int minScore, int maxScore)
        {
            //Arrange
            HighScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > minScore && x < maxScore))).Returns(Task.CompletedTask);
            HighScoreServiceMock.Setup(service => service.GetHighScoreAsync(playerName)).Returns(Task.FromResult(99));

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            var (highscoreName, highscore) = await Game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.Equal(playerName, highscoreName);
            Assert.True(highscore > minScore);
            Assert.True(highscore < maxScore);

            MockRepository.VerifyAll();
        }
    }
}
