using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using PhysicsEngine02.PhysicsEng.Objects;
using System.Collections.Generic;

namespace PhysicsEngine02
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Game
    {
        #region Variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MouseState mouse;
        KeyboardState keyboard;

        Texture2D ballTexture;
        Texture2D hitboxColor;
        SpriteFont debugFont;

        Crosshair crosshair;

        List<Ball> balls = new List<Ball>();
        List<Block> blocks = new List<Block>();

        bool debugMode = false;

        double clickDelay = 0;
        double ballDelay = 0;
        double blockDelay = 0;

        float ballScale = 0.03f;

        int ballCounter = 0;
        int blockCounter = 0;
        #endregion

        #region Constructors and Initializing
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
            crosshair = new Crosshair(Content.Load<Texture2D>("other/redcrosshair"), 0.1f);

            ballTexture = Content.Load<Texture2D>("objects/ball");

            hitboxColor = new Texture2D(GraphicsDevice, 1, 1);
            hitboxColor.SetData<Color>(new Color[] { Color.Red });

            debugFont = Content.Load<SpriteFont>("Fonts/debugFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        #endregion

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
            clickDelay += gameTime.ElapsedGameTime.TotalMilliseconds;

            MouseInput();
            KeyboardInput();

            UpdateBalls();
            UpdateBlocks();

            base.Update(gameTime);
        }

        #region User Inputs
        /// <summary>
        /// Collects and handles input from the mouse
        /// </summary>
        private void MouseInput()
        {
            mouse = Mouse.GetState();

            crosshair.Update(new Vector2(mouse.X, mouse.Y));

            if (mouse.LeftButton == ButtonState.Pressed)
                SpawnBall(new Vector2(mouse.X, mouse.Y));

            if (mouse.RightButton == ButtonState.Pressed)
                SpawnBlock(new Vector2(mouse.X, mouse.Y));
        }

        /// <summary>
        /// Collects and handles keyboard input
        /// </summary>
        private void KeyboardInput()
        {
            keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.D) && clickDelay > 400)
            {
                if (!debugMode)
                    debugMode = true;

                else
                    debugMode = false;

                clickDelay = 0;
            }

            // Clears the screen of elements
            if (keyboard.IsKeyDown(Keys.C))
            {
                for (int i = 0; i < balls.Count; i++)
                    balls.RemoveAt(i);

                for (int i = 0; i < blocks.Count; i++)
                    blocks.RemoveAt(i);
            }
        }
        #endregion

        /// <summary>
        /// Spawns a new ball at the given location
        /// </summary>
        /// <param name="startPosition"></param>
        private void SpawnBall(Vector2 startPosition)
        {
            Ball b = new Ball(new Vector2(ballTexture.Width, ballTexture.Height), new Vector2(startPosition.X, startPosition.Y), ballScale);
            balls.Add(b);
        }

        /// <summary>
        /// Spawns a new block at the given location
        /// </summary>
        /// <param name="position"></param>
        private void SpawnBlock(Vector2 position)
        {
            Block b = new Block(new Vector2(15, 15), position);
            blocks.Add(b);
        }

        /// <summary>
        /// Update all balls on screen (removes the ones that's off screen)
        /// </summary>
        private void UpdateBalls()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Update();

                if (balls[i].Position.Y < 0 ||
                    balls[i].Position.X < 0 ||
                    balls[i].Position.Y > GraphicsDevice.Viewport.Bounds.Height ||
                    balls[i].Position.X > GraphicsDevice.Viewport.Bounds.Width)
                {
                    balls.RemoveAt(i);
                }
            }
            ballCounter = balls.Count;
        }

        private void UpdateBlocks()
        {
            blockCounter = blocks.Count;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            foreach (var b in blocks)
                b.Draw(spriteBatch, hitboxColor);

            if (debugMode)
            {
                foreach (var b in balls)
                    b.Draw(spriteBatch, ballTexture, hitboxColor);

                spriteBatch.DrawString(debugFont, $"Ball Count: {ballCounter}", new Vector2(20, 20), Color.White);
                spriteBatch.DrawString(debugFont, $"Block Count: {blockCounter}", new Vector2(20, 40), Color.White);
            }

            else
                foreach (var b in balls)
                    b.Draw(spriteBatch, ballTexture);

            crosshair.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
