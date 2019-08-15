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
        Matrix rotationYMatrix;
        public Vector2 Positie { get; set; }
        private Texture2D Texture { get; set; }
        private Rectangle _ShowRect;
        public Rectangle CollisionRectangle;

        private Animation _animation;
        public Vector2 VelocityX = new Vector2(4f, 0);
        public Vector2 VelocityY = new Vector2(0, 7f);
        public Beweging _beweging { get; set; }

        public bool IsMoving = false;

        public Character(Texture2D _texture, Vector2 _positie)
        {
            m = new Matrix();
            rotationYMatrix = Matrix.CreateRotationY((float)Math.PI / 2);
            Texture = _texture;
            Positie = _positie;
            _ShowRect = new Rectangle(0, 0, 64, 75);
            CollisionRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 64, 75);

            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 64, 74));
            _animation.AddFrame(new Rectangle(64, 0, 64, 74));
            _animation.AddFrame(new Rectangle(128, 0, 64, 74));
            _animation.AddFrame(new Rectangle(192, 0, 64, 74));
            _animation.AddFrame(new Rectangle(256, 0, 64, 74));
            _animation.AddFrame(new Rectangle(320, 0, 64, 74));
            _animation.AddFrame(new Rectangle(384, 0, 64, 74));
            _animation.AddFrame(new Rectangle(448, 0, 64, 74));
            _animation.AddFrame(new Rectangle(512, 0, 64, 74));
            _animation.AddFrame(new Rectangle(576, 0, 64, 74));
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
                Positie -= VelocityX;
            }
            else if(_beweging.right)
            {
                Positie += VelocityX;
            }
            if (_beweging.up)
            {
                Positie -= VelocityY;
                VelocityY.Y -= 0.15f;
            }
            else
            {
                VelocityX.X = 0;
                VelocityY.Y += 0.15f;
            }

            Positie += VelocityX;
            Positie += VelocityY;
            CollisionRectangle.X = (int)Positie.X;
            CollisionRectangle.Y = (int)Positie.Y;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Positie, _animation.CurrentFrame.SourceRectangle, Color.AliceBlue);
        }

        public Rectangle GetCollisionRectangle()
        {
            return CollisionRectangle;
        }
    }
}
