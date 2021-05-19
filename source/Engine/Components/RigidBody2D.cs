using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace MyGame
{
    public class RigidBody2D :DrawableGameComponent 
    {
        private Texture2D whiteRectangle;
        public Vector2 position, force, aceleration,velocity;
        public float mass ;

        public int height, width;
        public Color rectColor;

        public RigidBody2D(Game game, Vector2 position, Color color, float mass = 0.1f ) : base(game) {
            this.mass = mass;
            this.position= position;
            this.rectColor = color;
           
            height = 50;
            width = 50;
            aceleration = new Vector2(0,0);
            force = new Vector2(10,10);

            whiteRectangle = new Texture2D(Game1.device, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });
        }
        public void applyForce(float xForce = 0f,float yForce = 0f ){
            Vector2 appliedForce = new Vector2(xForce,yForce);
            appliedForce /= mass;
            this.force += appliedForce;
        }

        public override void Update(GameTime gametime){
            keyboardReactionCheck();
            checkEdges();
            applyForce(yForce:0);
            

            this.force += this.aceleration* this.mass;
            this.position += this.force;
            base.Update(gametime);
            Console.WriteLine(this.force);

        }
        private void checkEdges(){
            if(this.position.Y >= Game1.device.Viewport.Height - 60){
                this.position.Y = Game1.device.Viewport.Height - 61;
                this.force.Y *=-1 * this.mass;
            }else if(this.position.Y <= 0){
                this.position.Y = 0;
                this.force.Y *=-1 * this.mass;
            }

            if(this.position.X >= Game1.device.Viewport.Width - 40){
                this.position.X = Game1.device.Viewport.Width - 40;
                this.force.X *= -1 * this.mass;
            }else if(this.position.X <=0){
                this.position.X =0;
                this.force.X *=-1 * this.mass;
            }
        }
        public override void Draw(GameTime gameTime){
            Global.spriteBatch.Draw(whiteRectangle, new  Rectangle((int)(position.X),(int)(position.Y),width, height),this.rectColor);
            base.Draw(gameTime);
        }
        
        public void keyboardReactionCheck(){
            if(Global.keyboard.GetPress("W")){
                applyForce(yForce: -5f);
                return;
            }
            if(Global.keyboard.GetPress("S")){
                applyForce(yForce: 0.05f);
                return;
            }
            if(Global.keyboard.GetPress("A")){
                applyForce(xForce: -0.05f);
                return;
            }
            if(Global.keyboard.GetPress("D")){
                applyForce(xForce: 0.05f);
                return;
            }
            
        }
    }
}