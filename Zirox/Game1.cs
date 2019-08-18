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

        Vector2 screen = new Vector2(1014, 768);
        Texture2D Backg;
        Camera camera;

        public List<Enemy> enemies = new List<Enemy>();
        Character Zirox;
        Level level1;
        Level level2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = (int)screen.X;
            graphics.PreferredBackBufferHeight = (int)screen.Y;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            
            level1 = new Level();
            level2 = new Level();
            Zirox = new Character();
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(GraphicsDevice.Viewport);
            
            Zirox._beweging = new BewegingPijltjes();
            
            Zirox.Load(Content);
            //Texture, Vector(start PositionX, start PositionY, Distance it will walk to the left)
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(600, 200), 200));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(300, 200), 200));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(900, 200), 200));

            Tiles.Content = Content;
            Backg = Content.Load<Texture2D>("finalDay");
            /*
             * 1 = Left Tile
             * 2 = Middle Tile
             * 3 = Right Tile
             * 4 = Dirt Left
             * 5 = Dirt Middle
             * 6 = Dirt Right
             * 7 = Island Left
             * 8 = Island Middle
             * 9 = Island Right
             * 10 = Water
             * 11 = Water Fill
             * 12 = Next Level
             * 13 = End
             */
            level1.Generate(new int[,]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,7,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,7,8,8,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,4,8,8,8,8,7,0,0,0,0,0,0,0,0,5,2,7,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,3,0,0,0,5,2,2,2,2,4,4,8,8,8,8,8,8,7,0,0,0,0,0,0,1,4,8,8,6,3,0,0,1,2,3,0 },
                { 0,0,0,7,9,0,0,7,8,9,0,0,0,0,0,0,0,0,5,4,8,8,8,8,8,8,8,8,8,8,8,8,8,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,4,8,8,8,8,8,8,8,8,8,8,8,8,8,8,6,1,2,2,2,3,9,9,9,9,9,9,9,1,2,2,1,3 },
                { 1,2,2,2,2,3,10,10,1,3,9,1,3,9,9,9,1,4,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,10,10,10,10,10,10,10,8,8,8,8,8 },
            }, 64);
            //level2.Generate(new int[,]
            //{
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,4,8,8,8,8,7,0,0,0,0,0,0,0,0,5,2,7,0,0,0,0,0,0,0,0 },
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,3,0,0,0,5,2,2,2,2,4,4,8,8,8,8,8,8,7,0,0,0,0,0,0,1,4,8,8,6,3,0,0,1,2,3,0 },
            //    { 0,0,0,1,3,0,0,1,2,3,0,0,0,0,0,0,0,0,5,4,8,8,8,8,8,8,8,8,8,8,8,8,8,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0 },
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,4,8,8,8,8,8,8,8,8,8,8,8,8,8,8,6,1,2,2,2,3,9,9,9,9,9,9,9,1,2,2,1,3 },
            //    { 1,2,2,2,2,3,9,9,1,3,9,1,3,9,9,9,1,4,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,10,10,10,10,10,10,10,8,8,8,8,8 },
            //}, 32);
        }
        
        protected override void UnloadContent()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Zirox.Update(enemies, gameTime);

            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
                Zirox.Collision(enemy.Rectangle, level1.Width, level1.Height);
            }
            //enemies.Update(gameTime);
            foreach (CollisionTiles tile in level1.CollisionTiles)
            {
                Zirox.Collision(tile.Rectangle, level1.Width, level1.Height);
                camera.Update(Zirox.Position, level1.Width, level1.Height);
                foreach(Enemy enemy in enemies)
                {
                    enemy.Collision(tile.Rectangle, level1.Width, level1.Height);
                }
                //enemy1.Collision(tile.Rectangle, level1.Width, level1.Height);
            }
            //Zirox.Collision(enemy1.Rectangle, level1.Width, level1.Height);
            //foreach (CollisionTiles tile in level2.CollisionTiles)
            //{
            //    Zirox.Collision(tile.Rectangle, level2.Width, level2.Height);
            //    camera.Update(Zirox.Position, level2.Width, level2.Height);
            //}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred,
                              BlendState.AlphaBlend,
                              null,null,null,null,
                              camera.Transform);
            spriteBatch.Draw(Backg,camera.BackPosition,Color.White);
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            //enemy1.Draw(spriteBatch);
            Zirox.Draw(spriteBatch);
            level1.Draw(spriteBatch);
            level2.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
