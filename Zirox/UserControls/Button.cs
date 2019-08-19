using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox.UserControls
{
    public class Button : Control
    {
        public Button(Texture2D newTexture,  Rectangle newRectangle)
        {
            texture = newTexture;
            Rectangle = newRectangle;

            IsVisible = true;
            IsEnabled = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                spriteBatch.Draw(texture, Rectangle, Color.White);
            }
        }
    }
}
