using System;

namespace TicTacToe.Demos
{
    public class GameConfiguration
    {
        public string Version => Environment.GetEnvironmentVariable("GameVersion");

        public string TempFolder => Environment.GetEnvironmentVariable("GameTempFolder");
    }

    public class GameConfigurationWithInterface
    {
        private readonly IEnvironment environment;

        public GameConfigurationWithInterface(IEnvironment environment)
        {
            this.environment = environment;
        }

        public string Version => environment.GetEnvironmentVariable("GameVersion");

        public string TempFolder => environment.GetEnvironmentVariable("GameTempFolder");
    }
}
