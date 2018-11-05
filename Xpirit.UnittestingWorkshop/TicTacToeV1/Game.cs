using System;

namespace TicTacToe
{
    public class Game
    {
        private IHighScoreService HighScoreService { get; }

        public Game()
        {
            HighScoreService = new HighScoreService();
        }

        public void Play(string name)
        {
            var score = new Random().Next(0, 100);

            HighScoreService.Save(name, score);
        }

        public (string name, int score) GetScore(string name)
        {
            return (name, HighScoreService.GetHighScore(name));
        }
    }
}
