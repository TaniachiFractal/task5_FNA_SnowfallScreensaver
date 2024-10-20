using GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnowfallScreensaver
{
    /// <summary>
    /// Класс приложения
    /// </summary>
    public class ApplicationLogic : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D snowflake;
        private Vector2 snowflakePosition;

        /// <summary>
        /// This is the constructor, this function is called whenever the App class is created.
        /// </summary>
        public ApplicationLogic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = false;

            graphics.ApplyChanges();
        }

        /// <summary>
        /// This function is automatically called when the App launches to initialize any non-graphic variables.
        /// </summary>
        protected override void Initialize()
        {
            snowflakePosition = new Vector2(640, 360);
            base.Initialize();
        }

        /// <summary>
        /// Automatically called when your App launches to load any App assets (graphics, audio etc.)
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            snowflake = TextureLoader.Load("snowflake.png", Content);
        }

        /// <summary>
        /// Called each frame to update the App. Games usually runs 60 frames per second.
        /// Each frame the Update function will run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            Input.Update();

            if (Input.IsKeyDown(Keys.Left))
            {
                snowflakePosition.X -= 5;
            }
            else if (Input.IsKeyDown(Keys.Right))
            {
                snowflakePosition.X += 5;
            }

            //Update the things FNA handles for us underneath the hood:
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

            spriteBatch.Draw(snowflake, snowflakePosition, Color.White);

            spriteBatch.End();

            //Draw the things FNA handles for us underneath the hood:
            base.Draw(gameTime);
        }
    }

}
