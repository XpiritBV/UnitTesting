using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests.xUnit.Moq
{
    public class GameTestsLoose
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        /*
         * From https://xunit.github.io/docs/comparisons:
         * We believe that use of [SetUp] is generally bad. However, you can implement a parameterless constructor as a direct replacement. See Note 2.
         * Note 2: The xUnit.net team feels that per-test setup and teardown creates difficult-to-follow and debug testing code, often causing unnecessary code to run before every single test is run.
        */
        public GameTestsLoose()
        {
            MockRepository = new MockRepository(MockBehavior.Loose);
            HighScoreServiceMock = MockRepository.Create<IHighScoreService>();

            //Alternatives:
            //var highScoreService = new Mock<IHighScoreService>(MockBehavior.Loose);
            //var highScoreService = Mock.Of<IHighScoreService>();

            Game = new Game(HighScoreServiceMock.Object);
        }

        [Fact(Skip = "Failing assertion for some reason")]
        public async Task TestPlayerHasHighScoreAfterGamePlay_NoArrange()
        {
            const string playerName = "Reinier";

            //Arrange

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            //Arrange HighScoreServiceMock with recorded highscore
            var (highScoreName, highScore) = await Game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.Equal(playerName, highScoreName);
            Assert.True(highScore > 0);
            Assert.True(highScore < 100);

            MockRepository.VerifyAll();
        }

        [Fact(Skip = "NullReferenceException for some reason")]
        public async Task TestPlayerHasHighScoreAfterGamePlay_AsyncIssue()
        {
            //Arrange
            const string playerName = "Reinier";

            HighScoreServiceMock.Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100)));

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            var (highScoreName, highScore) = await Game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.Equal(playerName, highScoreName);
            Assert.True(highScore > 0);
            Assert.True(highScore < 100);

            MockRepository.VerifyAll();
        }

        [Fact]
        public async Task TestPlayerHasHighScoreAfterGamePlay_HardcodedHighScore()
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
            Assert.True(highScore > 0);
            Assert.True(highScore < 100);

            MockRepository.VerifyAll();
        }

        [Fact]
        public async Task TestPlayerHasHighScoreAfterGamePlay_CallbackHighScore()
        {
            const string playerName = "Reinier";

            //Arrange HighScoreService for saving a highscore
            int recordedHighScore = -1;

            /*
             * Also possible:
             * It.IsInRange(0, 100, Range.Exclusive)
             * It.IsAny<int>()
             */
            HighScoreServiceMock
                .Setup(service => service.SaveAsync(playerName, It.Is<int>(x => x > 0 && x < 100)))
                .Returns(Task.CompletedTask)
                .Callback<string, int>((_, savedScore) => recordedHighScore = savedScore);

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            //Arrange HighScoreServiceMock with recorded highscore
            HighScoreServiceMock
                .Setup(service => service.GetHighScoreAsync(playerName))
                .Returns(Task.FromResult(recordedHighScore));

            var (highScoreName, highScore) = await Game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.Equal(playerName, highScoreName);
            Assert.Equal(recordedHighScore, highScore);
            Assert.True(highScore > 0);
            Assert.True(highScore < 100);

            MockRepository.VerifyAll();
        }

        [Theory]
        [InlineData("Reinier", 0, 100)]
        [InlineData("Marc", 0, 100)]
        [InlineData("Marcel", 0, 100)]
        [InlineData("Alex", 0, 100)]
        public async Task TestPlayerHasHighScoreAfterGamePlay_Theory(string playerName, int minScore, int maxScore)
        {
            //Arrange

            //Act
            await Game.PlayAsync(playerName).ConfigureAwait(false);

            var (highscoreName, highscore) = await Game.GetScoreAsync(playerName).ConfigureAwait(false);

            //Assert
            Assert.Equal(playerName, highscoreName);
            Assert.True(highscore > minScore);
            Assert.True(highscore < maxScore);
        }
    }
}
