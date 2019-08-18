using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    class Bullet : BaseSprite
    {
        public Bullet(Hero hero, Texture2D newTexture, float newSpeed)
        {
            minSpeed = 0;
            maxSpeed = 20;

            position = hero.Position;

            texture = newTexture;
            Speed = hero.Speed + newSpeed;
        }

        public void Update()
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);

            velocity.X = Speed;
        }
    }
}
