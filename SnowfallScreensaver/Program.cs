using ObjectManager;
using ObjectMemory;

namespace SnowfallScreensaver
{
    /// <summary>
    /// Класс точки входа
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        private static void Main()
        {
            var objectStorage = new SnowflakeObjectStorage();
            var objectManager = new SnowflakeObjectManager(objectStorage);
            using (var app = new ApplicationLogic(objectManager))
            {
                app.Run();
            }
        }
    }

}
