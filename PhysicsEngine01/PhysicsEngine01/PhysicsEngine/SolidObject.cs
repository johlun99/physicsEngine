﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsEngine01.PhysicsEngine
{
    class SolidObject
    {
        protected Rectangle sourceRectangle;
        protected Rectangle hitbox;

        protected Vector2 position;
        protected Vector2 origin;
        protected Vector2 velocity;
        protected Vector2 force;

        protected const float gravityAccelleration = 0.9f;
        protected float scale = 0.01f;
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


    }
}