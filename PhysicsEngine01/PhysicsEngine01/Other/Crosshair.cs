using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsEngine01.Other
{
    class Crosshair
    {
        Texture2D texture;

        Rectangle sourceRectangle;

        Vector2 position;
        Vector2 origin;

        float scale;
        float rotation = 0;

        public Crosshair(Texture2D texture, float scale)
        {
            this.texture = texture;
            this.scale = scale;

            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;

            sourceRectangle = new Rectangle(0, 0,
                texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(position.X - origin.X, position.Y - origin.Y), sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
