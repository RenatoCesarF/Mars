using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mars.Primitivies;

namespace Mars{
    public class Circle
    {
        private float radius = 1f;
        private Rigidbody2D body = null; 
        public Vector2 position;

        public Circle(Rigidbody2D body ,float radius = 5){
            this.body = body;
            this.radius = radius;
        }

        public float getRadius(){
            return this.radius;
        }
        public Vector2 getCenter(){
            return body.getPosition();
        }

        public void Draw(){
            if(!Global.debugging){
                return;
            }
            

            Primitives2D.DrawCircle(Global.spriteBatch, this.getCenter(),this.radius,1000,Color.BlueViolet,10);
        }
        
    }
}