using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Zirox
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D Backg;
        Texture2D _CharTexture;
        Character Zirox;

        List<ICollide> collideObjecten;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1800;
            graphics.PreferredBackBufferHeight = 893;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here 
            Backg = Content.Load<Texture2D>("BGpng/BG/BG");
            
            _CharTexture = Content.Load<Texture2D>("Charpng/Idle (1)");
            Zirox = new Character(_CharTexture, new Vector2(200, 200));
            Zirox._beweging = new BewegingKeys();

            collideObjecten = new List<ICollide>();
            collideObjecten.Add(Zirox);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        private bool CheckCollision()
        {
            for(int i = 0; i < collideObjecten.Count; i++)
             {
                 for(int j=i+1; j< collideObjecten.Count; j++)
                 {
                     if (collideObjecten[i].GetCollisionRectangle().Intersects(collideObjecten[j].GetCollisionRectangle()))
                     {
                         return true;
                     }
                 }
             }
            return false;
        }

        // <summary>
        // Allows the game to run logic such as updating the world,
        // checking for collisions, gathering input, and playing audio.
        // </summary>
        // <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Zirox.Update(gameTime);

            if (CheckCollision())
            {
                System.Console.WriteLine("AAAAA");
            }

            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here.
            spriteBatch.Begin();
            spriteBatch.Draw(Backg, Vector2.Zero, Color.White);
            Zirox.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
