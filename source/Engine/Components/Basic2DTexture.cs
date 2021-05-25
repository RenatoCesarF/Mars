using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;


namespace RocketFramework{

    class Basic2D{

        private Vector2 position, dimention,vector;
        private float rotation = 0.0f;
        private Texture2D model;
        private SpriteEffects spriteEffect;
        private Rectangle rectangle;
        

        public Basic2D(string PATH, Vector2 position, Vector2 dimention){
            this.model = Global.content.Load<Texture2D>(PATH);

            this.position = position;
            this.dimention = dimention; 

            this.spriteEffect = new SpriteEffects();
            this.rectangle = new Rectangle((int)(position.X),(int)(position.Y), (int)(dimention.X),(int)(dimention.Y));
            this.vector = new Vector2(model.Bounds.Width/2,model.Bounds.Height/2);
        }   
        public virtual void Draw( float customLayerDepth =0.0f){
            if(model == null) return;
            Global.spriteBatch.Draw(model, rectangle, null, Color.White,rotation,vector,spriteEffect,customLayerDepth);
        }
        public virtual void Update(){
        }
    }
}