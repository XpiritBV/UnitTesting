using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsCallback
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        public GameTestsCallback()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
            HighScoreServiceMock = MockRepository.Create<IHighScoreService>();

            Game = new Game(HighScoreServiceMock.Object);
        }

        [Fact]
        public async Task TestPlayerHasHighScoreAfterGamePlay_CallbackHighScore()
        {
            const string playerName = "Reinier";

            //Arrange HighScoreService for saving a highscore
            int recordedHighScore = -1;

            HighScoreServiceMock
                .Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100)))
                .Returns(Task.CompletedTask)
                .Callback<string, int>((_, savedScore) => recordedHighScore = savedScore);

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            //Arrange HighScoreServiceMock with recorded highscore
            HighScoreServiceMock
                .Setup(service => service.GetHighScoreAsync(playerName))
                .Returns(Task.FromResult(recordedHighScore));

            var (highScoreName, highScore) = await Game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.Equal(playerName, highScoreName);
            Assert.Equal(recordedHighScore, highScore);
            Assert.True(highScore > 0);
            Assert.True(highScore < 100);

            MockRepository.VerifyAll();
        }
    }
}
