using System.Diagnostics;

namespace AgarIO.scripts.GameElements.Time
{
    public static class STime
    {
        public static int deltaTime { get; private set; }
        private static Stopwatch timer = new();

        public static void Innit()
        {
            timer.Start();
        }

        public static void ElapseTime()
        {
            deltaTime = (int)timer.ElapsedMilliseconds;
            timer.Reset();
        }
    }
}
