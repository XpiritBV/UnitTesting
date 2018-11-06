using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsSetupPerTest
    {
        [Fact]
        public async Task TestPlayerHasHighScoreAfterGamePlay()
        {
            //Arrange
            const string playerName = "Reinier";

            var mockRepository = new MockRepository(MockBehavior.Strict);
            var highScoreServiceMock = mockRepository.Create<IHighScoreService>();

            var game = new Game(highScoreServiceMock.Object);

            highScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100))).Returns(Task.CompletedTask);
            highScoreServiceMock.Setup(service => service.GetHighScoreAsync(playerName)).Returns(Task.FromResult(99));

            //Act
            await game.PlayAsync(playerName).ConfigureAwait(false);

            var (highScoreName, highScore) = await game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.Equal(playerName, highScoreName);
            Assert.InRange(highScore, 0, 100);

            mockRepository.VerifyAll();
        }

        [Fact]
        public async Task TestSomethingElse()
        {
            //Arrange
            const string playerName = "Marc";

            var mockRepository = new MockRepository(MockBehavior.Strict);
            var highScoreServiceMock = mockRepository.Create<IHighScoreService>();

            var game = new Game(highScoreServiceMock.Object);

            highScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100))).Returns(Task.CompletedTask);
            highScoreServiceMock.Setup(service => service.GetHighScoreAsync(playerName)).Returns(Task.FromResult(99));

            //Act
            await game.PlayAsync(playerName).ConfigureAwait(false);

            var (highScoreName, highScore) = await game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.Equal(playerName, highScoreName);
            Assert.InRange(highScore, 0, 100);

            mockRepository.VerifyAll();
        }
    }
}
