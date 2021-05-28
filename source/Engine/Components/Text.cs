using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Mars.Primitivies;

namespace Mars.Components
{
    public class Text : Component
    {
        private String text;
        public Text(Vector2 position, String text){
            this.position = position;
            this.text = text;
        }

        public virtual void Draw(){
            FontBase.WriteText(this.position,this.text);
        }
        public override void Update(){}
    }
}