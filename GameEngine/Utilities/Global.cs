using System;
using Microsoft.Xna.Framework;

namespace GameEngine
{
    public static class Global
    {
        public static Game App;
        public static Random Random = new Random();
        public static string LevelName;

        public static void Initialize(Game inputGame)
        {
            App = inputGame;
        }
    }
}
