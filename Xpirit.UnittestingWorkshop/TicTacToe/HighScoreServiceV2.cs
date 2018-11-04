using System;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IHighScoreServiceV2 : IHighScoreService
    {
        Task<Guid> SaveAsync(string name, int score);
    }

    public class HighScoreServiceV2 : HighScoreService, IHighScoreServiceV2
    {
        public async Task<Guid> SaveAsync(string name, int score)
        {
            return await Task.Run(() => Save(name, score)).ConfigureAwait(false);
        }
    }
}
