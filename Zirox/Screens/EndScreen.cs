using Microsoft.Xna.Framework;
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
    public class EndScreen : BaseScreen
    {

        SpriteFont font;
        Texture2D farewellSign;

        public EndScreen(Game1 game)
        {
            Content = game.Content;
            font = Content.Load<SpriteFont>("ComicSans");
            farewellSign = Content.Load<Texture2D>("FarewellSign");
        }

        public override void Update(Game1 game, GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(farewellSign, new Rectangle(32, 159, 950, 450), Color.White);
            spriteBatch.End();
        }


    }
}
