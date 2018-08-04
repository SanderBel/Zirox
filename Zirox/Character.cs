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
        public Rectangle ResizeRect;


        // private Animation _animation;
        public Vector2 VelocityX = new Vector2(2, 0);
        public Beweging _beweging { get; set; }



        public Character(Texture2D _texture, Vector2 _positie)
        {
            Texture = _texture;
            Positie = _positie;//new Vector2(200, 200);
            _ShowRect = new Rectangle(0, 0, 75, 150);
            ResizeRect = new Rectangle(0, 0, 75, 150);
            CollisionRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 75, 150);


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


            if (_beweging.left || _beweging.right)
            // _animation.Update(gameTime);
            {
                _ShowRectangle.X += 75;
                if (_ShowRectangle.X > 150)
                    _ShowRectangle.X = 0;
            }
            if (_beweging.up || _beweging.down)
            // _animation.Update(gameTime);
            {
                _ShowRectangle.Y += 75;
                if (_ShowRectangle.Y > 150)
                    _ShowRectangle.Y = 0;
            }

            if (_beweging.left)
                Positie -= VelocityX;
            if (_beweging.right)
                Positie += VelocityX;

            CollisionRectangle.X = (int)Positie.X;
            CollisionRectangle.Y = (int)Positie.Y;


        }
        Rectangle _ShowRectangle = new Rectangle(0, 0, 75, 150);

        public void Draw(SpriteBatch spritebatch, Rectangle rectangle)
        {
            spritebatch.Draw(Texture, Positie, _ShowRectangle/*_animation.CurrentFrame.SourceRectangle*/, Color.AliceBlue);
        }

        public Rectangle GetCollisionRectangle()
        {
            return CollisionRectangle;
        }

        public Rectangle GetResizeRect()
        {
            return ResizeRect;
        }

    }
}
