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
        Texture2D ZiroxTexture;
        Texture2D textureSlopeEndL;
        Texture2D textureSlopeL;
        Texture2D textureSlopeEndR;
        Texture2D textureSlopeR;
        Texture2D textureLeft;
        Texture2D textureMid;
        Texture2D textureRight;
        Texture2D textureWater;
        Texture2D textureBush;
        Texture2D textureDirt;
        Character Zirox;

        Vector2 screen = new Vector2(1014, 768);

        List<Tiles> TilesList = new List<Tiles>();
        List<ICollide> collideObjecten = new List<ICollide>();
        Level level;

        Camera camera;
        Vector2 camPos = new Vector2();
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = (int)screen.X;
            graphics.PreferredBackBufferHeight = (int)screen.Y;
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
            camera = new Camera(GraphicsDevice.Viewport);
            level = new Level();
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
            Backg = Content.Load<Texture2D>("finalDay");
            //textureDirt = Content.Load<Texture2D>("Dirt");
            //textureSlopeEndL = Content.Load<Texture2D>("SlopeEndL");
            //textureSlopeL = Content.Load<Texture2D>("SlopeL");
            //textureSlopeEndR = Content.Load<Texture2D>("SlopeEndR");
            //textureSlopeR = Content.Load<Texture2D>("SlopeR");
            //textureLeft = Content.Load<Texture2D>("Left");
            //textureMid = Content.Load<Texture2D>("Mid");
            //textureRight = Content.Load<Texture2D>("Right");
            //textureWater = Content.Load<Texture2D>("Water");
            //textureBush = Content.Load<Texture2D>("AtmnBush");

            ZiroxTexture = Content.Load<Texture2D>("CharSheet");
            Zirox = new Character(ZiroxTexture, new Vector2(64, 64));
            Zirox._beweging = new BewegingPijltjes();


            //collideObjecten = new List<ICollide>();
            collideObjecten.Add(Zirox);

            Tiles.Content = Content;
            /*
             * 1 = Left Tile
             * 2 = Middle Tile
             * 3 = Right Tile
             * 4 = Slope End Left
             * 5 = Slope Left
             * 6 = Slope End Right
             * 7 = Slope Right
             * 8 = Dirt
             * 9 = Water
             * 10 = Water Filler
             * 11 = Next Level Sign
             * 12 = End Sign
             */
            level.Generate(new int[,]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,4,8,8,8,8,7,0,0,0,0,0,0,0,0,5,2,7,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,3,0,0,0,5,2,2,2,2,4,4,8,8,8,8,8,8,7,0,0,0,0,0,0,1,4,8,8,6,3,0,0,1,2,3,0 },
                { 0,0,0,1,3,0,0,1,2,3,0,0,0,0,0,0,0,0,5,4,8,8,8,8,8,8,8,8,8,8,8,8,8,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,4,8,8,8,8,8,8,8,8,8,8,8,8,8,8,6,1,2,2,2,3,9,9,9,9,9,9,9,1,2,2,1,3 },
                { 1,2,2,2,2,3,9,9,1,3,9,1,3,9,9,9,1,4,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,10,10,10,10,10,10,10,8,8,8,8,8 },
            }, 64);
        

            //level = new Level(TilesList);
            //level.textureBush = textureBush;
            //level.textureLeft = textureLeft;
            //level.textureMid = textureMid;
            //level.textureRight = textureRight;
            //level.textureSlopeEndL = textureSlopeEndL;
            //level.textureSlopeEndR = textureSlopeEndR;
            //level.textureSlopeL = textureSlopeL;
            //level.textureSlopeR = textureSlopeR;
            //level.textureWater = textureWater;
            //level.CreateWorld();

            //foreach (Tiles tiles in TilesList)
            //    collideObjecten.Add(tiles);
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
                return false;
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
            if (Zirox.IsMoving)
                camPos += Zirox.VelocityX;

            Zirox.Update(gameTime);

            if (CheckCollision() && Zirox.VelocityY.Y<0)
            {
                System.Console.WriteLine("AAAAA");
                Zirox.VelocityY.Y = 0f;
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

            var viewMatrix = camera.GetViewMatrix();
            camera.Position = camPos+new Vector2(10,0);
            // TODO: Add your drawing code here.
            spriteBatch.Begin(transformMatrix: viewMatrix);

            spriteBatch.Draw(Backg, camPos, Color.White);

            Zirox.Draw(spriteBatch);

            level.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
