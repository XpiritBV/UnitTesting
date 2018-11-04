using System;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum PatchLevel
    {
        V1, //Original release.
        V2, //Significant improvement to highscore saving, making efficient use of available resources.
    }

    public class Game
    {
        private IHighScoreService HighScoreService { get; }

        public Game(PatchLevel patchLevel = PatchLevel.V1)
        {
            switch (patchLevel)
            {
                case PatchLevel.V1:
                    HighScoreService = new HighScoreService();
                    break;
                case PatchLevel.V2:
                    HighScoreService = new HighScoreServiceV2();
                    break;
            }
        }

        public Game(IHighScoreService highScoreService)
        {
            HighScoreService = highScoreService ?? throw new ArgumentNullException(nameof(highScoreService));
        }

        public async Task<Guid> PlayAsync(string name)
        {
            var score = new Random().Next(0, 100);

            if(HighScoreService is IHighScoreServiceV2)
            {
                var highScoreService = HighScoreService as IHighScoreServiceV2;
                return await highScoreService.SaveAsync(name, score).ConfigureAwait(false);
            }
            else
            {
                var highScoreService = HighScoreService;
                return highScoreService.Save(name, score);
            }
        }
    }
}
