using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox.Screens
{
    public abstract class BaseScreen
    {
        public bool IsActive { get; set; }

        protected ContentManager Content;

        public abstract void Update(Game1 game, GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void LoadContent();
    }
}
