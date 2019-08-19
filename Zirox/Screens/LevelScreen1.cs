using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox.Screens
{
    public class LevelScreen1 : BaseScreen
    {
        private Character Zirox;
        private List<Enemy> enemies = new List<Enemy>();
        private List<Coin> coins = new List<Coin>();

        Texture2D Backg;
        Level level1;
        SpriteBatch spriteBatch;
        public Vector2 screen = new Vector2(1014, 768);
        Camera camera;
        float points;

        public float XPositionZirox
        {
            get { return Zirox.Position.X; }
        }

        public LevelScreen1(Game1 game)
        {            
            Content = game.Content;
            int centre = (int)screen.X / 2;
            camera = new Camera(game.GraphicsDevice.Viewport);
            spriteBatch = new SpriteBatch(game.GraphicsDevice);

            Zirox = new Character();
            Zirox._beweging = new BewegingPijltjes();
            Zirox.Load(Content);
            level1 = new Level();
            Backg = Content.Load<Texture2D>("finalNight");
            Tiles.Content = Content;

            coins.ForEach(c => c.Load(Content));

            Zirox._beweging = new BewegingPijltjes();
            //Texture, Vector(start PositionX, start PositionY, Distance it will walk to the left)
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(320, 512), 192));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(640, 512), 256));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(838, 128), 128));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(1152, 256), 320));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(1792, 256), 128));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(2560, 256), 256));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(2688, 256), 128));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(3328, 0), 320));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(3520, 256), 192));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(3712, 256), 320));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(3840, 256), 640));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(4480, 256), 384));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(4608, 256), 512));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(4800, 64), 64));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(5952, 64), 128));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(5760, 64), 960));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(5632, 64), 832));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(5440, 64), 960));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(5312, 64), 576));

            coins.Add(new Coin(Content.Load<Texture2D>("Coin"), new Vector2(300,400)));

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
                //0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,9,0,0,0,0,0,0,0,0,0,10,0,0
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,8,8,8,8,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,8,8,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,7,8,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,8,8,9,0,0,0,0,0,0,0,0,7,9,0,0,0,0,0,0,0,0,0,7,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,8,8,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,1,2,8,8,8,2,3,0,0,0,0,0,0,1,5,5,5,5,5,6,0,0,0,0,0,0,0,0,1,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,8,8,8,8,8,8,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,4,6,0,0,0,4,5,2,2,2,2,2,2,5,5,5,5,5,5,5,3,0,0,0,0,0,0,7,5,5,5,8,9,0,0,7,8,9,0,0,0,0,0,0,0,0,0,0,0,0,0,4,6,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,5,5,5,8,9,0,0,7,8,9,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,1,5,6,0,0,0,4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,5,6,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,4,5,6,1,1,1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,0,0,0,0,0,0,0,0,0,0,0,4,5,6,1,1,1,1,1,1,5,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3 },
                { 1,2,2,2,2,2,2,2,2,2,2,5,5,6,11,11,11,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1,2,2,2,2,2,2,2,2,2,2,5,5,6,11,11,11,11,11,11,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5 },
            }, 64);
        }

        public override void Update(Game1 game, GameTime gameTime)
        {
            camera.Update(Zirox.Position, level1.Width, level1.Height);
            Zirox.Update(enemies, gameTime);

            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
                Zirox.Collision(enemy.Rectangle, level1.Width, level1.Height);
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Rectangle.Intersects(Zirox.Rectangle))
                {
                    //ZIROX DIES
                    this.IsActive = false;
                    game.GameOverScreen.IsActive = true;
                    Zirox.Update(enemies, gameTime);
                }
            }

            coins.ForEach(c => c.Update(gameTime));
            for (int l = 0; l < coins.Count; l++)
            {
                if (coins[l].Rectangle.Intersects(Zirox.Rectangle))
                {
                    points += 100; 
                    coins.RemoveAt(l);
                    l--;
                }
            }

            foreach (CollisionTiles tile in level1.CollisionTiles)
            {
                Zirox.Collision(tile.Rectangle, level1.Width, level1.Height);
                
                foreach (Enemy enemy in enemies)
                {
                    enemy.Collision(tile.Rectangle, level1.Width, level1.Height);
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
            level1.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
