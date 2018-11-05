using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public interface IHighScoreService
    {
        void Save(string name, int score);

        int GetHighScore(string name);
    }

    public class HighScoreService : IHighScoreService
    {
        private readonly IDictionary<string, int> HighScores = new Dictionary<string, int>();

        public void Save(string name, int score)
        {
            if(HighScores.Any(highScore => highScore.Key.Equals(name)))
            {
                throw new ApplicationException("User already has a highscore and only gets one chance");
            }

            HighScores.Add(name, score);
        }

        public int GetHighScore(string name)
        {
            if(!HighScores.ContainsKey(name))
            {
                throw new ApplicationException("No highscore available for this id");
            }

            return HighScores[name];
        }
    }
}
