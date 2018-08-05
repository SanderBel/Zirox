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
        Matrix m;
        public Vector2 Positie { get; set; }
        private Texture2D Texture { get; set; }
        private Rectangle _ShowRect;
        public Rectangle CollisionRectangle;


        // private Animation _animation;
        public Vector2 VelocityX = new Vector2(2, 0);
        public Vector2 VelocityY = new Vector2(0, 2);
        public Beweging _beweging { get; set; }


        Matrix rotationYMatrix;
        public bool IsMoving = false;

        public Character(Texture2D _texture, Vector2 _positie)
        {
            m = new Matrix();
            rotationYMatrix = Matrix.CreateRotationY((float)Math.PI / 2);
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

            if (_beweging.left || _beweging.right || _beweging.up || _beweging.down)
                IsMoving = true;
            else
                IsMoving = false;

            if (_beweging.left)
                VelocityX.X = -2;
            else if (_beweging.right)
                VelocityX.X = 5;
            else if (_beweging.up)
                VelocityY.Y = -2;
            else if (_beweging.down)
                VelocityY.Y = 2;
            else
            {
                VelocityX.X = 0;
                VelocityY.Y = 0;
            }

            Positie += VelocityX;
            Positie += VelocityY;
            CollisionRectangle.X = (int)Positie.X;
            CollisionRectangle.Y = (int)Positie.Y;


        }
        Rectangle _ShowRectangle = new Rectangle(0, 0, 55, 94);

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
