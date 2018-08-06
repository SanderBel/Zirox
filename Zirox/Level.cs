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
    public class Level
    {
        public Texture2D textureLeft;
        public Texture2D textureMid;
        public Texture2D textureRight;
        public Texture2D texturePlatLeft;
        public Texture2D texturePlatMid;
        public Texture2D texturePlatRight;
        public Texture2D textureSea;
        public Level()
        {

        }
        //blok is 128x128
        public byte[,] tileArray = new byte[,]
        {
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 4,5,6,0,0,0,0,0,4,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,4,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 4,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,4,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 1,2,2,2,2,3,7,7,1,3,7,1,3,7,7,7,1,2,2,3,7,1,2,2,2,2,2,2,3,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,1,2,2,2,2,3 },
        };

        public Object[,] objectArray = new Object[7, 50];

        public void CreateWorld()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    if (tileArray[x, y] == 1)
                        objectArray[x, y] = new Object(textureLeft, new Vector2(y * 128, x * 128));
                    else if (tileArray[x, y] == 2)
                        objectArray[x, y] = new Object(textureMid, new Vector2(y * 128, x * 128));
                    else if (tileArray[x, y] == 3)
                        objectArray[x, y] = new Object(textureRight, new Vector2(y * 128, x * 128));
                    else if (tileArray[x, y] == 4)
                        objectArray[x, y] = new Object(texturePlatLeft, new Vector2(y * 128, x * 128));
                    else if (tileArray[x, y] == 5)
                        objectArray[x, y] = new Object(texturePlatMid, new Vector2(y * 128, x * 128));
                    else if (tileArray[x, y] == 6)
                        objectArray[x, y] = new Object(texturePlatRight, new Vector2(y * 128, x * 128));
                    else if (tileArray[x, y] == 7)
                        objectArray[x, y] = new Object(textureSea, new Vector2(y * 128, x * 128));
                }
            }
        }

        public void DrawLevel(SpriteBatch spritebatch)
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    if (objectArray[x, y] != null)
                    {
                        objectArray[x, y].Draw(spritebatch);
                    }

                }
            }
        }
    }
}
