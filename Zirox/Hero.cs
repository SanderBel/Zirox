//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Zirox
//{
//    class Hero : BaseSprite
//    {
//        //public Beweging _beweging { get; set; }

//        private Keys left, right, up, shoot;

//        private Texture2D bulletTexture;
//        private List<Bullet> bullets = new List<Bullet>();
//        private Animation _animationIdle;
//        private Animation _animationJump;
//        private Animation _animationRun;
//        private Animation _animationShootIdle;
//        private Animation _animationShootRun;
//        private Animation _animationHurt;
//        private Animation _animationDead;
//        private Rectangle _ShowRect;

//        private KeyboardState presentKey, pastKey;

//        public Hero(Vector2 newPosition)
//        {
//            //texture = Content.Load<Texture2D>("CharSheet");

//            position = newPosition;

//            minSpeed = 0;
//            maxSpeed = 7.5f;
//        }

//        public void Load(ContentManager Content)
//        {
//            texture = Content.Load<Texture2D>("CharSheet");
//            bulletTexture = Content.Load<Texture2D>("Bullet");

//            #region Animations
//            _ShowRect = new Rectangle(0, 0, 54, 63);
//            _animationIdle = new Animation();
//            _animationIdle.AddFrame(new Rectangle(0, 0, 64, 76));
//            _animationIdle.AddFrame(new Rectangle(64, 0, 64, 76));
//            _animationIdle.AddFrame(new Rectangle(128, 0, 64, 76));
//            _animationIdle.AddFrame(new Rectangle(192, 0, 64, 76));
//            _animationIdle.AddFrame(new Rectangle(256, 0, 64, 76));
//            _animationIdle.AddFrame(new Rectangle(320, 0, 64, 76));
//            _animationIdle.AddFrame(new Rectangle(384, 0, 64, 76));
//            _animationIdle.AddFrame(new Rectangle(448, 0, 64, 76));
//            _animationIdle.AddFrame(new Rectangle(512, 0, 64, 76));
//            _animationIdle.AddFrame(new Rectangle(576, 0, 64, 76));
//            _animationIdle.AantalBewegingenPerSeconde = 16;

//            _animationJump = new Animation();
//            _animationJump.AddFrame(new Rectangle(0, 390, 64, 76));
//            _animationJump.AddFrame(new Rectangle(64, 390, 64, 76));
//            _animationJump.AddFrame(new Rectangle(128, 390, 64, 76));
//            _animationJump.AddFrame(new Rectangle(192, 390, 64, 76));
//            _animationJump.AddFrame(new Rectangle(256, 390, 64, 76));
//            _animationJump.AddFrame(new Rectangle(320, 390, 64, 76));
//            _animationJump.AddFrame(new Rectangle(384, 390, 64, 76));
//            _animationJump.AddFrame(new Rectangle(448, 390, 64, 76));
//            _animationJump.AddFrame(new Rectangle(512, 390, 64, 76));
//            _animationJump.AddFrame(new Rectangle(576, 390, 64, 76));
//            _animationJump.AddFrame(new Rectangle(0, 470, 64, 76));
//            _animationJump.AddFrame(new Rectangle(64, 470, 64, 76));
//            _animationJump.AddFrame(new Rectangle(128, 470, 64, 76));
//            _animationJump.AddFrame(new Rectangle(192, 470, 64, 76));
//            _animationJump.AddFrame(new Rectangle(256, 470, 64, 76));
//            _animationJump.AddFrame(new Rectangle(320, 470, 64, 76));
//            _animationJump.AddFrame(new Rectangle(384, 470, 64, 76));
//            _animationJump.AddFrame(new Rectangle(448, 470, 64, 78));
//            _animationJump.AddFrame(new Rectangle(512, 470, 64, 84));
//            _animationJump.AddFrame(new Rectangle(576, 470, 64, 84));
//            _animationJump.AddFrame(new Rectangle(0, 560, 64, 78));
//            _animationJump.AddFrame(new Rectangle(64, 560, 64, 76));
//            _animationJump.AddFrame(new Rectangle(128, 560, 64, 76));
//            _animationJump.AddFrame(new Rectangle(192, 560, 64, 76));
//            _animationJump.AddFrame(new Rectangle(256, 560, 64, 76));
//            _animationJump.AddFrame(new Rectangle(320, 560, 64, 76));
//            _animationJump.AddFrame(new Rectangle(384, 560, 64, 76));
//            _animationJump.AddFrame(new Rectangle(448, 560, 64, 76));
//            _animationJump.AddFrame(new Rectangle(512, 560, 64, 76));
//            _animationJump.AddFrame(new Rectangle(576, 560, 64, 76));
//            _animationJump.AddFrame(new Rectangle(0, 640, 64, 76));
//            _animationJump.AddFrame(new Rectangle(64, 640, 64, 76));
//            _animationJump.AddFrame(new Rectangle(128, 640, 64, 76));
//            _animationJump.AddFrame(new Rectangle(192, 640, 64, 76));
//            _animationJump.AddFrame(new Rectangle(256, 640, 64, 76));
//            _animationJump.AantalBewegingenPerSeconde = 24;

//            _animationRun = new Animation();
//            _animationRun.AddFrame(new Rectangle(0, 228, 64, 74));
//            _animationRun.AddFrame(new Rectangle(64, 228, 64, 74));
//            _animationRun.AddFrame(new Rectangle(128, 228, 64, 74));
//            _animationRun.AddFrame(new Rectangle(192, 228, 64, 74));
//            _animationRun.AddFrame(new Rectangle(256, 228, 64, 74));
//            _animationRun.AddFrame(new Rectangle(320, 228, 64, 74));
//            _animationRun.AddFrame(new Rectangle(0, 310, 64, 74));
//            _animationRun.AddFrame(new Rectangle(64, 310, 64, 74));
//            _animationRun.AddFrame(new Rectangle(128, 310, 64, 74));
//            _animationRun.AddFrame(new Rectangle(192, 310, 64, 74));
//            _animationRun.AddFrame(new Rectangle(256, 310, 64, 74));
//            _animationRun.AddFrame(new Rectangle(320, 310, 64, 74));
//            _animationRun.AddFrame(new Rectangle(384, 310, 64, 74));
//            _animationRun.AddFrame(new Rectangle(448, 310, 64, 74));
//            _animationRun.AddFrame(new Rectangle(512, 310, 64, 74));
//            _animationRun.AddFrame(new Rectangle(576, 310, 64, 74));
//            _animationRun.AantalBewegingenPerSeconde = 16;

//            _animationShootIdle = new Animation();
//            _animationShootIdle.AddFrame(new Rectangle(0, 800, 64, 70));
//            _animationShootIdle.AddFrame(new Rectangle(64, 800, 64, 70));
//            _animationShootIdle.AddFrame(new Rectangle(128, 800, 64, 70));
//            _animationShootIdle.AddFrame(new Rectangle(192, 800, 64, 70));
//            _animationShootIdle.AddFrame(new Rectangle(256, 800, 64, 70));
//            _animationShootIdle.AddFrame(new Rectangle(320, 800, 64, 70));
//            _animationShootIdle.AddFrame(new Rectangle(384, 800, 64, 70));
//            _animationShootIdle.AddFrame(new Rectangle(448, 800, 64, 70));
//            _animationShootIdle.AddFrame(new Rectangle(512, 800, 64, 70));
//            _animationShootIdle.AantalBewegingenPerSeconde = 16;

//            _animationShootRun = new Animation();
//            _animationShootRun.AddFrame(new Rectangle(0, 720, 64, 76));
//            _animationShootRun.AddFrame(new Rectangle(64, 720, 64, 76));
//            _animationShootRun.AddFrame(new Rectangle(128, 720, 64, 76));
//            _animationShootRun.AddFrame(new Rectangle(192, 720, 64, 76));
//            _animationShootRun.AddFrame(new Rectangle(256, 720, 64, 76));
//            _animationShootRun.AddFrame(new Rectangle(320, 720, 64, 76));
//            _animationShootRun.AddFrame(new Rectangle(384, 720, 64, 76));
//            _animationShootRun.AddFrame(new Rectangle(448, 720, 64, 76));
//            _animationShootRun.AddFrame(new Rectangle(512, 720, 64, 76));
//            _animationShootRun.AddFrame(new Rectangle(576, 720, 64, 76));
//            _animationShootRun.AantalBewegingenPerSeconde = 16;

//            _animationHurt = new Animation();
//            _animationHurt.AddFrame(new Rectangle(0, 152, 64, 76));
//            _animationHurt.AddFrame(new Rectangle(64, 152, 64, 76));
//            _animationHurt.AddFrame(new Rectangle(128, 152, 64, 76));
//            _animationHurt.AddFrame(new Rectangle(192, 152, 64, 76));
//            _animationHurt.AddFrame(new Rectangle(256, 152, 64, 76));
//            _animationHurt.AddFrame(new Rectangle(320, 152, 64, 76));
//            _animationHurt.AddFrame(new Rectangle(384, 152, 64, 76));
//            _animationHurt.AddFrame(new Rectangle(448, 152, 64, 76));
//            _animationHurt.AddFrame(new Rectangle(512, 152, 64, 76));
//            _animationHurt.AantalBewegingenPerSeconde = 16;

//            _animationDead = new Animation();
//            _animationDead.AddFrame(new Rectangle(0, 870, 112, 80));
//            _animationDead.AddFrame(new Rectangle(112, 870, 112, 80));
//            _animationDead.AddFrame(new Rectangle(224, 870, 112, 80));
//            _animationDead.AddFrame(new Rectangle(336, 870, 112, 80));
//            _animationDead.AddFrame(new Rectangle(448, 870, 112, 80));
//            _animationDead.AddFrame(new Rectangle(560, 870, 112, 80));
//            _animationDead.AddFrame(new Rectangle(672, 870, 112, 80));
//            _animationDead.AddFrame(new Rectangle(784, 870, 112, 80));
//            _animationDead.AddFrame(new Rectangle(896, 870, 112, 80));
//            _animationDead.AddFrame(new Rectangle(0, 950, 112, 80));
//            _animationDead.AddFrame(new Rectangle(112, 950, 112, 80));
//            _animationDead.AddFrame(new Rectangle(224, 950, 112, 80));
//            _animationDead.AddFrame(new Rectangle(336, 950, 112, 80));
//            _animationDead.AddFrame(new Rectangle(448, 950, 112, 80));
//            _animationDead.AddFrame(new Rectangle(560, 950, 112, 80));
//            _animationDead.AddFrame(new Rectangle(672, 950, 112, 80));
//            _animationDead.AddFrame(new Rectangle(784, 950, 112, 80));
//            _animationDead.AddFrame(new Rectangle(896, 950, 112, 80));
//            _animationDead.AddFrame(new Rectangle(0, 1030, 112, 80));
//            _animationDead.AddFrame(new Rectangle(112, 1030, 112, 80));
//            _animationDead.AddFrame(new Rectangle(224, 1030, 112, 80));
//            _animationDead.AddFrame(new Rectangle(336, 1030, 112, 80));
//            _animationDead.AddFrame(new Rectangle(448, 1030, 112, 80));
//            _animationDead.AddFrame(new Rectangle(560, 1030, 112, 80));
//            _animationDead.AddFrame(new Rectangle(672, 1030, 112, 80));
//            _animationDead.AddFrame(new Rectangle(784, 1030, 112, 80));
//            _animationDead.AddFrame(new Rectangle(896, 1030, 112, 80));
//            _animationDead.AddFrame(new Rectangle(0, 1110, 112, 80));
//            _animationDead.AddFrame(new Rectangle(112, 1110, 112, 80));
//            _animationDead.AddFrame(new Rectangle(224, 1110, 112, 80));
//            _animationDead.AddFrame(new Rectangle(336, 1110, 112, 80));
//            _animationDead.AddFrame(new Rectangle(448, 1110, 112, 80));
//            _animationDead.AddFrame(new Rectangle(560, 1110, 112, 80));
//            _animationDead.AddFrame(new Rectangle(672, 1110, 112, 80));
//            _animationDead.AddFrame(new Rectangle(784, 1110, 112, 80));
//            _animationDead.AddFrame(new Rectangle(896, 1110, 112, 80));
//            _animationDead.AantalBewegingenPerSeconde = 16;
//            #endregion
//        }

//        public void SetControls(Keys newLeft, Keys newRight, Keys newUp, Keys newShoot)
//        {
//            left = newLeft;
//            right = newRight;
//            up = newUp;
//            shoot = newShoot;
//        }

//        public void Update(List<Enemy> enemies,GameTime gameTime)
//        {
//            _animationIdle.Update(gameTime);
//            _animationJump.Update(gameTime);
//            _animationRun.Update(gameTime);
//            _animationShootIdle.Update(gameTime);
//            _animationShootRun.Update(gameTime);
//            _animationHurt.Update(gameTime);
//            _animationDead.Update(gameTime);

//            presentKey = Keyboard.GetState();

//            position += velocity;
//            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
//            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);

//            //Gravity
//            if (velocity.Y < 10)
//                velocity.Y += 0.5f;

//            if (presentKey.IsKeyDown(left))
//                velocity.X = -1f;
//            if (presentKey.IsKeyDown(left))
//                velocity.X = 1f;

//            if (presentKey.IsKeyDown(up))
//                Speed += 0.5f;
//            else Speed -= 0.25f;

//            if(presentKey.IsKeyDown(shoot)&&pastKey.IsKeyUp(shoot) && bullets.Count <6)
//            {
//                //bullets.Add(new Bullet(this, bulletTexture, 5));
//            }

//            for(int i=0; i<bullets.Count; i++)
//            {
//                if (Vector2.Distance(bullets[i].Position, Position) > 700)
//                {
//                    bullets.RemoveAt(i);
//                    i--;
//                }
//            }

//            velocity.X = Speed;

//            bullets.ForEach(b => b.Update());

//            //Collision
//            foreach(Enemy enemy in enemies)
//            {
//                for (int i = 0; i < bullets.Count; i++)
//                {
//                    if (bullets[i].Rectangle.Intersects(enemy.Rectangle))
//                    {
//                        //enemie.Die();
//                        bullets.RemoveAt(i);
//                        i--;
//                    }
//                }
//            }

//            pastKey = presentKey;



//            //_beweging.Update();

//            //if (_beweging.right)
//            //{
//            //    //faceRight = true;
//            //    velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
//            //    //isMoving = true;
//            //}
//            //else if (_beweging.left)
//            //{
//            //    //faceRight = false;
//            //    velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
//            //    //isMoving = true;
//            //}
//            //else
//            //{
//            //    //isMoving = false;
//            //    velocity.X = 0f;
//            //}

//            //if (_beweging.up) // && hasJumped == false)
//            //{
//            //    position.Y -= 1f;
//            //    velocity.Y = -16f;
//            //    //hasJumped = true;
//            //}
//            //if (_beweging.shoot)
//            //    //hasShot = true;
//            //else
//            //    //hasShot = false;
//        }

//        public override void Draw(SpriteBatch spriteBatch)
//        {
//            //bullets.ForEach(b => b.Draw(spriteBatch));

//            base.Draw(spriteBatch);
//        }
//    }
//}
