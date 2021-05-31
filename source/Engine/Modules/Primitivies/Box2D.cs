using Microsoft.Xna.Framework;

namespace Mars
{
    
    public class Box2D
    {
        public Vector2 size = new Vector2();
        private Vector2 halfSize = new Vector2();
        private Rigidbody2D rigidBody = null;
        
        public Box2D(Vector2 size){
            this.halfSize = size/2;
        }
        public Box2D(Vector2 min, Vector2 max){
            this.size = new Vector2(max.X - min.X, max.Y - min.Y);
            this.halfSize = this.size/2;
            // this.center = new Vector2(min.X + size.X*0.5f, min.Y + size.Y*0.5f);
        }

        public Vector2 getMin(){
            return new Vector2(
                this.rigidBody.getPosition().X - this.halfSize.X,
                this.rigidBody.getPosition().Y - this.halfSize.Y
            );
        }
        public Vector2 getMax(){
            return new Vector2(
                this.rigidBody.getPosition().X + this.halfSize.X,
                this.rigidBody.getPosition().Y + this.halfSize.Y
            );
        }
    
        public Vector2[] getVerteces(){
            Vector2 min = getMin();
            Vector2 max = getMax();

            Vector2[] verteces = {
                min, new Vector2(min.X, max.Y),
                new Vector2(max.X, min.Y), max
            };
            if (rigidBody.getRotation() != 0.0f){
                foreach(Vector2 vert in verteces){
                //    MarsMath.rotate(this.;)
                }
            }
            return verteces;
        }
        public Rigidbody2D getRigidbody2D(){
            return this.rigidBody;
        }
    }


}