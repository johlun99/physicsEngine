using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsEngine02
{
    class Crosshair
    {
        Texture2D texture;

        Rectangle sourceRectangle;

        Vector2 position;
        Vector2 origin;

        float scale;
        float rotation;

        public Crosshair(Texture2D texture, float scale = 1)
        {
            this.texture = texture;
            this.scale = scale;

            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;

            sourceRectangle = new Rectangle(0, 0,
                texture.Width, texture.Height);
        }

        public void Update(Vector2 position)
        {
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
