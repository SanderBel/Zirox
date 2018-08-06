using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    public class Animation
    {
        private List<AnimationFrame> frames;
        public AnimationFrame CurrentFrame { get; set; }
        public int AantalBewegingenPerSeconde { get; set; }

        private int counter = 0;
        private double x = 0;
        public double offset { get; set; }

        private int _totalWidth = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
            AantalBewegingenPerSeconde = 1;
        }
        public void AddFrame(Texture2D texture)
        {
            AnimationFrame newFrame = new AnimationFrame()
            {
                SourceTexture = texture,
                //Duration = duration
            };

            frames.Add(newFrame);
            CurrentFrame = frames[0];
            offset = CurrentFrame.SourceTexture.Width;
            foreach (AnimationFrame f in frames)
                _totalWidth += f.SourceTexture.Width;
        }
      
        public void Update(GameTime gameTime)
        {
            double temp = CurrentFrame.SourceTexture.Width * ((double)gameTime.ElapsedGameTime.Milliseconds / 1000);

            x += temp;
            if (x >= CurrentFrame.SourceTexture.Width / AantalBewegingenPerSeconde)
            {
                Console.WriteLine(x);
                x = 0;
                counter++;
                if (counter >= frames.Count)
                    counter = 0;
                CurrentFrame = frames[counter];
                offset += CurrentFrame.SourceTexture.Width;
            }
            if (offset >= _totalWidth)
                offset = 0;            
        }
    }
}
