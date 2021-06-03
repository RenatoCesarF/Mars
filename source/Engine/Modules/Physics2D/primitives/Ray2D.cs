using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mars{

    public class Ray2D
    {
        private Vector2 origin;
        private Vector2 direction;

        public Ray2D(Vector2 origin, Vector2 direction){
            this.origin = origin;
            this.direction = direction;
            direction.Normalize();
        }
        public void setDirection(Vector2 newDirection){
            this.direction = newDirection;
        }
        public Vector2 getOrigin(){
            return this.origin;
        }

        public Vector2 getDirection(){
            return this.direction;
        }

    }
}