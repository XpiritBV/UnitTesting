using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsWrongScope
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        public GameTestsWrongScope()
        {
            MockRepository = new MockRepository(MockBehavior.Loose);
            HighScoreServiceMock = MockRepository.Create<IHighScoreService>();

            Game = new Game(HighScoreServiceMock.Object);
        }

        [Fact]
        public async Task ShouldThrowExceptionWhenHighScoreServiceIsDown()
        {
            //Arrange
            const string playerName = "Reinier";

            HighScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100))).Returns(Task.CompletedTask);
            HighScoreServiceMock.Setup(service => service.GetHighScoreAsync(playerName)).ThrowsAsync(new ApplicationException("My exception"));

            //Act
            //await Game.PlayAsync(playerName).ConfigureAwait(false); //Why isn't this failing?

            //Wrap the code in a Func that returns a Task that can be awaited
            Func<Task> codeUnderTest = () => Game.GetScoreAsync(playerName);

            //Assert
            codeUnderTest.Should().ThrowExactly<ApplicationException>("the game is not built to withstand exceptions");
        }
    }
}
