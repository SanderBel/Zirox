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
    class Tiles
    {
        protected Texture2D texture;

        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

    }

    //class CollisionTiles : Tiles
    //{
    //    public CollisionTiles(int i, Rectangle newRectangle)
    //    {
    //        texture = Content.Load<Texture2D>("Tile" + i);
    //        this.Rectangle = newRectangle;
    //    }
    //}



    //public class Tiles : ICollide
    //{
    //    public Texture2D _texture { get; set; }
    //    public Vector2 Position { get; set; }
    //    private Rectangle CollisionRectangle;
    //    private Rectangle _ShowRect;

    //    public Tiles(Texture2D texture, Vector2 pos)
    //    {
    //        _texture = texture;
    //        Position = pos;
    //        _ShowRect = new Rectangle(0, 0, 128, 128);
    //        CollisionRectangle = new Rectangle((int)pos.X,(int)pos.Y,texture.Width,texture.Height);
    //    }

    //    public void Draw(SpriteBatch spritebatch)
    //    {
    //        spritebatch.Draw(_texture, Position, Color.AliceBlue);
    //    }

    //    public Rectangle GetCollisionRectangle()
    //    {
    //        return CollisionRectangle;
    //    }
    //}
}
