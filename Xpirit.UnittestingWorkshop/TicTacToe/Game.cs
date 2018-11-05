using System;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        private IHighScoreService HighScoreService { get; }

        public Game(IHighScoreService highScoreService)
        {
            HighScoreService = highScoreService ?? throw new ArgumentNullException(nameof(highScoreService));
        }

        public async Task PlayAsync(string name)
        {
            var score = new Random().Next(1, 99);

            await HighScoreService.SaveAsync(name, score).ConfigureAwait(false);
        }

        public async Task<(string name, int score)> GetScoreAsync(string name)
        {
            return (name, await HighScoreService.GetHighScoreAsync(name).ConfigureAwait(false));
        }
    }
}
