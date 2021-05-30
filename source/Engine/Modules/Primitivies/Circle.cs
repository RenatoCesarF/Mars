using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mars.Primitivies;

namespace Mars{
    public class Circle
    {
        private float radius = 1f;
        private Rigidbody2D body = null; 
        public Vector2 position;

        public Circle(){
            
        }

        public float getRadius(){
            return this.radius;
        }
        public Vector2 getCenter(){
            return body.getPosition();
        }
        
    }
}