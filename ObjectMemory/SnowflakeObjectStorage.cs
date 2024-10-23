using System.Collections.Generic;
using ObjectMemory.Interfaces;
using SnowfallModels;

namespace ObjectMemory
{
    /// <inheritdoc cref="ISnowflakeObjectStorage"/>
    public class SnowflakeObjectStorage : ISnowflakeObjectStorage
    {
        private List<Snowflake> snowflakeList;

        /// <inheritdoc/>
        public List<Snowflake> GetSnowflakes()
        {
            if (snowflakeList == null)
            {
                snowflakeList = new List<Snowflake>();
            }
            return snowflakeList;
        }

    }
}
