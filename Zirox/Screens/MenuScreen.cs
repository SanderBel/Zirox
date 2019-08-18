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

        List<Control> Controls = new List<Control>();

        MouseState presentMouse;

        public MenuScreen(Game1 game)
        {
            int centre = (int)game.screen.X / 2;

            btnPLay = new Button(game.Content, "Play", new Rectangle(centre - 50, 100, 100, 35));
            btnQuit = new Button(game.Content, "Quit", new Rectangle(centre - 50, 150, 100, 35));

            Controls.Add(btnPLay);
            Controls.Add(btnQuit);
        }

        public override void LoadContent()
        {
        }

        public override void Update(Game1 game, GameTime gameTime)
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
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (Control control in Controls)
            {
                control.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        
    }
}
