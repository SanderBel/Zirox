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
        public LevelScreen1 LevelScreen1;
        public MenuScreen MenuScreen;
        public LevelScreen2 LevelScreen2;
        public EndScreen EndScreen;
        public GameOverScreen GameOverScreen;

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

            LevelScreen1 = new LevelScreen1(this);
            LevelScreen2 = new LevelScreen2(this);
            EndScreen = new EndScreen(this);
            GameOverScreen = new GameOverScreen(this);

            screens.Add(LevelScreen1);
            screens.Add(LevelScreen2);
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
                LevelScreen1.IsActive = false;
                LevelScreen2.IsActive = false;
                MenuScreen.IsActive = true;
                EndScreen.IsActive = false;
                GameOverScreen.IsActive = false;
            }
            else if (LevelScreen2.XPositionZirox >= 6400)
            {
                LevelScreen1.IsActive = true;
                LevelScreen2.IsActive = false;
                MenuScreen.IsActive = false;
                EndScreen.IsActive = false;
                GameOverScreen.IsActive = false;
            }
            else if (LevelScreen1.XPositionZirox >= 6400)
            {
                LevelScreen1.IsActive = false;
                LevelScreen2.IsActive = false;
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
                    s.Update(this, gameTime);
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
