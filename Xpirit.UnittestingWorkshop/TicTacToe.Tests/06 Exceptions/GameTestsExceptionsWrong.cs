using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsExceptionsWrong
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        public GameTestsExceptionsWrong()
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

            try
            {
                //Act
                await Game.PlayAsync(playerName).ConfigureAwait(false);
                await Game.GetScoreAsync(playerName).ConfigureAwait(false);
            }
            catch (ApplicationException e)
            {
                //Assert
                Assert.Equal("My exception message", e.Message);

                MockRepository.VerifyAll();

                return;
            }

            throw new Exception("Test shouldn't get this far");
        }
    }
}
