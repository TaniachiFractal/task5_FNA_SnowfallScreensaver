namespace SnowfallModels
{
    /// <summary>
    /// Класс снежинки
    /// </summary>
    public class Snowflake
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
    }
}
