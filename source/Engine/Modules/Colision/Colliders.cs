using Microsoft.Xna.Framework;

namespace Mars.Collider
{
    
    public class SphereCollider : Collider{
        Vector2 center;
        float radius;

        public override CollisionPoints TestCollision(
            Transform transform,
            Collider collider,
            Transform colliderTransform
        ){
            return collider.TestCollision(colliderTransform,this, transform);
        }
        public override CollisionPoints TestCollision(
            Transform transform,
            SphereCollider sphere,
            Transform sphereTransform
        ){
            return algo.FindSphereSphereCollisionPoints(this, transform, sphere, sphereTransform);
        }

        public override CollisionPoints TestCollision(
            Transform transform,
            PlaneCollider plane,
            Transform planeTransform
        ){
            return algo.FindSpherePlaneCollisionPoints(this, transform, plane, planeTransform);
        }
    }

    public class PlaneCollider : Collider{
        Vector2 center;
        float distance;

        public override CollisionPoints TestCollision(Transform transform,Collider collider,Transform colliderTransform){
            return collider.TestCollision(colliderTransform,this, transform);
        }
        public override CollisionPoints TestCollision(
            Transform transform,
            SphereCollider sphere,
            Transform sphereTransform
        ){
            CollisionPoints points = sphere.TestCollision(sphereTransform,this,transform);

            Vector2 T = points.A;
            points.A = points.B;
            points.B = T;

            points.normal = -points.normal;
            return points;
        }

        public override CollisionPoints TestCollision(
            Transform transform,
            PlaneCollider plane,
            Transform planeTransform
        ){
            return new CollisionPoints();
        }
    }

    public class Collider
    {
        public virtual CollisionPoints TestCollision(
            Transform transform,
            Collider collider,
            Transform colliderTransform
        ) {return new CollisionPoints();}
        public virtual CollisionPoints TestCollision(
            Transform transform,
            SphereCollider sphere,
            Transform colliderTransform
        ) {return new CollisionPoints();}
        public virtual CollisionPoints TestCollision(
            Transform transform,
            PlaneCollider plane,
            Transform colliderTransform
        ) {return new CollisionPoints();}
    }

}