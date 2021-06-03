using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;



namespace Mars.Components
{

    class Basic2D : Component{

        private Vector2  dimention,originVector;
        private Texture2D model;
        private SpriteEffects spriteEffect;
        private Rectangle rectangle;
        

        public Basic2D(string PATH, Vector2 position, Vector2 dimention){
            this.model = Global.content.Load<Texture2D>(PATH);

            this.position = position;
            this.dimention = dimention; 

            this.spriteEffect = new SpriteEffects();
            this.rectangle = new Rectangle((int)(position.X),(int)(position.Y), (int)(dimention.X),(int)(dimention.Y));
            this.originVector = new Vector2(model.Bounds.Width/2,model.Bounds.Height/2);
        }   
        public override void Draw(Vector2 OFFSET){
            if(model == null) return;
            Global.spriteBatch.Draw(model, rectangle, null, Color.White,rotation,originVector,spriteEffect,0);
        }
        public override void Draw(Vector2 OFFSET,Vector2 ORIGIN){
            if(model == null) return;
            Global.spriteBatch.Draw(model, rectangle, null, Color.White,rotation,ORIGIN,spriteEffect,0);
        }
        public override void Update(){
        }
    }
}