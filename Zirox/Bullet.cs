using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    class Bullet
    {
        protected Texture2D texture = null;
        protected Vector2 position = Vector2.Zero;
        protected Vector2 velocity = Vector2.Zero;
        protected Vector2 origin = Vector2.Zero;
        protected float scale = 1;
        protected float minSpeed, maxSpeed;
        private float speed = 0;
        private bool faceRight = true;

        protected Rectangle rectangle = Rectangle.Empty;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(rectangle.X - (rectangle.Width / 2), rectangle.Y - (rectangle.Height / 2), rectangle.Width, rectangle.Height);
            }
            set { rectangle = value; }
        }
                
        public float Speed
        {
            get { return speed; }
            set
            {
                speed = MathHelper.Clamp(value, minSpeed, maxSpeed);
            }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Bullet(Character character, Texture2D newTexture, float newSpeed)
        {
            position = character.Position;
            faceRight = character.FaceRight;

            texture = newTexture;
            Speed = character.Speed + newSpeed;
        }

        public void Update()
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);

            if (faceRight == true)
                velocity.X = Speed;
            else
                velocity.X = -Speed;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (faceRight == true)
                spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, scale, SpriteEffects.None, 0);
            else
                spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, scale, SpriteEffects.FlipVertically, 0);
        }
    }
}
