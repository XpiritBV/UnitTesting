using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsExceptionsRight
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        public GameTestsExceptionsRight()
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

            HighScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100))).Returns(Task.CompletedTask);
            HighScoreServiceMock.Setup(service => service.GetHighScoreAsync(playerName)).ThrowsAsync(new ApplicationException("My exception message"));

            //Act & Assert
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            await Assert.ThrowsAsync<ApplicationException>( //Don't do this, create your own custom exceptions!
                async () => await Game.GetScoreAsync(playerName).ConfigureAwait(false)
            ).ConfigureAwait(false);
        }
    }
}
