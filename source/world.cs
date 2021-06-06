using Microsoft.Xna.Framework;
using Mars.Components;
using System.Collections.Generic;
using System;

namespace Mars{
    public class World{
     
        public List<Component> entities;
        public Polygon polygon;

        public World(Game game){
            polygon = new Polygon(new Vector2(150,150),5,6);
        }

        public virtual void Update(){
            if(Global.keyboard.GetPress("Space")){
               polygon.transform(Global.mouseControl.getMousePosition());
            }
          
        }
        public virtual void Draw(Vector2 OFFSET){
            polygon.Draw();
        }
    }
}