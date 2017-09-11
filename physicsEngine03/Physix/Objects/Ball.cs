using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Physix.Objects
{
    public class Ball
    {
        #region Variables and Properties
        Texture2D texture;

        Rectangle sourceRectangle;
        Rectangle hitbox;

        Vector2 acceleration;
        Vector2 velocity;
        Vector2 position;
        Vector2 origin;

        float scale;
        float rotation = 0;

        const float gravityAccelleration = 0.8f;

        public Rectangle Hitbox { get { return hitbox; } }
        public Vector2 Position { get { return position - origin; } }
        public Vector2 Velocity { get { return velocity; } }
        #endregion

        #region Constructors
        public Ball(Texture2D texture, Vector2 position, float scale = 1)
        {
            this.texture = texture;
            this.position = position;
            this.scale = scale;

            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;

            sourceRectangle = new Rectangle(0, 0,
                (int)texture.Width, (int)texture.Height);

            hitbox = new Rectangle(0, 0,
                (int)(texture.Width * scale), (int)(texture.Height * scale));
        }

        public Ball(Vector2 textureSize, Vector2 position, float scale=1)
        {
            this.position = position;
            this.scale = scale;

            origin.X = textureSize.X / 2;
            origin.Y = textureSize.Y / 2;

            sourceRectangle = new Rectangle(0, 0,
                (int)textureSize.X, (int)textureSize.Y);

            hitbox = new Rectangle(0, 0,
                (int)(textureSize.X * scale), (int)(textureSize.Y * scale));
        }
        #endregion

        public void Update()
        {
            CalculateVelocity();

            position += velocity;

            hitbox.Y = (int)(position.Y - origin.Y * scale);
            hitbox.X = (int)(position.X - origin.X * scale);
        }

        public void AddVelocity(Vector2 velocity)
        {
            this.velocity += velocity;
        }

        private void CalculateVelocity()
        {
            acceleration.Y += gravityAccelleration;
            velocity += acceleration;
        }

        #region Draw Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
        }

        public void DrawWithHitbox(SpriteBatch spriteBatch, Texture2D hitboxColor)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
            spriteBatch.Draw(hitboxColor, hitbox, Color.White);
        }

        public void DrawWithHitbox(SpriteBatch spriteBatch, Texture2D texture, Texture2D hitboxColor)
        {

        }
        #endregion
    }
}
