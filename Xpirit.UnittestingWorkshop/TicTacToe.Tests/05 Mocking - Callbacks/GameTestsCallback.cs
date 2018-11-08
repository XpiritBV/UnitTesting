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

        [Fact(Skip = "Do fun stuff in Game.cs first!")]
        public async Task TestPlayerHasHighScoreAfterGamePlay_CallbackHighScore()
        {
            //Arrange HighScoreService for saving a highscore
            string recordedPlayerName = null;
            int recordedHighScore = -1;

            HighScoreServiceMock
                .Setup(service => service.SaveAsync(It.IsAny<string>(), It.Is<int>(x => x > 0 && x < 100)))
                .Returns(Task.CompletedTask)
                .Callback<string, int>((savedPlayerName, savedScore) =>
                {
                    recordedPlayerName = savedPlayerName;
                    recordedHighScore = savedScore;
                });

            //Act
            await Game.PlayAsync("Reinier").ConfigureAwait(false);

            //Arrange HighScoreServiceMock with recorded highscore
            HighScoreServiceMock
                .Setup(service => service.GetHighScoreAsync(recordedPlayerName))
                .Returns(Task.FromResult(recordedHighScore));

            var (highScoreName, highScore) = await Game.GetScoreAsync(recordedPlayerName).ConfigureAwait(false);

            //Assert
            Assert.Equal("Reinier", highScoreName);
            Assert.InRange(highScore, 0, 100);

            Assert.Equal(recordedPlayerName, highScoreName);
            Assert.Equal(recordedHighScore, highScore);

            MockRepository.VerifyAll();
        }
    }
}
