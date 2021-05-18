using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace MyGame
{
    public class RigidBody2D
    {
        private Texture2D whiteRectangle;
        public Vector2 position;
        public int height = 10, width = 10;

        public RigidBody2D(){
            whiteRectangle = new Texture2D(Game1.device, 1, 1);
            position= new Vector2(10,20);
            whiteRectangle.SetData(new[] { Color.White });
        }

        public virtual void Update(){
     
            position.Y +=5;
        }

        public virtual void Draw(){
            Global.spriteBatch.Draw(whiteRectangle, new  Rectangle((int)(position.X),(int)(position.Y),width, height),Color.BurlyWood);
        }
        
    }
}