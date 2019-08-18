using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox.Screens
{
    public class GameScreen : BaseScreen
    {
        private Character Zirox;
        private List<Enemy> enemies = new List<Enemy>();

        

        Level level1;
        //GraphicsDeviceManager graphics;
        public Vector2 screen = new Vector2(1014, 768);

        public GameScreen(Game1 game)
        {            
            Content = game.Content;

            Zirox = new Character();
            Zirox._beweging = new BewegingPijltjes();
            Zirox.Load(Content);
            level1 = new Level();
        }

        public override void LoadContent()
        {
            level1 = new Level();
            Zirox = new Character();

            //Texture, Vector(start PositionX, start PositionY, Distance it will walk to the left)
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(600, 200), 200));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(300, 200), 200));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(900, 200), 200));

            //

            Zirox._beweging = new BewegingPijltjes();

            Zirox.Load(Content);
            //Texture, Vector(start PositionX, start PositionY, Distance it will walk to the left)
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(600, 200), 200));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(300, 200), 200));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(900, 200), 200));
            enemies.Add(new Enemy(Content.Load<Texture2D>("EnemySheetWalking"), new Vector2(-500, 200), 10));

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
                { 0,0,0,7,9,0,0,7,8,9,0,0,0,0,0,0,0,0,5,4,8,8,8,8,8,8,8,8,8,8,8,8,8,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,12,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,4,8,8,8,8,8,8,8,8,8,8,8,8,8,8,6,1,2,2,2,3,9,9,9,9,9,9,9,1,2,2,1,3 },
                { 1,2,2,2,2,3,10,10,1,3,9,1,3,9,9,9,1,4,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,10,10,10,10,10,10,10,8,8,8,8,8 },
            }, 64);
        }

        public override void Update(Game1 game, GameTime gameTime)
        {
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
            
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            Zirox.Draw(spriteBatch);
            level1.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
