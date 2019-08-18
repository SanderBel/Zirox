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
        private Rectangle _ShowRect;
        private Rectangle rectangle;
        public Beweging _beweging { get; set; }
        private Animation _animationIdle;
        //private Animation _animationJump;
        private bool IsMoving = false;
        private bool FaceRight = true;
        SpriteEffects FlipVerticalEffect = SpriteEffects.FlipHorizontally;

        private bool hasJumped = false;

        public Vector2 Position
        {
            get { return position; }
        }

        public Character() { }

        public void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("CharSheet");

            _ShowRect = new Rectangle(0, 0, 54, 63);
            _animationIdle = new Animation();
            _animationIdle.AddFrame(new Rectangle(0, 0, 64, 74));
            _animationIdle.AddFrame(new Rectangle(64, 0, 64, 74));
            _animationIdle.AddFrame(new Rectangle(128, 0, 64, 74));
            _animationIdle.AddFrame(new Rectangle(192, 0, 64, 74));
            _animationIdle.AddFrame(new Rectangle(256, 0, 64, 74));
            _animationIdle.AddFrame(new Rectangle(320, 0, 64, 74));
            _animationIdle.AddFrame(new Rectangle(384, 0, 64, 74));
            _animationIdle.AddFrame(new Rectangle(448, 0, 64, 74));
            _animationIdle.AddFrame(new Rectangle(512, 0, 64, 74));
            _animationIdle.AddFrame(new Rectangle(576, 0, 64, 74));
            _animationIdle.AantalBewegingenPerSeconde = 8;

        //    _animationJump = new Animation();
        //    _animationJump.AddFrame(new Rectangle(0, 0, 64, 74));
        //    _animationJump.AddFrame(new Rectangle(64, 0, 64, 74));
        //    _animationJump.AddFrame(new Rectangle(128, 0, 64, 74));
        //    _animationJump.AddFrame(new Rectangle(192, 0, 64, 74));
        //    _animationJump.AddFrame(new Rectangle(256, 0, 64, 74));
        //    _animationJump.AddFrame(new Rectangle(320, 0, 64, 74));
        //    _animationJump.AddFrame(new Rectangle(384, 0, 64, 74));
        //    _animationJump.AddFrame(new Rectangle(448, 0, 64, 74));
        //    _animationJump.AddFrame(new Rectangle(512, 0, 64, 74));
        //    _animationJump.AddFrame(new Rectangle(576, 0, 64, 74));
        //    _animationJump.AantalBewegingenPerSeconde = 8;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, _ShowRect.Width, _ShowRect.Height);

            //Gravity
            if (velocity.Y < 10)
                velocity.Y += 0.4f;

            _beweging.Update();
            _animationIdle.Update(gameTime);

            if (_beweging.right)
            {
                FaceRight = true;
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                IsMoving = true;
            }
            else if (_beweging.left)
            {
                FaceRight = false;
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                IsMoving = true;
            }
            else
            {
                IsMoving = false;
                velocity.X = 0f;
            }

            if (_beweging.up && hasJumped == false)
            {
                position.Y -= 1f;
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
            if(FaceRight == true && IsMoving == false)
            spriteBatch.Draw(texture, rectangle, _animationIdle.CurrentFrame.SourceRectangle, Color.White);
            else if(FaceRight == false && IsMoving == false)
                spriteBatch.Draw(texture,rectangle, _animationIdle.CurrentFrame.SourceRectangle, Color.White, 0.0f, new Vector2(0,0), FlipVerticalEffect,0.0f);
        }
    }
}
