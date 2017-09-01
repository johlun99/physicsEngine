using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsEngine01.PhysicsEngine.Objects
{
    class BallNew
    {
        #region Variables and properties
        Rectangle sourceRectangle;
        Rectangle hitbox;

        Vector2 position;
        Vector2 velocity;
        Vector2 acceleration;
        Vector2 origin;
        Vector2 force;

        float mass = 2;
        float scale;
        float rotation;

        const float gravityAcceleration = 0.8f;

        public Rectangle Hitbox { get { return hitbox; } }

        public Vector2 Position { get { return position; } }
        public Vector2 Velocity { get { return velocity; } }
        public Vector2 Force { get { return force; } }
        #endregion

        public BallNew(Vector2 textureSize, Vector2 position, float scale)
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

        public void Update()
        {
            velocity += acceleration;
            velocity.Y += gravityAcceleration;
            position += velocity;
            CalculateForce();
        }

        #region Calculation methods
        public void AddForce(Vector2 force)
        {
            this.force += force;
            CalculateAcceleration();
        }

        public void AddForce(Vector2 direction, float accelleration)
        {

        }

        private void CalculateForce()
        {
            force = acceleration * mass;
        }

        private void CalculateAcceleration()
        {
            acceleration = force / mass;
        }

        public void HandleCollision(BallNew ball)
        {

        }
        #endregion

        #region Draw methods
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
