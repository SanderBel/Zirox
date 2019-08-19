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
    public class MenuScreen : BaseScreen
    {
        Button btnPLay;
        Button btnQuit;
        Texture2D btnPlayTexture;
        Texture2D btnQuitTexture;
        Texture2D menuBackground;
        Texture2D welcomeSign;

        List<Control> Controls = new List<Control>();

        MouseState presentMouse;

        public MenuScreen(Game1 game)
        {
            Content = game.Content;
            int centreX = (int)game.screen.X / 2;
            int centreY = (int)game.screen.Y / 2;

            btnPlayTexture = Content.Load<Texture2D>("ButtonsPlay");
            btnQuitTexture = Content.Load<Texture2D>("ButtonsExit");
            menuBackground = Content.Load<Texture2D>("menuBackground");
            welcomeSign = Content.Load<Texture2D>("welcomeSign");

            btnPLay = new Button(btnPlayTexture, new Rectangle(centreX - 190, centreY-45, 50, 50));
            btnQuit = new Button(btnQuitTexture,  new Rectangle(centreX + 190, centreY-45, 50, 50));

            Controls.Add(btnPLay);
            Controls.Add(btnQuit);
        }

        public override void Update(Game1 game, GameTime gameTime, float newPoints)
        {
            presentMouse = Mouse.GetState();

            foreach (Control control in Controls)
            {
                control.Update(presentMouse);
            }

            if (btnPLay.IsLeftClicked)
            {
                this.IsActive = false;
                game.GameScreen.IsActive = true;
            }
            if (btnQuit.IsLeftClicked)
            {
                this.IsActive = false;
                game.Exit();
                //game.QuitScreen.IsActive = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(menuBackground, new Rectangle(0, 0, 1014, 768), Color.White);
            spriteBatch.Draw(welcomeSign, new Rectangle(310, 100, 500, 250), Color.White);
            foreach (Control control in Controls)
            {
                control.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        
    }
}
