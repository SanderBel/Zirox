using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    class Level
    {
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();

        public List<CollisionTiles> CollisionTiles
        {
            get { return collisionTiles; }
        }

        private int width, height;
        public int Width
        {
            get { return width; }
        }
        
        public int Height
        {
            get { return height; }
        }

        public Level() { }

        public void Generate(int[,] level, int size)
        {
            for(int x=0; x < level.GetLength(1); x++)
                for(int y=0; y < level.GetLength(0); y++)
                {
                    int number = level[y, x];

                    if (number > 0)
                        collisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));

                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in collisionTiles)
                tile.Draw(spriteBatch);
        }

    }

    //public class Level
    //{
    //    public Texture2D textureSlopeEndL;
    //    public Texture2D textureSlopeL;
    //    public Texture2D textureSlopeEndR;
    //    public Texture2D textureSlopeR;
    //    public Texture2D textureLeft;
    //    public Texture2D textureMid;
    //    public Texture2D textureRight;
    //    public Texture2D textureWater;
    //    public Texture2D textureBush;

    //    private Tiles TileSlopeEndL;
    //    private Tiles TileSlopeL;
    //    private Tiles TileSlopeEndR;
    //    private Tiles TileSlopeR;
    //    private Tiles TileLeft;
    //    private Tiles TileMid;
    //    private Tiles TileRight;
    //    private Tiles TileWater;
    //    private Tiles TileBush;
    //    List<Tiles> TilesList = new List<Tiles>();

    //    public Level(List<Tiles> TilesList)
    //    {
    //        this.TilesList = TilesList;
    //    }
    //    //blok is 128x128
    //    public byte[,] tileArray = new byte[,]
    //    {
    //        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
    //        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
    //        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
    //        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
    //        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
    //        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
    //        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
    //        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
    //        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
    //        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
    //        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
    //        { 1,1,1,1,1,3,9,9,1,3,9,1,3,9,9,9,1,2,2,2,3,1,2,2,2,2,2,2,3,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,2,2,2,2,3 },
    //    };

    //    public Tiles[,] objectArray = new Tiles[12, 50];

    //    public void CreateWorld()
    //    {
    //        for (int x = 0; x < 12; x++)
    //        {
    //            for (int y = 0; y < 50; y++)
    //            {
    //                if (tileArray[x, y] == 1)
    //                    objectArray[x, y] = new Tiles(textureLeft, new Vector2(y * 64, x * 64));
    //                else if (tileArray[x, y] == 2)
    //                    objectArray[x, y] = new Tiles(textureMid, new Vector2(y * 64, x * 64));
    //                else if (tileArray[x, y] == 3)
    //                    objectArray[x, y] = new Tiles(textureRight, new Vector2(y * 64, x * 64));
    //                else if (tileArray[x, y] == 4)
    //                    objectArray[x, y] = new Tiles(textureSlopeEndL, new Vector2(y * 64, x * 64));
    //                else if (tileArray[x, y] == 5)
    //                    objectArray[x, y] = new Tiles(textureSlopeL, new Vector2(y * 64, x * 64));
    //                else if (tileArray[x, y] == 6)
    //                    objectArray[x, y] = new Tiles(textureSlopeEndR, new Vector2(y * 64, x * 64));
    //                else if (tileArray[x, y] == 7)
    //                    objectArray[x, y] = new Tiles(textureSlopeR, new Vector2(y * 64, x * 64));
    //                else if (tileArray[x, y] == 8)
    //                    objectArray[x, y] = new Tiles(textureBush, new Vector2(y * 64, x * 64));
    //                else if (tileArray[x, y] == 9)
    //                    objectArray[x, y] = new Tiles(textureWater, new Vector2(y * 64, x * 64));
    //            }
    //        }
    //    }

    //    public void DrawLevel(SpriteBatch spritebatch)
    //    {
    //        for (int x = 0; x < 12; x++)
    //        {
    //            for (int y = 0; y < 50; y++)
    //            {
    //                if (objectArray[x, y] != null)
    //                {
    //                    objectArray[x, y].Draw(spritebatch);
    //                }

    //            }
    //        }
    //    }
    //}
}
