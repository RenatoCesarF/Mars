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
                point,box.getRigidbody2D().getRotation(),
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
            float theta = -box.getRigidbody2D().getRotation();
            Vector2 center = box.getRigidbody2D().getPosition();

            Vector2 rotatedStartLine = MarsMath.rotate(line.getStart(),theta,center);
            Vector2 rotatedEndLine = MarsMath.rotate(line.getEnd(),theta,center);

            AABB aabb = new AABB(box.size,box.getRigidbody2D().getPosition());
            LineSegment localRotatedLine = new LineSegment(rotatedStartLine,rotatedEndLine);

            return lineInAABB(localRotatedLine,aabb);
        }
        
        
        
        #endregion
    }

}