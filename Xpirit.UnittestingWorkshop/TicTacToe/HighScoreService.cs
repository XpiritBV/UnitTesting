using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public interface IHighScoreService
    {
        Guid Save(string name, int score);
    }

    public class HighScoreService : IHighScoreService
    {
        private readonly IDictionary<Guid, KeyValuePair<string, int>> HighScores = new Dictionary<Guid, KeyValuePair<string, int>>();

        public Guid Save(string name, int score)
        {
            if(HighScores.Any(highScore => highScore.Key.Equals(name)))
            {
                throw new ApplicationException("User already has a highscore and only gets one chance");
            }

            var guid = Guid.NewGuid();

            HighScores.Add(guid, new KeyValuePair<string, int>(name, score));

            return guid;
        }
    }
}
