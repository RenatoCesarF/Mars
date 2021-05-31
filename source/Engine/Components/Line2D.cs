using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mars.Primitivies;

namespace Mars.Components
{    
public class Line2D : Component
    {
        #region private Members
        // private Texture2D SimpleTexture; this is not used yet 
        public LineSegment lineSegment;
        private Color color;
        private float thickness;
        #endregion
        
        ///<summary>
        /// A game component line segment that receves a primitive line segment
        ///</summary>
        public Line2D(LineSegment line, float thickness = 5){
            this.lineSegment = line;
            this.thickness = thickness;

            this.color = Color.Orange;
        }
        public override void Draw(Vector2 OFFSET){
            DrawPrimitive.DrawLineToPoint(Global.spriteBatch,lineSegment.from, lineSegment.to,this.color,this.thickness);
        }

        public override void Update(){
        }


    }
}