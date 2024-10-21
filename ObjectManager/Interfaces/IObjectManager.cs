using System.Collections.Generic;
using SnowfallModels;

namespace ObjectManager.Interfaces
{
    /// <summary>
    /// Прослойка между хранилищем и представлением; Обработчик логики
    /// </summary>
    public interface IObjectManager
    {
        /// <summary>
        /// Получить список снежинок
        /// </summary>
        List<Snowflake> GetSnowflakes();

        /// <summary>
        /// Получить количество снежинок
        /// </summary>
        int GetSnowflakesCount();

        /// <summary>
        /// Сгенерировать снежинки
        /// </summary>
        void GenerateSnowflakes();

        /// <summary>
        /// Обновить все снежинки
        /// </summary>
        void UpdateSnowflakes();

        /// <summary>
        /// Установить размер поля
        /// </summary>
        void SetFieldSize(int width, int height);
    }
}
