﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PhysicsEngine01.PhysicsEngine.Objects
{
    class Ball : SolidObject
    {
        #region Variables & properties
        public float Radius { get { return hitbox.Width / 2; } }
        #endregion

        #region Methods
        /// <summary>
        /// Initates the base values of the balls
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="force"></param>
        public Ball(Texture2D texture, Vector2 position, Vector2 force, float mass, int screenHeight, int screenWidth)
        {
            this.position = position;
            this.force = force;
            this.mass = mass;
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;

            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;

            sourceRectangle = new Rectangle(0, 0,
                texture.Width, texture.Height);

            hitbox = new Rectangle(0, 0,
                (int)(texture.Width * scale), (int)(texture.Height * scale));
        }

        /// <summary>
        /// Updates the current location of the ball and
        /// performs all neccessary calculations
        /// </summary>
        /// <param name="screenHeight"></param>
        public void Update()
        {
            velocity.Y += gravityAccelleration;

            force = velocity * mass;

            hitbox.X = (int)(position.X - origin.X * scale);
            hitbox.Y = (int)(position.Y - origin.Y * scale);

            if (position.Y > screenHeight - origin.Y * scale)
            {
                if (Math.Abs(velocity.Y) < 0.1)
                    velocity.Y = 0;

                else
                    velocity.Y = 0 - velocity.Y + 2;

                position.Y = screenHeight - origin.Y * scale;
            }

            if (position.X < 0 + origin.X * scale ||
                position.X > screenWidth - origin.X * scale)
            {
                if (Math.Abs(velocity.X) < 0.1)
                    velocity.X = 0;

                else
                    velocity.X = velocity.X * -1;
            }

            position += velocity;
        }
        
        public override void HandleCollision(Ball ball)
        {
            Vector2 direction = ball.position - position;
            direction.Normalize();

            ball.AddForce(direction * force.Length());
            AddForce(direction * -force.Length());
        }

        /// <summary>
        /// Draws the ball to the screen (WITHOUT hitbox)
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="texture">The texture the ball shall have</param>
        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }

        /// <summary>
        /// Draws the ball (WITH hitbox)
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="texture">The texture of the ball</param>
        /// <param name="hitboxColor">The color of the hitbox</param>
        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Texture2D hitboxColor)
        {
            spriteBatch.Draw(hitboxColor, hitbox, Color.White);
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
        #endregion
    }
}