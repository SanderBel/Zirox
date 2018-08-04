using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    public abstract class Beweging
    {
        public bool left { get; set; }
        public bool right { get; set; }
        public bool up { get; set; }
        public bool down { get; set; }
        public abstract void Update();
    }

    public class BewegingKeys: Beweging
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.A))
            {
                left = true;
            }
            if (stateKey.IsKeyUp(Keys.A))
            {
                left = false;
            }

            if (stateKey.IsKeyDown(Keys.D))
            {
                right = true;
            }
            if (stateKey.IsKeyUp(Keys.D))
            {
                right = false;
            }
            if (stateKey.IsKeyDown(Keys.W))
            {
                up = true;
            }
            if (stateKey.IsKeyUp(Keys.W))
            {
                up = false;
            }

            if (stateKey.IsKeyDown(Keys.S))
            {
                down = true;
            }
            if (stateKey.IsKeyUp(Keys.S))
            {
                down = false;
            }
        }
    }

    public class BewegingPijltjes : Beweging
    {
        public override void Update()
        {

            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.Left))
            {
                left = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                left = false;
            }

            if (stateKey.IsKeyDown(Keys.Right))
            {
                right = true;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                right = false;
            }
            if (stateKey.IsKeyDown(Keys.Up))
            {
                up = true;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                up = false;
            }

            if (stateKey.IsKeyDown(Keys.Down))
            {
                down = true;
            }
            if (stateKey.IsKeyUp(Keys.Down))
            {
                down = false;
            }
        }
    }
}
