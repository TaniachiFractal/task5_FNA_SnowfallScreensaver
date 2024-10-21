using GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ObjectManager.Interfaces;
using SnowfallModels.Additions;

namespace SnowfallScreensaver
{
    /// <summary>
    /// Класс приложения
    /// </summary>
    public class ApplicationLogic : Game
    {
        private readonly IObjectManager objectManager;
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D snowflakeTexture;
        private Texture2D snowforestTexture;
        private MouseState previousMouseState;

        /// <summary>
        /// Конструктор приложения
        /// </summary>
        public ApplicationLogic(IObjectManager objectManager)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = true;

            graphics.ApplyChanges();

            this.objectManager = objectManager;
            objectManager.SetFieldSize(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        #region parent functions

        /// <summary>
        /// Инициализация списка снежинок и получение состояния компьютерной мыши и стандартная инициализация окна FNA 
        /// </summary>
        protected override void Initialize()
        {
            objectManager.GenerateSnowflakes();

            previousMouseState = Mouse.GetState();

            base.Initialize();
        }

        /// <summary>
        /// Инициализация списка спрайтов и загрузка картинок
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            snowflakeTexture = TextureLoader.Load("snowflake.png", Content);
            snowforestTexture = TextureLoader.Load("snowforest.png", Content);
        }

        /// <summary>
        /// Функция обновления: обновить позиции снежинок и проверить состояние клавиатуры и мыши
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            objectManager.UpdateSnowflakes();

            if (Keyboard.GetState().GetPressedKeys().Length > 0) // Закрыться, если нажали какую-то кнопку
            { Exit(); }

            var currentMouseState = Mouse.GetState(); // Закрыться, если двинулась мышь
            if (currentMouseState != previousMouseState)
            { Exit(); }
            previousMouseState = currentMouseState;

            base.Update(gameTime);
        }

        /// <summary>
        /// Рендер приложения
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(snowforestTexture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            foreach (var snowflake in objectManager.GetSnowflakes())
            {
                var currSize = (int)(Const.SnowflakeSize * snowflake.scale);
                spriteBatch.Draw(snowflakeTexture, new Rectangle(snowflake.X, snowflake.Y, currSize, currSize), Color.White);
            }

            spriteBatch.End();

            //Draw the things FNA handles for us underneath the hood
            base.Draw(gameTime);
        }

        #endregion

    }
}
