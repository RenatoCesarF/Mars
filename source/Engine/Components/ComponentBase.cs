using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Mars.Components
{
    public class Component
    {
        public Vector2 position; // talvez ser get and set (propriedade)
        public Vector2 scale, drawOrigin;
        public String name;
        public float rotation = 0.0f;
        public bool isVisible;

        public virtual void Update(){}
        public virtual void Draw(Vector2 OFFSET){}
        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN){}

    }
}