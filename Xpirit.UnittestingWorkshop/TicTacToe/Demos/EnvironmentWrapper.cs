using System;

namespace TicTacToe.Demos
{
    public interface IEnvironment
    {
        string CurrentDirectory { get; }
        string GetEnvironmentVariable(string variable);
        void SetEnvironmentVariable(string variable, string value);
    }

    public class EnvironmentWrapper : IEnvironment
    {
        public string CurrentDirectory => Environment.CurrentDirectory;
        public string GetEnvironmentVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable);
        }

        public void SetEnvironmentVariable(string variable, string value)
        {
            Environment.SetEnvironmentVariable(variable, value);
        }
    }
}

