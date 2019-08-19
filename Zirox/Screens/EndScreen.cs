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
        Texture2D btnPlayTexture;
        float points;
        string pointsString;

        SpriteFont font;

        public EndScreen(Game1 game)
        {
            Content = game.Content;
            font = Content.Load<SpriteFont>("ComicSans");
        }

        public override void Update(Game1 game, GameTime gameTime, float newPoints)
        {
            points = newPoints;
            pointsString = points.ToString();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font,pointsString,new Vector2(450,450),Color.AliceBlue);

            spriteBatch.End();
        }


    }
}
