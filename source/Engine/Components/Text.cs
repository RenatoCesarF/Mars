using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Mars.Primitivies;

namespace Mars.Components
{
    public class Text : Component
    {
        public String text;
        private String color;
        public Text(Vector2 position, String text,Vector2 scale, String color){
            this.position = position;
            this.text = text;
            this.scale = scale;
            this.color = color;
        }

        public virtual void Draw(){
            FontBase.WriteText(this.position,this.scale,this.text, this.color);
        }
        public override void Update(){}
    }
}