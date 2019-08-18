using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Zirox.Screens;

namespace Zirox
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public enum GameState
        {
            MainMenu,
            LevelSelect,
            Level1,
            Level2,
            Died,
            QuitGame
        }
        GameState CurrentState = GameState.MainMenu;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Vector2 screen = new Vector2(1014, 768);
        Texture2D Backg;
        Camera camera;

        //Screens
        List<BaseScreen> Screens = new List<BaseScreen>();
        public GameScreen GameScreen;
        public MenuScreen MenuScreen;

        public Game1()
        {
            
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = (int)screen.X;
            graphics.PreferredBackBufferHeight = (int)screen.Y;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(GraphicsDevice.Viewport);
            Backg = Content.Load<Texture2D>("finalDay");

            MenuScreen = new MenuScreen(this);
            MenuScreen.IsActive = true;

            GameScreen = new GameScreen(this);

            Screens.Add(GameScreen);
            Screens.Add(MenuScreen);
            
        }
        
        protected override void UnloadContent()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //camera.Update(Zirox.Position, level1.Width, level1.Height);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred,
                              BlendState.AlphaBlend,
                              null, null, null, null,
                              camera.Transform);
            spriteBatch.Draw(Backg, camera.BackPosition, Color.White);


            base.Draw(gameTime);
        }
    }
}
