using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    public class BaseSprite
    {
        protected Texture2D texture = null;
        protected Vector2 position = Vector2.Zero;
        protected Vector2 velocity = Vector2.Zero;
        protected Vector2 origin = Vector2.Zero;
        protected float scale = 1;

        protected Rectangle rectangle = Rectangle.Empty;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(rectangle.X - (rectangle.Width / 2), rectangle.Y - (rectangle.Height / 2), rectangle.Width, rectangle.Height);
            }
            set { rectangle = value; }
        }

    }
}
