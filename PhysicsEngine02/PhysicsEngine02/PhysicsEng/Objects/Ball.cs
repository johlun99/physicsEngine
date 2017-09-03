using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Ball(Vector2 textureSize, Vector2 position, float scale)
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Texture2D hitboxColor)
        {
            spriteBatch.Draw(hitboxColor, hitbox, Color.White);
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
