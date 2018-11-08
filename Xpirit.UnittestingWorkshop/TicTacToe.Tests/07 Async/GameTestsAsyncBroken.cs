using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsAsyncBroken
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        public GameTestsAsyncBroken()
        {
            MockRepository = new MockRepository(MockBehavior.Loose); //Behavior set to loose for this example!
            HighScoreServiceMock = MockRepository.Create<IHighScoreService>();

            Game = new Game(HighScoreServiceMock.Object);
        }

        [Fact(Skip = "NullReferenceException for some reason")]
        public async Task TestPlayerHasHighScoreAfterGamePlay_AsyncIssue()
        {
            //Arrange
            const string playerName = "Reinier";

            HighScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100)));
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
