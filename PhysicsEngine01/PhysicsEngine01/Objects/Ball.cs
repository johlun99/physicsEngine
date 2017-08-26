using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsEngine01.Objects
{
    class Ball
    {
        #region Variables
        Rectangle sourceRectangle;
        Rectangle hitbox;

        Vector2 position;
        Vector2 origin;
        Vector2 velocity;
        Vector2 force;

        const float gravityAccelleration = 0.8f;
        float scale = 0.03f;
        float rotation = 0;
        #endregion

        #region Methods
        public Ball(Texture2D texture, Vector2 position, Vector2 force)
        {
            this.position = position;
            this.force = force;

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
        public void Update(int screenHeight)
        {
            velocity.Y += gravityAccelleration;
            position += velocity;

            hitbox.X = (int)(position.X - origin.X * scale);
            hitbox.Y = (int)(position.Y - origin.Y * scale);

            if (position.Y > screenHeight - origin.Y * scale)
            {
                velocity.Y = 0 - velocity.Y + 2;
                position.Y = screenHeight - origin.Y * scale;
            }
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
