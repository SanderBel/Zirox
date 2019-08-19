using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Zirox.Screens;

namespace Zirox
{
    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Vector2 screen = new Vector2(1014, 768);

        //Screens
        List<BaseScreen> screens = new List<BaseScreen>();
        public LevelScreen1 GameScreen;
        public MenuScreen MenuScreen;
        public LevelScreen2 GameScreen2;
        public EndScreen EndScreen;
        public GameOverScreen GameOverScreen;
        Character character;
        float points;

        public Game1()
        {            
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = (int)screen.X;
            graphics.PreferredBackBufferHeight = (int)screen.Y;
            graphics.ApplyChanges();
        }
        
        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            MenuScreen = new MenuScreen(this);
            MenuScreen.IsActive = true;

            GameScreen = new LevelScreen1(this);
            GameScreen2 = new LevelScreen2(this);
            EndScreen = new EndScreen(this);
            GameOverScreen = new GameOverScreen(this);

            screens.Add(GameScreen);
            screens.Add(GameScreen2);
            screens.Add(MenuScreen);
            screens.Add(EndScreen);
            screens.Add(GameOverScreen);
        }
        
        protected override void UnloadContent()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                GameScreen.IsActive = false;
                GameScreen2.IsActive = false;
                MenuScreen.IsActive = true;
                EndScreen.IsActive = false;
                GameOverScreen.IsActive = false;
            }
            else if (GameScreen.XPositionZirox >= 600)
            {
                GameScreen.IsActive = false;
                GameScreen2.IsActive = true;
                MenuScreen.IsActive = false;
                EndScreen.IsActive = false;
                GameOverScreen.IsActive = false;
            }
            else if (GameScreen2.XPositionZirox >= 200)
            {
                GameScreen.IsActive = false;
                GameScreen2.IsActive = false;
                MenuScreen.IsActive = false;
                EndScreen.IsActive = true;
                GameOverScreen.IsActive = false;
            }
            else if (GameOverScreen.IsActive == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }

            screens.ForEach(s =>
            {
                if (s.IsActive)
                    s.Update(this, gameTime, points);
            });
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            screens.ForEach(s =>
            {
                if (s.IsActive)
                    s.Draw(spriteBatch);
            });


            base.Draw(gameTime);
        }
    }
}
