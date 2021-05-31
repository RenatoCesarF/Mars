using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mars.Primitivies;
using System.Collections.Generic;
using System;

namespace Mars.Components
{    
public class Line2D : Component
    {
        #region private Members
        // private Texture2D SimpleTexture; this is not used yet 
        public LineSegment lineSegment;
        private Color color;
        private  Color[] lc;
        private float thickness;
        #endregion
        
        ///<summary>
        /// A game component line segment that receves a primitive line segment
        ///</summary>
        public Line2D(LineSegment line, float thickness = 5){
            lc = new Color[3] { Color.Black, Color.Blue, Color.Orange};
            
            this.lineSegment = line;
            this.thickness = thickness;
            Random rnd = new Random();
            this.color = lc[rnd.Next(3)];
        }
        public override void Draw(Vector2 OFFSET){
            DrawPrimitive.DrawLineToPoint(Global.spriteBatch,lineSegment.from, lineSegment.to,this.color,this.thickness);
        }

        public override void Update(){
        }


    }
}