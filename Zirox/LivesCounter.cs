using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    public class LivesCounter
    {
        protected SpriteFont font;

        protected ContentManager Content;
        protected Texture2D texture;
        private Vector2 position = Vector2.Zero;
        private Rectangle rectangle;
        public float livesLeft;
        protected string lives = "";

        protected string text = "";
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public LivesCounter(ContentManager Content, string newText, Rectangle newRectangle)
        {
            text = newText;
            texture = Content.Load<Texture2D>("LivesCounter");
            font = Content.Load<SpriteFont>("ComicSans");
            rectangle = newRectangle;
            livesLeft = 2;
            lives = livesLeft.ToString();
        }

        public float LivesLeft
        {
            get { return livesLeft; }
        }

        public void Update()
        {
            livesLeft--;
            lives = livesLeft.ToString();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);

            if(text.Length > 0 && font != null)
            {
                float x = font.MeasureString(text).X / 2;
                float y = font.MeasureString(text).Y / 2;

                Vector2 fPosition = new Vector2((rectangle.X + (rectangle.Width / 2)) - x, (rectangle.Y + (rectangle.Height / 2)) - y);
                spriteBatch.DrawString(font, text+lives, fPosition, Color.White);
            }
        }
    }
}
