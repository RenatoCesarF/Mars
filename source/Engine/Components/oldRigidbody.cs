using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace Mars.Components
{
    public class RigidBody2D : Component
    {
        private Texture2D whiteRectangle;
        private Vector2  force, aceleration;
        private Vector2 originVector;
        private float mass = 0;
        private int height, width;
        private Color rectColor;

        /// <summary>
        /// A entity that reacts to gravity and physics laws simulations.
        /// Colisions and motion are auto-simulated
        /// </summary>
        /// <param name="game">Used to specify context.</param>
        /// <param name="position">The start position of the Entity.</param>
        /// <param name="color">If the Component doesn't have a Texture, it needs to receve a Color</param>
        /// <param name="mass">the mass will interfer in motion and colision stuff</param>
        public RigidBody2D(Game game, Vector2 position, Color color, float mass = 0.1f )  {
            this.mass = mass;
            this.position= position;
            this.rectColor = color;
            this.height = 50;
            this.width = 50;
            this.aceleration = new Vector2(0,0);
            this.force = new Vector2(0,0);
            whiteRectangle = new Texture2D(Global.device, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });
            this.originVector = new Vector2(0.5f,0.5f);
            //TODO: add a texture or a based2d as a required argument
            //TODO: add Friction
            //TODO: add Bounce
            //TODO: Add rotation
        }
        /// <summary>
        /// Applies a force and X and Y direction, it is effected by the mass of the object
        /// </summary>
        /// <param name="xForce">The force applied in X axis</param>
        /// <param name="yForce">The force applied in Y axis</param>
        public void applyForce(float xForce = 0f,float yForce = 0f ){
            Vector2 appliedForce = new Vector2(xForce,yForce);
            appliedForce /= mass;
            this.force += appliedForce;
        }
        public override void Update(){
            keyboardReactionCheck();
            checkEdges();
            // applyForce(yForce:0.098f);

            this.force += this.aceleration * this.mass;
            this.position += this.force;
        }
        public override void Draw(Vector2 OFFSET){
            Global.spriteBatch.Draw(
                texture: whiteRectangle,
                new  Rectangle((int)(position.X - OFFSET.X),(int)(position.Y - OFFSET.Y),width, height),
                null, this.rectColor,rotation,originVector,
                SpriteEffects.None,0
            );
        }        
        public void keyboardReactionCheck(){
            if(Global.keyboard.GetPress("W")){
                applyForce(yForce: -0.05f);
            }
            if(Global.keyboard.GetPress("S")){
                applyForce(yForce: 0.05f);
            }
            if(Global.keyboard.GetPress("A")){
                applyForce(xForce: -0.05f);
            }
            if(Global.keyboard.GetPress("D")){
                applyForce(xForce: 0.05f);
            }
        }

        private void checkEdges(){
            if(this.position.Y >  Global.graphics.PreferredBackBufferHeight - 60){
                this.position.Y =  Global.graphics.PreferredBackBufferHeight - 61;
                this.force.Y *=-1 * this.mass;
            }

            if(this.position.X >= Global.graphics.PreferredBackBufferWidth - 20){
                this.position.X = Global.graphics.PreferredBackBufferWidth - 20;
                this.force.X *= -1 * this.mass;
            }else if(this.position.X <=0){
                this.position.X =0;
                this.force.X *=-1 * this.mass;
            }
        }
    }
}