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
        Character Zirox;

        Vector2 screen = new Vector2(1014, 768);

        //List<Tiles> TilesList = new List<Tiles>();
        //List<ICollide> collideObjecten = new List<ICollide>();
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
            Zirox = new Character();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);            
            Backg = Content.Load<Texture2D>("finalDay");
            Zirox._beweging = new BewegingPijltjes();
            Zirox.Load(Content);

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

        //private bool CheckCollision()
        //{
        //    for(int i = 0; i < collideObjecten.Count; i++)
        //     {
        //         for(int j=i+1; j< collideObjecten.Count; j++)
        //         {
        //             if (collideObjecten[i].GetCollisionRectangle().Intersects(collideObjecten[j].GetCollisionRectangle()))
        //             {
        //                 return true;
        //             }
        //         }
        //        return false;
        //    }
        //    return false;
        //}

        // <summary>
        // Allows the game to run logic such as updating the world,
        // checking for collisions, gathering input, and playing audio.
        // </summary>
        // <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Zirox.Update(gameTime);
            foreach (CollisionTiles tile in level.CollisionTiles)
                Zirox.Collision(tile.Rectangle, level.Width, level.Height);

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
