using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zirox
{
    public class Camera
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }

        private Vector2 centre;
        private Viewport viewport;
        public Vector2 BackPosition;

        public Camera(Viewport newViewport)
        {
            viewport = newViewport;
        }

        public void Update(Vector2 position, int xOffset, int yOffset)
        {
            if (position.X < viewport.Width / 2)
                centre.X = viewport.Width / 2;
            else if (position.X > xOffset - (viewport.Width / 2))
                centre.X = xOffset - (viewport.Width / 2);
            else centre.X = position.X;

            if (position.Y < viewport.Height / 2)
                centre.Y = viewport.Height / 2;
            else if (position.Y > yOffset - (viewport.Height / 2))
                centre.Y = yOffset - (viewport.Height / 2);
            else centre.Y = position.Y;

            BackPosition.X = (centre.X - (viewport.Width / 2));
            BackPosition.Y = (centre.Y - (viewport.Height / 2));

            transform = Matrix.CreateTranslation(new Vector3(-centre.X + (viewport.Width / 2),
                                                             -centre.Y + (viewport.Height / 2), 0));
        }

        //private readonly Viewport _viewport;
        //public Vector2 Position { get; set; }
        //public Vector2 Origin { get; set; }
        //public float Rotation { get; set; }
        //public float Zoom { get; set; }

        //public Camera(Viewport viewport)
        //{
        //    _viewport = viewport;
        //    Rotation = 0;
        //    Zoom = 1;

        //    Origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
        //    Position = Vector2.Zero;
        //}

        //public Vector2 ViewportCenter
        //{
        //    get
        //    {
        //        return new Vector2(_viewport.Width * 0.5f, _viewport.Height * 0.5f);
        //    }
        //}        

        //public Matrix GetViewMatrix()
        //{
        //    // Position = new Vector2(100, 200);
        //    Matrix m =
        //        Matrix.CreateTranslation(new Vector3(-Position, 0)) *//(-Position, 0.0f)) *
        //                                                             // Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
        //         Matrix.CreateRotationZ(Rotation) *
        //        Matrix.CreateScale(Zoom, Zoom, 1);
        //    //Matrix.CreateTranslation(new Vector3(ViewportCenter, 0));
        //    //    Matrix.CreateTranslation(new Vector3(Position, 0.0f));

        //    return m;
        //}
    }
}
