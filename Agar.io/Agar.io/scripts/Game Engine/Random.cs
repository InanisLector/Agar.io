namespace Agar.io.scripts.GameEngine
{
    public static class Random
    {
        private static System.Random rand = new();

        public static float OneFloat 
            => (float) rand.NextDouble();

        public static int Int(int MaxValue)
            => rand.Next(MaxValue);

        public static int Int(int MinValue, int MaxValue)
            => rand.Next(MinValue, MaxValue);
    }
}
