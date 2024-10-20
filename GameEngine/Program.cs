namespace GameEngine
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
            using (var app = new ApplicationLogic())
            {
                app.Run();
            }
        }
    }

}
