using AgarIO.scripts.GameEngine;
using AgarIO.scripts.Game;

namespace Program
{
    class Program
    {
        private static void Main(string[] args)
        {
            new Game().StartGame(new AgarIOScene());
        }
    }
}