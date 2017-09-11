using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace physicsEngine03
{
    class Cursor
    {
        #region Variables
        Texture2D texture;

        Rectangle sourceRectangle;

        Vector2 position;
        Vector2 origin;

        float scale;
        float rotation;
        #endregion

        public Cursor(Texture2D texture, float scale)
        {
            this.texture = texture;
            this.scale = scale;

            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;

            sourceRectangle = new Rectangle(0, 0,
                texture.Width, texture.Height);
        }

        /// <summary>
        /// Updates current location of the cursor
        /// </summary>
        /// <param name="position">The position where you want the cursor</param>
        public void Update(Vector2 position)
        {
            this.position = position;
        }

        /// <summary>
        /// Draws the cursor att the given location
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
