using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace Mars{
    ///<summary>
    /// Global contains global variables:
    /// ContentManager; graphicsDeviceManager; SpriteBatch; InputKeyboard;
    ///</summary>
    public class Global
    {
        public static int screenHeight, screenWidth;
        public  static GraphicsDevice device;
        public  static ContentManager content;
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static InputKeyboard keyboard;
        public static MouseControl mouseControl;
        public static SpriteFont spriteFont;
        public static bool debugging = true;
        public static GameTime gameTime;
        public static MarsConsole console;


        ///<summary>
        ///Return the distance between two vectors
        ///<summary>
        public static float GetDistance(Vector2 position, Vector2 target){
            return (float)Math.Sqrt(Math.Pow(position.X - target.X, 2) + Math.Pow(position.Y - target.Y, 2));
        }

        public static float RotateTowards(Vector2 Pos, Vector2 focus)
        {

            float h, sineTheta, angle;
            if(Pos.Y-focus.Y != 0)
            {
                h = (float)Math.Sqrt(Math.Pow(Pos.X-focus.X, 2) + Math.Pow(Pos.Y-focus.Y, 2));
                sineTheta = (float)(Math.Abs(Pos.Y-focus.Y)/h); //* ((item.Pos.Y-focus.Y)/(Math.Abs(item.Pos.Y-focus.Y))));
            }
            else
            {
                h = Pos.X-focus.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            // Drawing diagonial lines here.
            //Quadrant 2
            if(Pos.X-focus.X > 0 && Pos.Y-focus.Y > 0)
            {
                angle = (float)(Math.PI*3/2 + angle);
            }
            //Quadrant 3
            else if(Pos.X-focus.X > 0 && Pos.Y-focus.Y < 0)
            {
                angle = (float)(Math.PI*3/2 - angle);
            }
            //Quadrant 1
            else if(Pos.X-focus.X < 0 && Pos.Y-focus.Y > 0)
            {
                angle = (float)(Math.PI/2 - angle);
            }
            else if(Pos.X-focus.X < 0 && Pos.Y-focus.Y < 0)
            {
                angle = (float)(Math.PI/2 + angle);
            }
            else if(Pos.X-focus.X > 0 && Pos.Y-focus.Y == 0)
            {
                angle = (float)Math.PI*3/2;
            }
            else if(Pos.X-focus.X < 0 && Pos.Y-focus.Y == 0)
            {
                angle = (float)Math.PI/2;
            }
            else if(Pos.X-focus.X == 0 && Pos.Y-focus.Y > 0)
            {
                angle = (float)0;
            }
            else if(Pos.X-focus.X == 0 && Pos.Y-focus.Y < 0)
            {
                angle = (float)Math.PI;
            }

            return angle;
        }
    }
}