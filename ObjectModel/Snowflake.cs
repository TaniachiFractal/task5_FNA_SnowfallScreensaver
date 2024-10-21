using System;
using Microsoft.Xna.Framework;

namespace SnowfallModels
{
    /// <summary>
    /// Класс снежинки
    /// </summary>
    public class Snowflake : IComparable<Snowflake>
    {
        /// <summary>
        /// Позиция снежинки по горизонтали
        /// </summary>
        public int X;

        /// <summary>
        /// Позиция снежинки по вертикали
        /// </summary>
        public int Y;

        /// <summary>
        /// Ширина и высота квадратного изображения снежинки.
        /// </summary>
        public float scale;

        /// <summary>
        /// Скорость снежинки
        /// </summary>
        public int speed;

        /// <summary>
        /// Оттенок снежинки
        /// </summary>
        public Color color;

        public int CompareTo(Snowflake other)
        {
            if (scale > other.scale)
            { return 1; }
            if (scale < other.scale)
            { return -1; }
            return 0;
        }
    }
}
