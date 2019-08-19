using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox.Screens
{
    public class LevelScreen2: BaseScreen
    {
        private Character Zirox;
        private List<Enemy> enemies = new List<Enemy>();
        private List<Coin> coins = new List<Coin>();


        Texture2D Backg;
        Level level2;
        SpriteBatch spriteBatch;
        //GraphicsDeviceManager graphics;
        public Vector2 screen = new Vector2(1014, 768);

        Camera camera;

        public float XPositionZirox
        {
            get { return Zirox.Position.X; }
        }

        public LevelScreen2(Game1 game)
        {
            Content = game.Content;

            camera = new Camera(game.GraphicsDevice.Viewport);
            spriteBatch = new SpriteBatch(game.GraphicsDevice);

            Zirox = new Character();
            Zirox._beweging = new BewegingPijltjes();
            Zirox.Load(Content);
            level2 = new Level();
            Backg = Content.Load<Texture2D>("finalNight");

            coins.ForEach(c => c.Load(Content));

            Zirox._beweging = new BewegingPijltjes();
            //Texture, Vector(start PositionX, start PositionY, Distance it will walk to the left)
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(600, 200), 200));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(300, 200), 200));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(900, 200), 200));

            coins.Add(new Coin(Content.Load<Texture2D>("Coin"), new Vector2(300, 400)));

            Tiles.Content = Content;

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
            level2.Generate(new int[,]
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
                { 0,0,0,7,9,0,0,7,8,9,0,0,0,0,0,0,0,0,5,4,8,8,8,8,8,8,8,8,8,8,8,8,8,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,12,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,4,8,8,8,8,8,8,8,8,8,8,8,8,8,8,6,1,2,2,2,3,9,9,9,9,9,9,9,1,2,2,1,3 },
                { 1,2,2,2,2,3,10,10,1,3,9,1,3,9,9,9,1,4,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,10,10,10,10,10,10,10,8,8,8,8,8 },
            }, 64);
        }

        public override void Update(Game1 game, GameTime gameTime)
        {
            camera.Update(Zirox.Position, level2.Width, level2.Height);
            Zirox.Update(enemies, gameTime);

            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
                Zirox.Collision(enemy.Rectangle, level2.Width, level2.Height);
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Rectangle.Intersects(Zirox.Rectangle))
                {
                    //ZIROX DIES
                }
            }

            coins.ForEach(c => c.Update(gameTime));
            for (int l = 0; l < coins.Count; l++)
            {
                if (coins[l].Rectangle.Intersects(Zirox.Rectangle))
                {
                    coins.RemoveAt(l);
                    l--;
                }
            }

            foreach (CollisionTiles tile in level2.CollisionTiles)
            {
                Zirox.Collision(tile.Rectangle, level2.Width, level2.Height);

                foreach (Enemy enemy in enemies)
                {
                    enemy.Collision(tile.Rectangle, level2.Width, level2.Height);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred,
                              BlendState.AlphaBlend,
                              null, null, null, null,
                               camera.Transform);
            spriteBatch.Draw(Backg, camera.BackPosition, Color.White);
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (Coin coin in coins)
            {
                coin.Draw(spriteBatch);
            }

            Zirox.Draw(spriteBatch);
            level2.Draw(spriteBatch);
            spriteBatch.End();

            //base.Draw(gameTime);
        }
    }
}
