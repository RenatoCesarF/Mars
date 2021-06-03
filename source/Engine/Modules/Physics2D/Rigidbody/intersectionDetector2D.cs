using Microsoft.Xna.Framework;
using Mars.Primitivies;
using System;

namespace Mars
{
    public class intersectionDetector2D{


        #region Point Colision
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
            
            Vector2 pointInBoxSpace = MarsMath.rotate(
                point, - box.getRigidbody2D().getRotation(),
                box.getRigidbody2D().getPosition()
            );
            AABB aabbBox = new AABB(box.size,box.getRigidbody2D().getPosition());

            return pointInAABB(pointInBoxSpace,aabbBox);
            
        }

        #endregion
        
        #region Line Colision
        public static bool lineInCircle(LineSegment line, Circle circle){
            if(pointInCircle(line.getStart(), circle) || pointInCircle(line.getEnd(), circle)){
                return true;
            }
            Vector2 lineSegment = new Vector2(line.getEnd().X - line.getStart().X,line.getEnd().Y - line.getStart().Y);
            Vector2 circleCenter = new Vector2(circle.getCenter().X,circle.getCenter().Y);
            Vector2 centerToLineStart = new Vector2( circleCenter.X - line.getStart().X, circleCenter.Y - line.getStart().Y);
            float t = (centerToLineStart.X * lineSegment.X +centerToLineStart.Y* lineSegment.Y) / (lineSegment.X * lineSegment.X +lineSegment.Y* lineSegment.Y);

            if(t < 0.0f || t>= 1.0f){
                return false;
            }

            Vector2 closestPoint =  line.getStart()+lineSegment * t;

            return pointInCircle(closestPoint,circle);
        }    
       
        public static bool lineInLine(LineSegment line1, LineSegment line2){
            float end_X_line2_sub_start_X_line2 = line2.getEnd().X - line2.getStart().X;
            float start_Y_line1_sub_end_Y_line2 = line1.getStart().Y - line2.getStart().Y;
            float end_X_line1_sub_start_X_line1 = line1.getEnd().X - line1.getStart().X;
            float end_Y_line2_sub_start_Y_line2 = line2.getEnd().Y - line2.getStart().Y;
            float start_X_line1_sub_start_X_line2 = line1.getStart().X - line2.getStart().X;
            float end_Y_line1_sub_start_Y_line1 = line1.getEnd().Y - line1.getStart().Y;

            float uA =  ((end_X_line2_sub_start_X_line2)*(start_Y_line1_sub_end_Y_line2) -
                         (end_Y_line2_sub_start_Y_line2)*(start_X_line1_sub_start_X_line2)) /
                        ((end_Y_line2_sub_start_Y_line2)*(end_X_line1_sub_start_X_line1) - 
                            (end_X_line2_sub_start_X_line2)*(end_Y_line1_sub_start_Y_line1));

            float uB = ((end_X_line1_sub_start_X_line1)*(start_Y_line1_sub_end_Y_line2) - 
                        (end_Y_line1_sub_start_Y_line1)*(start_X_line1_sub_start_X_line2)) / 
                        ((end_Y_line2_sub_start_Y_line2)*(end_X_line1_sub_start_X_line1) - 
                        (end_X_line2_sub_start_X_line2)*(end_Y_line1_sub_start_Y_line1));

            // if uA and uB are between 0-1, lines are colliding
            if (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1) {
                return true;
            }
            return false;
        }
        public static bool lineInAABB(LineSegment line, AABB box){
            if(pointInAABB(line.getStart(), box) || pointInAABB(line.getEnd(), box)){
                return true;
            }

            LineSegment topOfTheBox = new LineSegment(box.getMin(), new Vector2(box.getMin().X + box.getSize().X,box.getMin().Y));
            LineSegment bottomOfTheBox = new LineSegment(box.getMax(), new Vector2(box.getMax().X - box.getSize().X,box.getMax().Y));  
            LineSegment leftOfTheBox = new LineSegment( box.getMin(), new Vector2(box.getMin().X,box.getMin().Y + box.getSize().Y));  
            LineSegment rightOfTheBox = new LineSegment( box.getMax(), new Vector2(box.getMax().X,box.getMax().Y - box.getSize().Y));    

            if(lineInLine(line,topOfTheBox) || lineInLine(line,bottomOfTheBox) || lineInLine(line,leftOfTheBox) || lineInLine(line,rightOfTheBox)){
                return true;
            }
            return false;

        }
        public static bool lineInBox2D(LineSegment line, Box2D box){
            Box2D thisBox = box;
            LineSegment thisLine = line;

            float theta = -thisBox.getRigidbody2D().getRotation();
            Vector2 center = thisBox.getRigidbody2D().getPosition();

            Vector2 rotatedStartLine = MarsMath.rotate(thisLine.getStart(),theta,center);
            Vector2 rotatedEndLine = MarsMath.rotate(thisLine.getEnd(),theta,center);

            AABB aabb = new AABB(thisBox.size,thisBox.getRigidbody2D().getPosition());
            LineSegment localRotatedLine = new LineSegment(rotatedStartLine,rotatedEndLine);

            return lineInAABB(localRotatedLine,aabb);
        }
        
        
        
        #endregion
    
        #region Raycast

        // public static bool raycast(Circle circle, Ray2D ray,RaycastResult result){
        //     if(result == null) return false;

        //     RaycastResult.reset(result);

        //     Vector2 originToCircle = circle.getCenter() - ray.getOrigin();
        //     float radiusSquared = circle.getRadius() * circle.getRadius();
        //     float originToCircleLenghtSquared = (float)Math.Sqrt(originToCircle.X * originToCircle.X + originToCircle.Y * originToCircle.Y);

        //     float a = (originToCircle.X * ray.getDirection().X) + (originToCircle.Y * ray.getDirection().Y);
        //     float lenghtCenterCircleToProjected = originToCircleLenghtSquared - (a*a);

        //     if(radiusSquared - lenghtCenterCircleToProjected< 0.0f){
        //         return false;
        //     }

        //     float f = (float)Math.Sqrt(radiusSquared - lenghtCenterCircleToProjected);

        //     float t = 0;

        //     if(originToCircleLenghtSquared < radiusSquared){
        //         t = a + f;
        //     }else{
        //         t = a - f;
        //     }

        //     Vector2 point = ray.getOrigin()  + (ray.getDirection() * t);
        //     Vector2 normal = point - circle.getCenter();
        //     normal.Normalize();

        //     result.init(point, normal, t, hit: true);
        //     return true; 

        // }

        // public static bool raycast(AABB box,Ray2D ray, RaycastResult result){
        //     RaycastResult.reset(result);

        //     // if(result == null ) return false;

        //     Vector2 unitVector = ray.getDirection();
        //     unitVector.Normalize();
        //     unitVector.X = (unitVector.Y !=0) ? 1.0f / unitVector.X : 0f;
        //     unitVector.X = (unitVector.X !=0) ? 1.0f / unitVector.Y : 0f;

        //     Vector2 min = box.getMin();
        //     min  = min - (ray.getOrigin() * unitVector);//mudar a ordem das operações com () e ver se muda o resultado
        //     Vector2 max = box.getMax();
        //     max = max  - (ray.getOrigin() * unitVector);

        //     float tmin = Math.Max(Math.Min(min.X,max.X), Math.Min(min.Y,max.Y));
        //     float tmax = Math.Min(Math.Max(min.X,max.X), Math.Max(min.Y,max.Y));

        //     if(tmax < 0 || tmin > tmax){
        //         return false;
        //     }


        //     float t = (tmin < 0f) ?tmax : tmin;
        //     bool hit = t>0f;

        //     if(!hit){
        //         return false;
        //     }

        //     Vector2 point = ray.getOrigin() + ray.getDirection() * t;
        //     Vector2 normal = ray.getOrigin() - point;
        //     normal.Normalize();

        //     result.init(point,normal,t,hit);

        //     return true;
        // }

        // public static bool raycast(Box2D box, Ray2D ray, RaycastResult result){
        //     RaycastResult.reset(result);
        //     Box2D thisBox = box;
        //     Ray2D thisRay = ray;

        //     float theta = -thisBox.getRigidbody2D().getRotation();
        //     Vector2 center = thisBox.getRigidbody2D().getPosition();

        //     Vector2 rotatedStartRay = MarsMath.rotate(thisRay.getOrigin(),theta,center);
        //     Vector2 rotatedEndRay = MarsMath.rotate(thisRay.getDirection(),theta,center);

        //     AABB aabb = new AABB(thisBox.size,thisBox.getRigidbody2D().getPosition());
        //     Ray2D localRotatedRay = new Ray2D(rotatedStartRay,rotatedEndRay);

        //     return raycast(aabb,thisRay,new RaycastResult());
        // }


        #endregion
    
    }

}