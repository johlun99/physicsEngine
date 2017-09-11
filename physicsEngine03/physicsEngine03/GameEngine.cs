using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Physix.Objects;
using System.Collections.Generic;

namespace physicsEngine03
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Cursor cursor;

        Texture2D hitboxColor;
        Texture2D ballTexture;

        List<Ball> balls = new List<Ball>();

        double clickDelay = 0;

        float screenHeight;
        float screenWidth;

        bool debugMode = false;

        public GameEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screenHeight = GraphicsDevice.Viewport.Bounds.Height;
            screenWidth = GraphicsDevice.Viewport.Bounds.Width;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("Objects/ball");

            cursor = new Cursor(Content.Load<Texture2D>("Other/redcrosshair"), 0.1f);

            hitboxColor = new Texture2D(GraphicsDevice, 1, 1);
            hitboxColor.SetData<Color>(new Color[] { Color.Red });
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            MouseInput();
            KeyboardInput(gameTime);

            UpdateBalls();

            base.Update(gameTime);
        }

        private void MouseInput()
        {
            MouseState mouse = Mouse.GetState();

            cursor.Update(new Vector2(mouse.X, mouse.Y));

            if (mouse.LeftButton == ButtonState.Pressed)
                SpawnBall(new Vector2(mouse.X, mouse.Y));
        }

        private void KeyboardInput(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            clickDelay += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (keyboard.IsKeyDown(Keys.D) && clickDelay > 100)
            {
                clickDelay = 0;

                if (!debugMode)
                    debugMode = true;

                else
                    debugMode = false;
            }
        }

        private void SpawnBall(Vector2 position)
        {
            Ball b = new Ball(ballTexture, position, 0.03f);
            balls.Add(b);
        }

        private void UpdateBalls()
        {
            foreach (var b in balls)
            {
                b.Update();

                if (b.Hitbox.Y + b.Hitbox.Height > screenHeight)
                    b.AddVelocity(-b.Velocity);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            if (!debugMode)
            {
                foreach (var b in balls)
                    b.Draw(spriteBatch);
            }

            else
            {
                foreach (var b in balls)
                    b.DrawWithHitbox(spriteBatch, hitboxColor);
            }

            cursor.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
