using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsRightScope
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        public GameTestsRightScope()
        {
            MockRepository = new MockRepository(MockBehavior.Loose);
            HighScoreServiceMock = MockRepository.Create<IHighScoreService>();

            Game = new Game(HighScoreServiceMock.Object);
        }

        [Fact]
        public void ShouldThrowExceptionWhenPlayingAndHighScoreServiceIsDown()
        {
            //Arrange
            const string playerName = "Reinier";

            HighScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100))).ThrowsAsync(new ApplicationException("My exception"));

            //Wrap the code in a Func that returns a Task that can be awaited
            Func<Task> codeUnderTest = () => Game.PlayAsync(playerName);

            //Act & Assert
            codeUnderTest.Should().ThrowExactly<ApplicationException>("the game is not built to withstand exceptions");
        }

        [Fact]
        public void ShouldThrowExceptionWhenRetreivingHighScoreAndHighScoreServiceIsDown()
        {
            //Arrange
            const string playerName = "Reinier";

            HighScoreServiceMock.Setup(service => service.GetHighScoreAsync(playerName)).ThrowsAsync(new ApplicationException("My exception"));

            //Wrap the code in a Func that returns a Task that can be awaited
            Func<Task> codeUnderTest = () => Game.GetScoreAsync(playerName);

            //Act & Assert
            codeUnderTest.Should().ThrowExactly<ApplicationException>("the game is not built to withstand exceptions");
        }
    }
}
