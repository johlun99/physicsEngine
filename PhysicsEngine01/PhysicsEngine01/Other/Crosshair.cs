using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsEngine01.Other
{
    class Crosshair
    {
        #region Variables
        Texture2D texture;

        Rectangle sourceRectangle;

        Vector2 position;
        Vector2 origin;

        float scale;
        float rotation = 0;
        #endregion

        #region Methods
        /// <summary>
        /// Setup of the crosshair
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        public Crosshair(Texture2D texture, float scale)
        {
            this.texture = texture;
            this.scale = scale;

            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;

            sourceRectangle = new Rectangle(0, 0,
                texture.Width, texture.Height);
        }

        /// <summary>
        /// Updates the current position of the crosshair
        /// </summary>
        /// <param name="cursorPosition">The position of the cursor (where it shall be drawn)</param>
        public void Update(Vector2 cursorPosition)
        {
            position.X = cursorPosition.X + origin.X;
            position.Y = cursorPosition.Y + origin.Y;
        }

        /// <summary>
        /// Draws the crosshair on the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(position.X - origin.X, position.Y - origin.Y), sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
        #endregion
    }
}
