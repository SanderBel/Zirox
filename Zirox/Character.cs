using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    public class Character : ICollide
    {
        public Vector2 Positie { get; set; }
        private Texture2D Texture { get; set; }
        private Rectangle _ShowRect;
        public Rectangle CollisionRectangle;


        // private Animation _animation;
        public Vector2 VelocityX = new Vector2(2, 0);
        public Vector2 VelocityY = new Vector2(0, 2);
        public Beweging _beweging { get; set; }



        public Character(Texture2D _texture, Vector2 _positie)
        {
            Texture = _texture;
            Positie = _positie;//new Vector2(200, 200);
            _ShowRect = new Rectangle(0, 0, 60, 100);
            CollisionRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 60, 100);


            /*  _animation = new Animation();
              _animation.AddFrame(new Rectangle(0, 0, 75, 125));
              _animation.AddFrame(new Rectangle(64, 0, 64, 205));
              _animation.AddFrame(new Rectangle(128, 0, 64, 205));
              _animation.AddFrame(new Rectangle(192, 0, 64, 205));
              _animation.AantalBewegingenPerSeconde = 8;*/
        }


        public void Update(GameTime gameTime)
        {
            _beweging.Update();

            if (_beweging.left)
                Positie -= VelocityX;
            if (_beweging.right)
                Positie += VelocityX;
            if (_beweging.up)
                Positie -= VelocityY;
            if (_beweging.down)
                Positie += VelocityY;

            CollisionRectangle.X = (int)Positie.X;
            CollisionRectangle.Y = (int)Positie.Y;


        }
        Rectangle _ShowRectangle = new Rectangle(0, 0, 60, 100);

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Positie, _ShowRectangle/*_animation.CurrentFrame.SourceRectangle*/, Color.AliceBlue);
        }

        public Rectangle GetCollisionRectangle()
        {
            return CollisionRectangle;
        }
    }
}
