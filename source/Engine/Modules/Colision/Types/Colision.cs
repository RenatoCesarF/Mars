
namespace Mars.Collider
{
    public class Collision{
        public Object ObjA;
        public Object ObjB;
        public CollisionPoints points;

        public Collision(Object objA, Object objB, CollisionPoints points){
            this.ObjA = objA;
            this.ObjB = objB;
            this.points = points;
        }

    }
}