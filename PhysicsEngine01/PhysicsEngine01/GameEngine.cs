using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using PhysicsEngine01.Objects;
using PhysicsEngine01.Other;
using System.Collections.Generic;
using System.Diagnostics;

namespace PhysicsEngine01
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        FPSCounter fps;
        Crosshair crosshair;

        SpriteFont debugFont;

        Texture2D ballTexture;
        Texture2D hitboxColor;

        int screenHeight;
        int screenWidth;
        int ballCounter = 0;

        double ballTimer = 0;

        float fpsCounter = 0;

        List<Ball> balls = new List<Ball>();

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
            screenHeight = GraphicsDevice.Viewport.Bounds.Height;
            screenWidth = GraphicsDevice.Viewport.Bounds.Width;

            base.Initialize();

            fps = new FPSCounter();

            hitboxColor = new Texture2D(GraphicsDevice, 1, 1);
            hitboxColor.SetData<Color>(new Color[] { Color.Red });
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
            debugFont = Content.Load<SpriteFont>("debugFont");

            crosshair = new Crosshair(Content.Load<Texture2D>("other/redcrosshair"), 0.1f);

            ballTexture = Content.Load<Texture2D>("Objects/ball");
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

            MouseState mouse = Mouse.GetState();

            // Keep track of delay between balls
            ballTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

            // Create new balls if the delay is correct
            if (mouse.LeftButton == ButtonState.Pressed && ballTimer > 400)
            {
                ballTimer = 0;
                createBall();
            }
            crosshair.Update(new Vector2(mouse.Position.X, mouse.Position.Y));

            // Update all the balls
            foreach (var b in balls)
            {
                /*if (b.Position.Y >= screenHeight - 60)
                {
                    b.AddForce(new Vector2(2, -10));
                }*/

                b.Update(screenHeight);
                checkBallCollisions();
            }

            fpsCounter = fps.CurrentFramesPerSecond;
            ballCounter = balls.Count;

            base.Update(gameTime);
        }

        /// <summary>
        /// Creates a new ball and adds it to the screen
        /// </summary>
        private void createBall()
        {
            MouseState mouse = Mouse.GetState();

            Ball b = new Ball(ballTexture, new Vector2(mouse.Position.X, mouse.Position.Y), new Vector2(0, 0), 2);

            balls.Add(b);
        }

        private void checkBallCollisions()
        {
            for (int i = 0; i < balls.Count; i++)
                for (int j = 0; j < balls.Count; j++)
                    if (i != j && balls[i].Hitbox.Intersects(balls[j].Hitbox))
                    {
                        Debug.WriteLine($"Collision detected between balls[{i}] & balls[{j}]");
                    }
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

            foreach (var b in balls)
            {
                b.Draw(spriteBatch, ballTexture, hitboxColor);
            }

            fps.Update((float)gameTime.TotalGameTime.TotalSeconds);
            spriteBatch.DrawString(debugFont, $"FPS: {fpsCounter}", new Vector2(20, 20), Color.White);
            spriteBatch.DrawString(debugFont, $"Counter: {ballCounter}", new Vector2(20, 40), Color.White);

            crosshair.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
