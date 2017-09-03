using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsEngine02.PhysicsEng.Objects
{
    class Ball
    {
        Texture2D texture;

        Rectangle sourceRectangle;
        Rectangle hitbox;

        Vector2 position;
        Vector2 origin;
        Vector2 velocity;
        Vector2 acceleration;
        Vector2 force;

        float rotation;
        float scale;
        const float gravityAccelleration = 0.8f;

        public float Radius { get { return hitbox.Width / 2; } }
        public Vector2 Position { get { return position; } }
        public Rectangle Hitbox { get { return hitbox; } }

        public Ball(Vector2 textureSize, Vector2 position, float scale)
        {
            this.position = position;
            this.scale = scale;

            sourceRectangle = new Rectangle(0, 0,
                (int)textureSize.X, (int)textureSize.Y);

            hitbox = new Rectangle(0, 0,
                (int)(textureSize.X * scale), (int)(textureSize.Y * scale));

            origin.X = textureSize.X / 2;
            origin.Y = textureSize.Y / 2;
        }

        public Ball(Texture2D texture, Vector2 position, float scale)
        {
            this.texture = texture;
            this.position = position;
            this.scale = scale;

            sourceRectangle = new Rectangle(0, 0,
                texture.Width, texture.Height);

            hitbox = new Rectangle(0, 0,
                (int)(texture.Width * scale), (int)(texture.Height * scale));

            origin.X = texture.Width / 2 * scale;
            origin.Y = texture.Height / 2 * scale;
        }

        public void Update()
        {
            Move();
        }

        private void Move()
        {
            velocity.Y += gravityAccelleration;

            position += velocity;

            hitbox.X = (int)(position.X - origin.X * scale);
            hitbox.Y = (int)(position.Y - origin.Y * scale);
        }

        #region Draw Methods
        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Texture2D hitboxColor)
        {
            spriteBatch.Draw(hitboxColor, hitbox, Color.White);
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
        #endregion
    }
}
