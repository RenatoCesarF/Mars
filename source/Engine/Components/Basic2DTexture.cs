using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;


namespace RocketFramework{

    class Basic2D{

        public Vector2 position, dimention;
        public Vector2 vector;
        public float rotation = 0.0f;
        public Texture2D model;
        public SpriteEffects spriteEffect;
        public Rectangle rectangle;

        public Basic2D( string PATH, Vector2 position, Vector2 dimention){

            this.position = position;
            this.dimention = dimention; 

            this.model = Global.content.Load<Texture2D>(PATH);

            spriteEffect = new SpriteEffects();
            rectangle = new Rectangle((int)(position.X),(int)(position.Y), (int)(dimention.X),(int)(dimention.Y));
            vector = new Vector2(model.Bounds.Width/2,model.Bounds.Height/2);
        }   
        public virtual void Draw(){
            if(model == null) return;
            Global.spriteBatch.Draw(model, rectangle, null, Color.White,rotation,vector,spriteEffect,0);
        }

        public virtual void Update(){
            this.rotation+=0.1f;
            Console.WriteLine(model.Bounds.Width/2);

        }
    }
}