using System.Collections.Generic;
using SnowfallModels;

namespace ObjectMemory.Interfaces
{
    /// <summary>
    /// Хранилище снежинок
    /// </summary>
    public interface ISnowflakeObjectStorage
    {
        /// <summary>
        /// Получить список снежинок
        /// </summary>
        List<Snowflake> GetSnowflakes();
    }
}
