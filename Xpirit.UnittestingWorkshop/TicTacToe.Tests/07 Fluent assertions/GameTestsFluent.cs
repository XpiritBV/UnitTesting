using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsFluent
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        public GameTestsFluent()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
            HighScoreServiceMock = MockRepository.Create<IHighScoreService>();

            Game = new Game(HighScoreServiceMock.Object);
        }

        [Fact]
        public async Task ShouldHaveHighScoreAfterPlaying()
        {
            //Arrange
            const string playerName = "Reinier";

            HighScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100))).Returns(Task.CompletedTask);
            HighScoreServiceMock.Setup(service => service.GetHighScoreAsync(playerName)).Returns(Task.FromResult(99));

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            var (highScoreName, highScore) = await Game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            highScoreName.Should().Be(playerName, "the game should save the highscore of the player currently playing");
            highScore.Should().BeInRange(0, 100, "the score is determined with 0 and 100 as excluded boundaries");

            MockRepository.VerifyAll();
        }

        [Fact]
        public void ShouldThrowExceptionWhenHighScoreServiceIsDown()
        {
            //Arrange
            const string playerName = "Reinier";

            HighScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100))).Returns(Task.CompletedTask);
            HighScoreServiceMock.Setup(service => service.GetHighScoreAsync(playerName)).ThrowsAsync(new ApplicationException("My exception"));

            //Act
            Game.PlayAsync(playerName).ConfigureAwait(false);

            //Wrap the code in a Func that returns a Task that can be awaited
            Func<Task> codeUnderTest = () => Game.GetScoreAsync(playerName);

            //Assert
            codeUnderTest.Should().ThrowExactly<ApplicationException>("the game is not built to withstand exceptions");

            MockRepository.VerifyAll();
        }
    }
}
