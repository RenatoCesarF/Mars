using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mars.Components;
using Mars.Primitivies;
using System.Collections.Generic;

namespace Mars{
    public class World{
        public Line2D line;
        // public static RigidBody2D square,square2;
        public List<Component> entities;
        public AABB LL;


        public World(Game game){
            entities = new List<Component>();
        

            line = new Line2D( new LineSegment(new Vector2(600,00), new Vector2(40,250)));
            entities.Add(line);

            LL = new AABB(new Vector2(100,200),new Vector2(500,200));
        }
        public virtual void Update(){
            line.Update();
            line.lineSegment.from = Global.mouseControl.getMousePosition();

            if(intersectionDetector2D.lineInAABB(line.lineSegment,LL)){
                Global.console.print("FUNFA");
                return;
            }
            Global.console.print("kkk");
        }
        public virtual void Draw(Vector2 OFFSET){
            foreach (Component entity in entities){
                entity.Draw(OFFSET);
            }
            LL.Draw();

        }
    }
}