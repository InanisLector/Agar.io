using AgarIO.scripts.GameEngine;
using AgarIO.scripts.Game;

namespace Program
{
    class Program
    {
        private static void Main(string[] args)
        {
            Game.CrateNew(new AgarIOScene()).Start();
        }
    }
}