using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsLoose
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        public GameTestsLoose()
        {
            MockRepository = new MockRepository(MockBehavior.Loose);
            HighScoreServiceMock = MockRepository.Create<IHighScoreService>();

            //Alternatives:
            //var highScoreService = new Mock<IHighScoreService>(MockBehavior.Loose);
            //var highScoreService = Mock.Of<IHighScoreService>();

            Game = new Game(HighScoreServiceMock.Object);
        }

        [Fact]
        public async Task TestPlayerHasHighScoreAfterGamePlay_NoArrange() //Huray, green! But is it OK?
        {
            const string playerName = "Reinier";

            //Arrange

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            //Arrange HighScoreServiceMock with recorded highscore
            var (highScoreName, highScore) = await Game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.Equal(playerName, highScoreName);
            Assert.InRange(highScore, 0, 100);

            MockRepository.VerifyAll();
        }

        [Fact]
        public async Task TestPlayerHasHighScoreAfterGamePlay()
        {
            //Arrange
            const string playerName = "Reinier";

            HighScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100))).Returns(Task.CompletedTask);
            HighScoreServiceMock.Setup(service => service.GetHighScoreAsync(playerName)).Returns(Task.FromResult(99));

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            var (highScoreName, highScore) = await Game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.Equal(playerName, highScoreName);
            Assert.InRange(highScore, 0, 100);

            MockRepository.VerifyAll();
        }
    }
}
