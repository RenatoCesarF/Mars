using Mars.Components;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    }
}