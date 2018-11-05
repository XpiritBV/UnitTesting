using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IHighScoreService
    {
        Task SaveAsync(string name, int score);

        Task<int> GetHighScoreAsync(string name);
    }

    public class HighScoreService : IHighScoreService
    {
        private readonly IDictionary<string, int> HighScores = new Dictionary<string, int>();

        public async Task SaveAsync(string name, int score)
        {
            await Task.Run(() =>
            {
                if (HighScores.Any(highScore => highScore.Key.Equals(name)))
                {
                    throw new ApplicationException("User already has a highscore and only gets one chance");
                }

                HighScores.Add(name, score);
            }).ConfigureAwait(false);
        }

        public async Task<int> GetHighScoreAsync(string name)
        {
            return await Task.Run(() =>
            {
                if (!HighScores.ContainsKey(name))
                {
                    throw new ApplicationException("No highscore available for this id");
                }

                return HighScores[name];
            }).ConfigureAwait(false);
        }
    }
}
