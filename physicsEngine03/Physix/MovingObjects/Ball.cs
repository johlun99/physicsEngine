using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Physix.MovingObjects
{
    public class Ball
    {
        #region Variables and Properties
        Rectangle sourceRectangle;
        Rectangle hitbox;

        Vector2 position;
        Vector2 origin;

        float scale;
        float rotation;

        public Rectangle Hitbox { get { return hitbox; } }
        public Vector2 Position { get { return position; } }
        #endregion

        public Ball(Vector2 textureSize, Vector2 position, float scale=1)
        {
            this.position = position;
			scale = 1;
			rotation = 0;

            origin.Y = textureSize.Y / 2;
            origin.X = textureSize.X / 2;

            sourceRectangle = new Rectangle(0, 0,
                (int)(origin.X / 2), (int)(origin.Y / 2));

            hitbox = new Rectangle(0, 0,
                (int)(origin.X / 2), (int)(origin.Y / 2));
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
