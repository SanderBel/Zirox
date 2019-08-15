using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    public class Character
    {
        private Texture2D texture;
        private Vector2 position = new Vector2(64, 256);
        private Vector2 velocity;
        private Rectangle rectangle;
        public Beweging _beweging { get; set; }
        private Animation _animation;
        public bool IsMoving = false;

        private bool hasJumped = false;

        public Vector2 Position
        {
            get { return position; }
        }

        public Character() { }

        public void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Zirox");
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (velocity.Y < 10)
                velocity.Y += 0.4f;

            _beweging.Update();

            if (_beweging.left || _beweging.right || _beweging.up || _beweging.down)
            {
                IsMoving = true;
                //_animation.Update(gameTime);
            }
            else
                IsMoving = false;

            if (_beweging.right)
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else if (_beweging.left)
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else velocity.X = 0f;

            if (_beweging.up && hasJumped == false)
            {
                position.Y -= 3f;
                velocity.Y = -10f;
                hasJumped = true;
            }

        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }

            if (rectangle.TouchLeftOf(newRectangle))
                position.X = newRectangle.X - rectangle.Width - 2;
            if (rectangle.TouchRightOf(newRectangle))
                position.X = newRectangle.X + newRectangle.Width + 2;
            if (rectangle.TouchBottomOf(newRectangle))
                velocity.Y = 1f;

            if (position.X < 0)
                position.X = 0;
            if (position.X > xOffset - rectangle.Width)
                position.X = xOffset - rectangle.Width;
            if (position.Y < 0)
                position.Y = 0;
            if (position.Y > yOffset - rectangle.Height)
                position.Y = yOffset - rectangle.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }


        //Matrix m;
        //Matrix rotationYMatrix;
        //public Vector2 Positie { get; set; }
        //private Texture2D Texture { get; set; }
        //private Rectangle _ShowRect;
        //public Rectangle CollisionRectangle;

        //private Animation _animation;
        //public Vector2 VelocityX = new Vector2(4f, 0);
        //public Vector2 VelocityY = new Vector2(0, 7f);
        //public Beweging _beweging { get; set; }

        //public bool IsMoving = false;

        //public Character(Texture2D _texture, Vector2 _positie)
        //{
        //    m = new Matrix();
        //    rotationYMatrix = Matrix.CreateRotationY((float)Math.PI / 2);
        //    Texture = _texture;
        //    Positie = _positie;
        //    _ShowRect = new Rectangle(0, 0, 64, 75);
        //    CollisionRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 64, 75);

        //    _animation = new Animation();
        //    _animation.AddFrame(new Rectangle(0, 0, 64, 74));
        //    _animation.AddFrame(new Rectangle(64, 0, 64, 74));
        //    _animation.AddFrame(new Rectangle(128, 0, 64, 74));
        //    _animation.AddFrame(new Rectangle(192, 0, 64, 74));
        //    _animation.AddFrame(new Rectangle(256, 0, 64, 74));
        //    _animation.AddFrame(new Rectangle(320, 0, 64, 74));
        //    _animation.AddFrame(new Rectangle(384, 0, 64, 74));
        //    _animation.AddFrame(new Rectangle(448, 0, 64, 74));
        //    _animation.AddFrame(new Rectangle(512, 0, 64, 74));
        //    _animation.AddFrame(new Rectangle(576, 0, 64, 74));
        //    _animation.AantalBewegingenPerSeconde = 8;
        //}

        //public void Update(GameTime gameTime)
        //{
        //    _beweging.Update();

        //    if (_beweging.left || _beweging.right || _beweging.up || _beweging.down)
        //    {
        //        IsMoving = true;
        //        _animation.Update(gameTime);
        //    }
        //    else
        //        IsMoving = false;

        //    if(_beweging.left)
        //    {
        //        Positie -= VelocityX;
        //    }
        //    else if(_beweging.right)
        //    {
        //        Positie += VelocityX;
        //    }
        //    if (_beweging.up)
        //    {
        //        Positie -= VelocityY;
        //        VelocityY.Y -= 0.15f;
        //    }
        //    else
        //    {
        //        VelocityX.X = 0;
        //        VelocityY.Y += 0.15f;
        //    }

        //    Positie += VelocityX;
        //    Positie += VelocityY;
        //    CollisionRectangle.X = (int)Positie.X;
        //    CollisionRectangle.Y = (int)Positie.Y;
        //}

        //public void Draw(SpriteBatch spritebatch)
        //{
        //    spritebatch.Draw(Texture, Positie, _animation.CurrentFrame.SourceRectangle, Color.AliceBlue);
        //}

        //public Rectangle GetCollisionRectangle()
        //{
        //    return CollisionRectangle;
        //}
    }
}
