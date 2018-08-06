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
        private Texture2D Texture1 { get; set; }
        private Texture2D Texture2 { get; set; }
        private Texture2D Texture3 { get; set; }
        private Texture2D Texture4 { get; set; }
        private Texture2D Texture5 { get; set; }
        private Texture2D Texture6 { get; set; }
        private Texture2D Texture7 { get; set; }
        private Texture2D Texture8 { get; set; }
        private Rectangle _ShowRect;
        public Rectangle CollisionRectangle;

        private Animation _animation;
        public Vector2 VelocityX = new Vector2(2, 0);
        public Vector2 VelocityY = new Vector2(0, 2);
        public Beweging _beweging { get; set; }

        Matrix rotationYMatrix;
        public bool IsMoving = false;

        public Character(Texture2D _texture1, Texture2D _texture2, Texture2D _texture3, Texture2D _texture4, Texture2D _texture5, Texture2D _texture6, Texture2D _texture7, Texture2D _texture8,
                         Vector2 _positie)
        {
            m = new Matrix();
            rotationYMatrix = Matrix.CreateRotationY((float)Math.PI / 2);
            Texture1 = _texture1;
            Texture2 = _texture2;
            Texture3 = _texture3;
            Texture4 = _texture4;
            Texture5 = _texture5;
            Texture6 = _texture6;
            Texture7 = _texture7;
            Texture8 = _texture8;
            Positie = _positie;
            CollisionRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 60, 100);

            _animation = new Animation();
            _animation.AddFrame(_texture1);
            _animation.AddFrame(_texture2);
            _animation.AddFrame(_texture3);
            _animation.AddFrame(_texture4);
            _animation.AddFrame(_texture5);
            _animation.AddFrame(_texture6);
            _animation.AddFrame(_texture7);
            _animation.AddFrame(_texture8);
            _animation.AantalBewegingenPerSeconde = 8;
        }

        public void Update(GameTime gameTime)
        {
            _beweging.Update();

            if (_beweging.left || _beweging.right || _beweging.up || _beweging.down)
            {
                IsMoving = true;
                _animation.Update(gameTime);
            }
            else
                IsMoving = false;

            if(_beweging.left)
            {
                VelocityX.X = -5f;
               // VelocityY.Y += 0.3f;
            }
            else if(_beweging.right)
            {
                VelocityX.X = 5f;
               // VelocityY.Y += 0.3f;
            }
            else if (_beweging.up)
            {
                VelocityY.Y = -7f;
                VelocityX.X = 0f;
            }
            else if (_beweging.down)
            {
                VelocityY.Y = 7f;
                VelocityX.X = 0f;
            }
            else
            {
                VelocityX.X = 0;
                //VelocityY.Y += 0.3f;
            }

            Positie += VelocityX;
            Positie += VelocityY;
            CollisionRectangle.X = (int)Positie.X;
            CollisionRectangle.Y = (int)Positie.Y;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_animation.CurrentFrame.SourceTexture, Positie, Color.AliceBlue);
        }

        public Rectangle GetCollisionRectangle()
        {
            return CollisionRectangle;
        }
    }
}
