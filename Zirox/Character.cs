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
        private Vector2 position = new Vector2(64, 512);
        private Vector2 velocity;
        private Rectangle _ShowRect;
        private Rectangle rectangle;
        public Beweging _beweging { get; set; }
        private Animation _animationIdle;
        private Animation _animationJump;
        private Animation _animationRun;
        private Animation _animationShootIdle;
        private Animation _animationShootRun;
        private Animation _animationHurt;
        private Animation _animationDead;
        private Texture2D bulletTexture;
        private List<Bullet> bullets = new List<Bullet>();
        private bool isMoving = false;
        private bool faceRight = true;
        private bool hasShot = false;
        private bool hasBeenShot = false;
        private bool isDead = false;
        private bool hasJumped = false;
        private float speed;

        SpriteEffects FlipVerticalEffect = SpriteEffects.FlipHorizontally;

        

        public Vector2 Position
        {
            get { return position; }
        }

        public bool FaceRight
        {
            get { return faceRight; }
        }

        public float Speed
        {
            get { return speed; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        public Character() { }

        public void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("CharSheet");
            bulletTexture = Content.Load<Texture2D>("Bullet");
            

            #region Animations
            _ShowRect = new Rectangle(0, 0, 54, 63);
            _animationIdle = new Animation();
            _animationIdle.AddFrame(new Rectangle(0, 0, 64, 76));
            _animationIdle.AddFrame(new Rectangle(64, 0, 64, 76));
            _animationIdle.AddFrame(new Rectangle(128, 0, 64, 76));
            _animationIdle.AddFrame(new Rectangle(192, 0, 64, 76));
            _animationIdle.AddFrame(new Rectangle(256, 0, 64, 76));
            _animationIdle.AddFrame(new Rectangle(320, 0, 64, 76));
            _animationIdle.AddFrame(new Rectangle(384, 0, 64, 76));
            _animationIdle.AddFrame(new Rectangle(448, 0, 64, 76));
            _animationIdle.AddFrame(new Rectangle(512, 0, 64, 76));
            _animationIdle.AddFrame(new Rectangle(576, 0, 64, 76));
            _animationIdle.AantalBewegingenPerSeconde = 16;
            
            _animationJump = new Animation();
            _animationJump.AddFrame(new Rectangle(0, 390, 64, 76));
            _animationJump.AddFrame(new Rectangle(64, 390, 64, 76));
            _animationJump.AddFrame(new Rectangle(128, 390, 64, 76));
            _animationJump.AddFrame(new Rectangle(192, 390, 64, 76));
            _animationJump.AddFrame(new Rectangle(256, 390, 64, 76));
            _animationJump.AddFrame(new Rectangle(320, 390, 64, 76));
            _animationJump.AddFrame(new Rectangle(384, 390, 64, 76));
            _animationJump.AddFrame(new Rectangle(448, 390, 64, 76));
            _animationJump.AddFrame(new Rectangle(512, 390, 64, 76));
            _animationJump.AddFrame(new Rectangle(576, 390, 64, 76));
            _animationJump.AddFrame(new Rectangle(0, 470, 64, 76));
            _animationJump.AddFrame(new Rectangle(64, 470, 64, 76));
            _animationJump.AddFrame(new Rectangle(128, 470, 64, 76));
            _animationJump.AddFrame(new Rectangle(192, 470, 64, 76));
            _animationJump.AddFrame(new Rectangle(256, 470, 64, 76));
            _animationJump.AddFrame(new Rectangle(320, 470, 64, 76));
            _animationJump.AddFrame(new Rectangle(384, 470, 64, 76));
            _animationJump.AddFrame(new Rectangle(448, 470, 64, 78));
            _animationJump.AddFrame(new Rectangle(512, 470, 64, 84));
            _animationJump.AddFrame(new Rectangle(576, 470, 64, 84));
            _animationJump.AddFrame(new Rectangle(0, 560, 64, 78));
            _animationJump.AddFrame(new Rectangle(64, 560, 64, 76));
            _animationJump.AddFrame(new Rectangle(128, 560, 64, 76));
            _animationJump.AddFrame(new Rectangle(192, 560, 64, 76));
            _animationJump.AddFrame(new Rectangle(256, 560, 64, 76));
            _animationJump.AddFrame(new Rectangle(320, 560, 64, 76));
            _animationJump.AddFrame(new Rectangle(384, 560, 64, 76));
            _animationJump.AddFrame(new Rectangle(448, 560, 64, 76));
            _animationJump.AddFrame(new Rectangle(512, 560, 64, 76));
            _animationJump.AddFrame(new Rectangle(576, 560, 64, 76));
            _animationJump.AddFrame(new Rectangle(0, 640, 64, 76));
            _animationJump.AddFrame(new Rectangle(64, 640, 64, 76));
            _animationJump.AddFrame(new Rectangle(128, 640, 64, 76));
            _animationJump.AddFrame(new Rectangle(192, 640, 64, 76));
            _animationJump.AddFrame(new Rectangle(256, 640, 64, 76));
            _animationJump.AantalBewegingenPerSeconde = 24;
            
            _animationRun = new Animation();
            _animationRun.AddFrame(new Rectangle(0, 228, 64, 74));
            _animationRun.AddFrame(new Rectangle(64, 228, 64, 74));
            _animationRun.AddFrame(new Rectangle(128, 228, 64, 74));
            _animationRun.AddFrame(new Rectangle(192, 228, 64, 74));
            _animationRun.AddFrame(new Rectangle(256, 228, 64, 74));
            _animationRun.AddFrame(new Rectangle(320, 228, 64, 74));
            _animationRun.AddFrame(new Rectangle(0, 310, 64, 74));
            _animationRun.AddFrame(new Rectangle(64, 310, 64, 74));
            _animationRun.AddFrame(new Rectangle(128, 310, 64, 74));
            _animationRun.AddFrame(new Rectangle(192, 310, 64, 74));
            _animationRun.AddFrame(new Rectangle(256, 310, 64, 74));
            _animationRun.AddFrame(new Rectangle(320, 310, 64, 74));
            _animationRun.AddFrame(new Rectangle(384, 310, 64, 74));
            _animationRun.AddFrame(new Rectangle(448, 310, 64, 74));
            _animationRun.AddFrame(new Rectangle(512, 310, 64, 74));
            _animationRun.AddFrame(new Rectangle(576, 310, 64, 74));
            _animationRun.AantalBewegingenPerSeconde = 16;

            _animationShootIdle = new Animation();
            _animationShootIdle.AddFrame(new Rectangle(0, 800, 64, 70));
            _animationShootIdle.AddFrame(new Rectangle(64, 800, 64, 70));
            _animationShootIdle.AddFrame(new Rectangle(128, 800, 64, 70));
            _animationShootIdle.AddFrame(new Rectangle(192, 800, 64, 70));
            _animationShootIdle.AddFrame(new Rectangle(256, 800, 64, 70));
            _animationShootIdle.AddFrame(new Rectangle(320, 800, 64, 70));
            _animationShootIdle.AddFrame(new Rectangle(384, 800, 64, 70));
            _animationShootIdle.AddFrame(new Rectangle(448, 800, 64, 70));
            _animationShootIdle.AddFrame(new Rectangle(512, 800, 64, 70));
            _animationShootIdle.AantalBewegingenPerSeconde = 16;

            _animationShootRun = new Animation();
            _animationShootRun.AddFrame(new Rectangle(0, 720, 64, 76));
            _animationShootRun.AddFrame(new Rectangle(64, 720, 64, 76));
            _animationShootRun.AddFrame(new Rectangle(128, 720, 64, 76));
            _animationShootRun.AddFrame(new Rectangle(192, 720, 64, 76));
            _animationShootRun.AddFrame(new Rectangle(256, 720, 64, 76));
            _animationShootRun.AddFrame(new Rectangle(320, 720, 64, 76));
            _animationShootRun.AddFrame(new Rectangle(384, 720, 64, 76));
            _animationShootRun.AddFrame(new Rectangle(448, 720, 64, 76));
            _animationShootRun.AddFrame(new Rectangle(512, 720, 64, 76));
            _animationShootRun.AddFrame(new Rectangle(576, 720, 64, 76));
            _animationShootRun.AantalBewegingenPerSeconde = 16;

            _animationHurt = new Animation();
            _animationHurt.AddFrame(new Rectangle(0, 152, 64, 76));
            _animationHurt.AddFrame(new Rectangle(64, 152, 64, 76));
            _animationHurt.AddFrame(new Rectangle(128, 152, 64, 76));
            _animationHurt.AddFrame(new Rectangle(192, 152, 64, 76));
            _animationHurt.AddFrame(new Rectangle(256, 152, 64, 76));
            _animationHurt.AddFrame(new Rectangle(320, 152, 64, 76));
            _animationHurt.AddFrame(new Rectangle(384, 152, 64, 76));
            _animationHurt.AddFrame(new Rectangle(448, 152, 64, 76));
            _animationHurt.AddFrame(new Rectangle(512, 152, 64, 76));
            _animationHurt.AantalBewegingenPerSeconde = 16;

            _animationDead = new Animation();
            _animationDead.AddFrame(new Rectangle(0, 870, 112, 80));
            _animationDead.AddFrame(new Rectangle(112, 870, 112, 80));
            _animationDead.AddFrame(new Rectangle(224, 870, 112, 80));
            _animationDead.AddFrame(new Rectangle(336, 870, 112, 80));
            _animationDead.AddFrame(new Rectangle(448, 870, 112, 80));
            _animationDead.AddFrame(new Rectangle(560, 870, 112, 80));
            _animationDead.AddFrame(new Rectangle(672, 870, 112, 80));
            _animationDead.AddFrame(new Rectangle(784, 870, 112, 80));
            _animationDead.AddFrame(new Rectangle(896, 870, 112, 80));
            _animationDead.AddFrame(new Rectangle(0, 950, 112, 80));
            _animationDead.AddFrame(new Rectangle(112, 950, 112, 80));
            _animationDead.AddFrame(new Rectangle(224, 950, 112, 80));
            _animationDead.AddFrame(new Rectangle(336, 950, 112, 80));
            _animationDead.AddFrame(new Rectangle(448, 950, 112, 80));
            _animationDead.AddFrame(new Rectangle(560, 950, 112, 80));
            _animationDead.AddFrame(new Rectangle(672, 950, 112, 80));
            _animationDead.AddFrame(new Rectangle(784, 950, 112, 80));
            _animationDead.AddFrame(new Rectangle(896, 950, 112, 80));
            _animationDead.AddFrame(new Rectangle(0, 1030, 112, 80));
            _animationDead.AddFrame(new Rectangle(112, 1030, 112, 80));
            _animationDead.AddFrame(new Rectangle(224, 1030, 112, 80));
            _animationDead.AddFrame(new Rectangle(336, 1030, 112, 80));
            _animationDead.AddFrame(new Rectangle(448, 1030, 112, 80));
            _animationDead.AddFrame(new Rectangle(560, 1030, 112, 80));
            _animationDead.AddFrame(new Rectangle(672, 1030, 112, 80));
            _animationDead.AddFrame(new Rectangle(784, 1030, 112, 80));
            _animationDead.AddFrame(new Rectangle(896, 1030, 112, 80));
            _animationDead.AddFrame(new Rectangle(0, 1110, 112, 80));
            _animationDead.AddFrame(new Rectangle(112, 1110, 112, 80));
            _animationDead.AddFrame(new Rectangle(224, 1110, 112, 80));
            _animationDead.AddFrame(new Rectangle(336, 1110, 112, 80));
            _animationDead.AddFrame(new Rectangle(448, 1110, 112, 80));
            _animationDead.AddFrame(new Rectangle(560, 1110, 112, 80));
            _animationDead.AddFrame(new Rectangle(672, 1110, 112, 80));
            _animationDead.AddFrame(new Rectangle(784, 1110, 112, 80));
            _animationDead.AddFrame(new Rectangle(896, 1110, 112, 80));
            _animationDead.AantalBewegingenPerSeconde = 16;
            #endregion
        }

        public void Update(List<Enemy> enemies,GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, _ShowRect.Width, _ShowRect.Height);
            speed = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

            //Gravity
            if (velocity.Y < 10)
                velocity.Y += 0.5f;

            _beweging.Update();
            _animationIdle.Update(gameTime);
            _animationJump.Update(gameTime);
            _animationRun.Update(gameTime);
            _animationShootIdle.Update(gameTime);
            _animationShootRun.Update(gameTime);
            _animationHurt.Update(gameTime);
            _animationDead.Update(gameTime);

            if (_beweging.right)
            {
                faceRight = true;
                velocity.X = speed;
                isMoving = true;
            }
            else if (_beweging.left)
            {
                faceRight = false;
                velocity.X = -speed;
                isMoving = true;
            }
            else
            {
                isMoving = false;
                velocity.X = 0f;
            }

            if (_beweging.up && hasJumped == false)
            {
                position.Y -= 1f;
                velocity.Y = -16f;
                hasJumped = true;
            }
            if (_beweging.shoot == true && bullets.Count < 5 && hasShot == false)
            {
                bullets.Add(new Bullet(this, bulletTexture, 1));
                hasShot = true;
                _beweging.shoot = false;
            }
            else
                hasShot = false;

            for (int i = 0; i < bullets.Count; i++)
            {
                if (Vector2.Distance(bullets[i].Position, Position) > 500)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }

            //velocity.X = Speed;

            bullets.ForEach(b => b.Update());

            //Collision
           // foreach (Enemy enemy in enemies)
            //{
                for (int j = 1; j < enemies.Count; j++)
                {
                    for (int i = 0; i < bullets.Count; i++)
                    {
                        if (bullets[i].Rectangle.Intersects(enemies[j].Rectangle) && j > 0)
                        {
                            enemies.RemoveAt(j);
                            bullets.RemoveAt(i);
                            j--;
                            i--;
                        }
                    }
                }
                    
            //}
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
            bullets.ForEach(b => b.Draw(spriteBatch));

            if (hasShot == true && faceRight == true && isMoving == false && hasBeenShot == false && isDead == false)
                spriteBatch.Draw(texture, rectangle, _animationShootIdle.CurrentFrame.SourceRectangle, Color.White);
            else if (hasShot == true && faceRight == false && isMoving == false && hasBeenShot == false && isDead == false)
                spriteBatch.Draw(texture, rectangle, _animationShootIdle.CurrentFrame.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), FlipVerticalEffect, 0.0f);
            else if (hasShot == true && faceRight == true && isMoving == true && hasBeenShot == false && isDead == false)
                spriteBatch.Draw(texture, rectangle, _animationShootRun.CurrentFrame.SourceRectangle, Color.White);
            else if (hasShot == true && faceRight == false && isMoving == true && hasBeenShot == false && isDead == false)
                spriteBatch.Draw(texture, rectangle, _animationShootRun.CurrentFrame.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), FlipVerticalEffect, 0.0f);
            else if (hasShot == false && faceRight == true && isMoving == false && hasJumped == false && hasBeenShot == false && isDead == false)
                spriteBatch.Draw(texture, rectangle, _animationIdle.CurrentFrame.SourceRectangle, Color.White);
            else if(hasShot == false && faceRight == false && isMoving == false && hasJumped == false && hasBeenShot == false && isDead == false)
                spriteBatch.Draw(texture,rectangle, _animationIdle.CurrentFrame.SourceRectangle, Color.White, 0.0f, new Vector2(0,0), FlipVerticalEffect,0.0f);
            else if (hasShot == false && faceRight == true && isMoving == true && hasJumped == false && hasBeenShot == false && isDead == false)
                spriteBatch.Draw(texture, rectangle, _animationRun.CurrentFrame.SourceRectangle, Color.White);
            else if (hasShot == false && faceRight == false && isMoving == true && hasJumped == false && hasBeenShot == false && isDead == false)
                spriteBatch.Draw(texture, rectangle, _animationRun.CurrentFrame.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), FlipVerticalEffect, 0.0f);
            else if(hasShot == false && faceRight == true && hasJumped == true && hasBeenShot == false && isDead == false)
                spriteBatch.Draw(texture, rectangle, _animationJump.CurrentFrame.SourceRectangle, Color.White);
            else if (hasShot == false && faceRight == false && hasJumped == true && hasBeenShot == false && isDead == false)
                spriteBatch.Draw(texture, rectangle, _animationJump.CurrentFrame.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), FlipVerticalEffect, 0.0f);

            if (hasBeenShot == true && isDead == false && faceRight == true)
                spriteBatch.Draw(texture, rectangle, _animationHurt.CurrentFrame.SourceRectangle, Color.White);
            else if (hasBeenShot == true && isDead == false && faceRight == true)
                spriteBatch.Draw(texture, rectangle, _animationHurt.CurrentFrame.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), FlipVerticalEffect, 0.0f);
            if (isDead == true && faceRight == true)
                spriteBatch.Draw(texture, rectangle, _animationDead.CurrentFrame.SourceRectangle, Color.White);
            else if (isDead == true && faceRight == true)
                spriteBatch.Draw(texture, rectangle, _animationDead.CurrentFrame.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), FlipVerticalEffect, 0.0f);

        }
    }
}
