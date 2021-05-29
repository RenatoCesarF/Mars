using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mars.Primitivies;

namespace Mars.Components
{    
public class Line2D : Component
    {
        #region private Members
        // private Texture2D SimpleTexture; this is not used yet 
        private Vector2 fromPosition, toPosition;
        private Color color;
        private float thickness;
        #endregion
        
        ///<summary>
        /// A game component line segment that receves, position, thikness and lenght
        ///</summary>
        public Line2D(Vector2 fromPosition , Vector2 toPosition, float thickness = 5){
            this.fromPosition = fromPosition;
            this.toPosition = toPosition;
            this.thickness = thickness;

            this.color = Color.Orange;
        }
        public override void Draw(Vector2 OFFSET){
            DrawPrimitive.DrawLineToPoint(Global.spriteBatch,this.fromPosition,this.toPosition,this.color,this.thickness);
        }

        public override void Update(){
        }
    }
}