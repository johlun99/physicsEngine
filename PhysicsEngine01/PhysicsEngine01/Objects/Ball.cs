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
        Rectangle hitbox;
        Rectangle sourceRectangle;

        Vector2 position;
        Vector2 velocity;
        Vector2 origin;

        const float gravitationConstant = 9.8f;
        float scale = 0.08f;
        float rotation = 0;

        public Ball(Texture2D texture, Vector2 position)
        {
            this.position = position;

            origin.X = (int)(texture.Width / 2);
            origin.Y = (int)(texture.Height / 2);

            sourceRectangle = new Rectangle(0, 0,
                texture.Width, texture.Height);

            hitbox = new Rectangle(10, 10,
                (int)(texture.Width * scale), (int)(texture.Height * scale));
        }

        public void Update()
        {
            hitbox.Y = (int)position.Y;
            hitbox.X = (int)(position.X * origin.X);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Texture2D hitboxTexture)
        {
            spriteBatch.Draw(hitboxTexture, hitbox, Color.White);
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
