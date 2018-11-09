using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTestsSetupConstructor
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        /*
         * From https://xunit.github.io/docs/comparisons:
         * We believe that use of [SetUp] is generally bad. However, you can implement a parameterless constructor as a direct replacement. See Note 2.
         * Note 2: The xUnit.net team feels that per-test setup and teardown creates difficult-to-follow and debug testing code, often causing unnecessary code to run before every single test is run.
        */
        public GameTestsSetupConstructor()
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

            /*
             * Also possible:
             * It.IsInRange(0, 100, Range.Exclusive)
             * It.IsAny<int>()
             */
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

        [Fact]
        public async Task TestSomethingElse()
        {
            //Arrange
            const string playerName = "Marc";

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
