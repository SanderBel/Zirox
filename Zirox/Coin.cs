using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    class Coin
    {
        Texture2D texture;
        Vector2 position;
        Vector2 origin;
        protected Rectangle rectangle = Rectangle.Empty;

        public int Width
        {
            get { return texture.Width; }
        }

        public int Height
        {
            get { return texture.Height; }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(rectangle.X - (rectangle.Width / 2), rectangle.Y - (rectangle.Height / 2), rectangle.Width, rectangle.Height);
            }
            set { rectangle = value; }
        }

        public Coin(Texture2D newTexture, Vector2 newPosition)
        {
            position = newPosition;
            texture = newTexture;
        }

        public void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Coin");
        }

        public void Update(GameTime gameTime)
        {
            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width - (texture.Width / 2), texture.Height - (texture.Height / 2));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
