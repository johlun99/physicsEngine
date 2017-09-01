using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsEngine01.PhysicsEngine.Objects
{
    abstract class SolidObject
    {
        #region Variables & Properties
        protected Rectangle sourceRectangle;
        protected Rectangle hitbox;

        protected Vector2 position;
        protected Vector2 origin;
        protected Vector2 velocity;
        protected Vector2 force;

        protected const float gravityAccelleration = 0.9f;
        protected float scale = 0.03f;
        protected float rotation = 0;
        protected float mass;

        protected int screenHeight;
        protected int screenWidth;

        public Vector2 Position
        {
            get
            {
                Vector2 temp = position;
                temp.Y -= origin.Y * scale;
                temp.X -= origin.X * scale;

                return temp;
            }
        }

        public Rectangle Hitbox { get { return hitbox; } }
        #endregion

        public void AddForce(Vector2 force)
        {
            this.force += force;
            velocity = force * mass;

            if (Math.Abs(velocity.Length()) < 0.1)
                velocity = new Vector2(0, 0);
        }

        public abstract void HandleCollision(Ball ball);
    }
}
