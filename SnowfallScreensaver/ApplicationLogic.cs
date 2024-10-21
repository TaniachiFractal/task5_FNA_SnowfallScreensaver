using System;
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
        /// This function is automatically called when the App launches to initialize any non-graphic variables.
        /// </summary>
        protected override void Initialize()
        {
            objectManager.GenerateSnowflakes();

            previousMouseState = Mouse.GetState();

            base.Initialize();
        }

        /// <summary>
        /// Automatically called when your App launches to load any App assets (graphics, audio etc.)
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            snowflakeTexture = TextureLoader.Load("snowflake.png", Content);
        }

        /// <summary>
        /// Called each frame to update the App. Games usually runs 60 frames per second.
        /// Each frame the Update function will run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
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
        /// This is called when the App is ready to draw to the screen, it's also called each frame.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            //This will clear what's on the screen each frame, if we don't clear the screen will look like a mess:
            GraphicsDevice.Clear(Color.DarkBlue);

            spriteBatch.Begin();

            foreach (var snowflake in objectManager.GetSnowflakes())
            {
                var currSize = (int)(Const.SnowflakeSize * snowflake.scale);
                spriteBatch.Draw(snowflakeTexture, new Rectangle(snowflake.X, snowflake.Y, currSize, currSize), Color.White);
            }

            spriteBatch.End();

            //Draw the things FNA handles for us underneath the hood:
            base.Draw(gameTime);
        }

        #endregion

    }
}
