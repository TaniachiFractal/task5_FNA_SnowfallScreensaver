using System;
using System.Collections.Generic;
using ObjectManager.Additions;
using ObjectManager.Interfaces;
using ObjectMemory.Interfaces;
using SnowfallModels;
using SnowfallModels.Additions;

namespace ObjectManager
{
    /// <inheritdoc cref="IObjectManager"/>
    public class SnowflakeObjectManager : IObjectManager
    {
        private readonly ISnowflakeObjectStorage storage;
        private int fieldHeight;
        private int fieldWidth;
        private const int SnowflakesCount = 500;

        /// <summary>
        /// Конструктор прослойки: Указать хранилище
        /// </summary>
        public SnowflakeObjectManager(ISnowflakeObjectStorage storage)
        {
            this.storage = storage;
        }

        #region interface implement

        /// <inheritdoc/>
        public void GenerateSnowflakes()
        {
            var rnd = new Random();
            var snowflakes = GetSnowflakes();
            for (var i = 0; i < GetSnowflakesCount(); i++)
            {
                snowflakes.Add(NewSnowflake(rnd));
            }
            snowflakes.Sort();
        }

        /// <inheritdoc/>
        public void UpdateSnowflakes()
        {
            foreach (var snowflake in GetSnowflakes())
            {
                snowflake.Y += snowflake.speed;
                if (snowflake.Y > fieldHeight)
                {
                    snowflake.Y = (int)(-Const.SnowflakeSize * snowflake.scale);
                }
            }
        }

        /// <inheritdoc/>
        public List<Snowflake> GetSnowflakes() => storage.GetSnowflakes();

        /// <inheritdoc/>
        public int GetSnowflakesCount() => SnowflakesCount;

        /// <inheritdoc/>
        public void SetFieldSize(int width, int height)
        {
            fieldHeight = height;
            fieldWidth = width;
        }

        #endregion

        private Snowflake NewSnowflake(Random rnd)
        {
            var snowflake = new Snowflake
            {
                scale = (float)(rnd.NextDouble() * 2 + 0.1), // модификатор размера от 0.1 до 2.1
                X = rnd.Next(-Const.SnowflakeSize, fieldWidth + Const.SnowflakeSize), // от края до края поля с отступом на стандарный размер
                Y = rnd.Next(-fieldHeight, -Const.SnowflakeSize), // от минус размера поля до минус стандартного размера снежинки
                color = SnowflakeColors.Colors[rnd.Next(SnowflakeColors.Colors.Length)]
            };
            snowflake.speed = (int)(snowflake.scale * Const.SnowflakeSize * 0.1); // скорсть - 0.1 размера

            return snowflake;
        }

    }
}
