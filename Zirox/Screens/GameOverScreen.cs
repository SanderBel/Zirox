using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zirox.UserControls;

namespace Zirox.Screens
{
    public class GameOverScreen : BaseScreen
    {
        protected SpriteFont font;
        protected Texture2D texture;
        private Vector2 position = Vector2.Zero;

        public GameOverScreen(Game1 game)
        {
            Content = game.Content;
            texture = Content.Load<Texture2D>("GameOver");
        }

        public override void Update(Game1 game, GameTime gameTime, float newPoints)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, new Rectangle(0,0,1014,768), Color.White);
            spriteBatch.End();
        }
    }
}
