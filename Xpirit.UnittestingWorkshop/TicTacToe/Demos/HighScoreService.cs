using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IHighScoreService
    {
        Task SaveAsync(string name, int score);

        Task<int> GetHighScoreAsync(string name);
    }

    /// <summary>
    /// This class represents some external webservice which you have no control over
    /// </summary>
    [ExcludeFromCodeCoverage]
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

                //Thread.Sleep(10000); //What is this service was very slow, or does some IO related stuff?
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
