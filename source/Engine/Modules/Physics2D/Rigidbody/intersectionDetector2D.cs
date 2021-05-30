using Microsoft.Xna.Framework;
using Mars.Primitivies;

namespace Mars
{
    public class intersectionDetector2D{


        ///<summary>
        ///</summary>
        public static bool pointOnLine(Vector2 point, LineSegment line){
            float d1 = Global.GetDistance(point,line.getStart());
            float d2 = Global.GetDistance(point,line.getEnd());


            float lineLen = Global.GetDistance(line.getStart(),line.getEnd());

          
            float buffer = 0.1f;

            return d1+d2 >= lineLen-buffer && d1+d2 <= lineLen+buffer;
        }

        public static bool pointInCircle(Vector2 point, Circle circle){

            Vector2 circleCenter = circle.getCenter();
            Vector2 lineFromCenterToPoint = point - circleCenter;
            
            return lineFromCenterToPoint.LengthSquared() < circle.getRadius()*circle.getRadius();
        }

        public static bool pointInAABB(Vector2 point, AABB box){
            Vector2 min = box.getMin();
            Vector2 max = box.getMax();

            return point.X <= max.X && min.X <= point.X &&
                    point.Y <= max.Y && min.Y <= point.Y;
        }
        public static bool pointInBox2D(Vector2 point, Box2D box){
            Vector2 pointInBoxSpace = point;
            MarsMath.rotate(
                pointInBoxSpace,box.getRigidbody2D().getRotation(),
                box.getRigidbody2D().getPosition()
            );
            Vector2 min = box.getMin();
            Vector2 max = box.getMax();

            return pointInBoxSpace.X <= max.X && min.X <= pointInBoxSpace.X &&
                    pointInBoxSpace.Y <= max.Y && min.Y <= pointInBoxSpace.Y;
        }
    }

}