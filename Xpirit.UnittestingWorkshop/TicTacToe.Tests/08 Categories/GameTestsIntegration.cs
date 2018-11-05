using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.Tests
{
    [Trait("Category", "Integration")]
    public class GameTestsIntegration
    {
        private Game Game { get; }

        private MockRepository MockRepository { get; }
        private Mock<IHighScoreService> HighScoreServiceMock { get; }

        public GameTestsIntegration()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
            HighScoreServiceMock = MockRepository.Create<IHighScoreService>();

            Game = new Game(HighScoreServiceMock.Object);
        }

        [Fact]
        public void SomeIntegrationStuffWhichIsVerySlow()
        {
            Thread.Sleep(1000);
        }
    }
}
