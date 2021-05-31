using Microsoft.Xna.Framework;
using Mars.Components;
using Mars.Primitivies;
using System.Collections.Generic;

namespace Mars{
    public class World{
        public Line2D line;
        // public static RigidBody2D square,square2;
        public List<Component> entities;
        public Line2D LL;

        public World(Game game){
            entities = new List<Component>();
            // square = new RigidBody2D(game,new Vector2(10,50),Color.Orange, mass:0.2f);
            // entities.Add(square);

            // square2 = new RigidBody2D(game,new Vector2(10,10), Color.CornflowerBlue, mass:0.5f);
            // entities.Add(square2);

            line = new Line2D( new LineSegment(new Vector2(600,00), new Vector2(40,250)));
            entities.Add(line);


            LL = new Line2D(line:new LineSegment(new Vector2(300,400) ,new Vector2(500,200)));
            
          
      
        }
        public virtual void Update(){
            // foreach (Component entity in entities)
            // {
            //     entity.Update();
            // }
            line.Update();
            line.lineSegment.from = Global.mouseControl.getMousePosition();

            if(intersectionDetector2D.lineInLine(line.lineSegment,LL.lineSegment)){
                Global.console.print("FUNFA");
            }
            else{
                Global.console.print("Nao colide");
            }
        }
        public virtual void Draw(Vector2 OFFSET){
            foreach (Component entity in entities){
                entity.Draw(OFFSET);
            }
            LL.Draw(OFFSET);
        }
    }
}