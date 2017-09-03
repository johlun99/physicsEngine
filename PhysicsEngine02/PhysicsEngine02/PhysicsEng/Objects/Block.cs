using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsEngine02.PhysicsEng.Objects
{
    class Block
    {
        #region Variables and Properties
        Texture2D texture;

        Rectangle sourceRectangle;
        Rectangle hitbox;

        Vector2 position;
        Vector2 origin;

        float rotation;
        float scale;

        public Rectangle Hitbox { get { return hitbox; } }
        public Vector2 Position { get { return position; } }
        #endregion

        public Block(Vector2 textureSize, Vector2 position, float scale = 1)
        {
            this.position = position;
            this.scale = scale;

            origin.X = textureSize.X / 2;
            origin.Y = textureSize.Y / 2;

            sourceRectangle = new Rectangle(0, 0,
                (int)(textureSize.X), (int)(textureSize.Y));

            hitbox = new Rectangle((int)(position.X - origin.X * scale), (int)(position.Y - origin.Y * scale),
                (int)(textureSize.X * scale), (int)(textureSize.Y * scale));
        }

        public void Update()
        {

        }

        #region Draw methods
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D hitboxColor)
        {
            spriteBatch.Draw(hitboxColor, hitbox, Color.White);
        }
        #endregion
    }
}
