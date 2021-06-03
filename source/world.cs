using Microsoft.Xna.Framework;
using Mars.Components;
using System.Collections.Generic;
using System;

namespace Mars{
    public class World{
     
        public List<Component> entities;
        public Polygon polygon;
        public MarsTimer timer;
        public World(Game game){
            polygon = new Polygon(new Vector2(150,150),5,6);
            timer = new MarsTimer(1000);
        }
        public virtual void Update(){
            timer.UpdateTimer();
            if(Global.keyboard.GetPress("Space") && timer.hasFinished()){
               polygon.addPoint(Global.mouseControl.getMousePosition());
               timer.ResetToZero();
            }
            if(Global.keyboard.GetPress("R") ){
               polygon.removePoint();
            }
                
        }
        public virtual void Draw(Vector2 OFFSET){
            polygon.Draw();
        }
    }
}