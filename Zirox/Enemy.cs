using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    class Enemy
    {
        Texture2D texture;
        Rectangle rectangle;
        Vector2 position;
        Vector2 origin;
        Vector2 velocity;

        bool isFacingRight;
        float distance;
        float oldDistance;

        public Enemy(Texture2D newTexture, Vector2 newPosition, float newDistance)
        {
            texture = newTexture;
            position = newPosition;
            distance = newDistance;

            oldDistance = distance;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);

            if (distance <= 0)
            {
                isFacingRight = true;
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 4;
            }
            else if(distance >= oldDistance)
            {
                isFacingRight = false;
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 4;
            }

            if (isFacingRight)
                distance += 1;
            else
                distance -= 1;
                
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Moving right to draw, Flip it for facing left
            if (velocity.X > 0)
                spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, 1f, SpriteEffects.FlipHorizontally, 0f);
            else
                spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0f);
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
                velocity.Y = 0f;
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
    }
}
