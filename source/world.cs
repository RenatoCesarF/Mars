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
        public World(Game game){
            entities = new List<Component>();

            line = new Line2D( new LineSegment(Vector2.Zero, new Vector2(500,500)));
            box = new Box2D(new Vector2(100,200),new Vector2(500,200));

            // laaa = new Line2D(new LineSegment( new Vector2(450,100),new Vector2(450,500)));
            // laaa.lineSegment.from = MarsMath.rotate( laaa.lineSegment.getStart(), rotate,box.getRigidbody2D().getPosition());
            // laaa.lineSegment.to  =  MarsMath.rotate( laaa.lineSegment.getEnd(), rotate,box.getRigidbody2D().getPosition());
            
        }
        public virtual void Update(){
            line.Update();
            line.lineSegment.to = Global.mouseControl.getMousePosition();

            box.getRigidbody2D().setRotation(5);

         
            if(Global.keyboard.GetPress("Space")){
                line.lineSegment.from = Global.mouseControl.getMousePosition();
            }

            if(intersectionDetector2D.pointInBox2D(Global.mouseControl.getMousePosition(),box)){
                Global.console.print("FUNFA");
                return;
            }
            Global.console.print("kkk");

        }
        public virtual void Draw(Vector2 OFFSET){
            box.Draw();
               
            line.Draw(OFFSET);
           
            // laaa.Draw(OFFSET);
           
            
            LineSegment a = new LineSegment( line.lineSegment.from, line.lineSegment.to);  
            a.from =  MarsMath.rotate(a.getStart(),box.getRigidbody2D().getRotation(),box.getRigidbody2D().getPosition());
            a.to = MarsMath.rotate(a.getEnd(),box.getRigidbody2D().getRotation(),box.getRigidbody2D().getPosition());
            Line2D dd = new Line2D(a,8);

            dd.Draw(OFFSET);
        }
    }
}