using FluentAssertions;
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
        public async Task TestGameCrashesIfHighScoreServiceIsDown()
        {
            //Arrange
            const string playerName = "Reinier";

            HighScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100))).Returns(Task.CompletedTask);
            HighScoreServiceMock.Setup(service => service.GetHighScoreAsync(playerName)).ThrowsAsync(new ApplicationException("My exception message"));

            //Act & Assert
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            //You shouldn't use Exception or ApplicationException in production code, create your own custom exceptions!
            //This results in better (more precise) error handling and it's better to test
            await Assert.ThrowsAsync<ApplicationException>(
                async () => await Game.GetScoreAsync(playerName).ConfigureAwait(false)
            ).ConfigureAwait(false);

            MockRepository.VerifyAll();
        }

        [Fact]
        public async Task ShouldThrowExceptionWhenHighScoreServiceIsDown()
        {
            //Arrange
            const string playerName = "Reinier";

            HighScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100))).Returns(Task.CompletedTask);
            HighScoreServiceMock.Setup(service => service.GetHighScoreAsync(playerName)).ThrowsAsync(new ApplicationException("My exception"));

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            //Wrap the code in a Func that returns a Task that can be awaited
            Func<Task> codeUnderTest = () => Game.GetScoreAsync(playerName);

            //Assert
            codeUnderTest.Should().ThrowExactly<ApplicationException>("the game is not built to withstand exceptions");

            MockRepository.VerifyAll();
        }
    }
}
