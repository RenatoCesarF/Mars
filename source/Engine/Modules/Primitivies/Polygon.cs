using Microsoft.Xna.Framework;
using Mars.Primitivies;
using System;
using System.Collections.Generic;
namespace Mars
{
    public class Polygon {
        public List<Vector2> points;
        private Vector2 position;
        public bool overlap;
       
        /// <summary>
        /// Create a perfect Polygon that can be drawn in the screen, receeving size and edges;
        /// </summary>
        /// <param name="position">Where it's gonna be</param>
        /// <param name="size">The radius size of the polygon</param>
        /// <param name="edges">The number of Edges of it</param>
        public Polygon(Vector2 position, float size,int edges ){
            this.position = position;
            this.points = new List<Vector2>(edges);
            
            for(int i = 0; i < edges; i ++){
                points.Add(
                    new Vector2(
                        (10*size) * (float)Math.Cos(( MathHelper.Pi * 2 /edges) * i),
                        (10*size) * (float)Math.Sin((MathHelper.Pi * 2 /edges) * i)
                    )
                    + position
                );
            }
        }
        /// <summary>
        /// Create polygon receving a infinit number of Points that have it's own position
        /// </summary>
        /// <param name="position">Where the middle gonna be</param>
        public Polygon(Vector2 position, List<Vector2> points){
            this.position = position;
            this.points = points;
        }

        public void addPoint(Vector2 pointPosition){
            this.points.Capacity = this.points.Capacity+1;
            this.points.Add(pointPosition);
        }
        public void removePoint(int position = -1){
            if(points.Capacity <= 1) return;
            if(position == -1){
                position = this.points.Capacity-1;
            }
            
            this.points.RemoveAt(position);
            this.points.Capacity -= 1;

        }
        public void Draw(){
            for(int i = 0; i< this.points.Capacity; i++){
                DrawPrimitive.DrawLineToPoint(Global.spriteBatch,points[i],points[(i + 1 )% points.Capacity],Color.BlueViolet,4);
            }
            // DrawPrimitive.DrawLineToPoint(Global.spriteBatch, points[0],position,Color.Yellow);
        }
    }
}