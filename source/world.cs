using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mars.Components;
using Mars.Primitivies;
using System.Collections.Generic;

namespace Mars{
    public class World{
        public Line2D line,laaa;
        public List<Component> entities;
        public Box2D box;
        float rotate = 5;
        public World(Game game){
            entities = new List<Component>();

            line = new Line2D( new LineSegment(Vector2.Zero, new Vector2(500,500)));
            box = new Box2D(new Vector2(100,200),new Vector2(500,200));
        }
        public virtual void Update(){
            line.Update();
            line.lineSegment.to = Global.mouseControl.getMousePosition();
               
            box.getRigidbody2D().setRotation(rotate);
            rotate += 0.01f;
            if(Global.keyboard.GetPress("Space")){
                line.lineSegment.from = Global.mouseControl.getMousePosition();
            }

            if(intersectionDetector2D.lineInBox2D(line.lineSegment,box)){
                Global.console.print("FUNFA");
                return;
            }
            Global.console.print("kkk");
         

        }
        public virtual void Draw(Vector2 OFFSET){
            box.Draw();

            line.Draw(OFFSET);
        }
    }
}