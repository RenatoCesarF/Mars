using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;



namespace Mars.Primitivies
{
    public class Line2D
    {
        public Vector2 from {get; set;}
        public Vector2 to   {get; set;}
        private int lifetime   {get; set;}      
        private Color color;

        public Line2D(Vector2 from, Vector2 to, Color color, int lifetime){
            this.from = from;
            this.to = to;
            this.color = color;
            this.lifetime = lifetime;
        }
        public Line2D(Vector2 from, Vector2 to){
            this.from = from;
            this.to = to;
        }

        public Vector2 getStart(){
            return this.from;
        }

        public Vector2 getEnd(){
            return this.to;
        }
    }
}