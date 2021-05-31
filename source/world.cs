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
        public Box2D LL;
        public World(Game game){
            entities = new List<Component>();
        

            line = new Line2D( new LineSegment(Vector2.Zero, new Vector2(500,500)));
            entities.Add(line);

            LL = new Box2D(new Vector2(100,200),new Vector2(500,200));
        }
        public virtual void Update(){
            line.Update();
            line.lineSegment.to = Global.mouseControl.getMousePosition();

            LL.getRigidbody2D().setRotation(0.5f);

            if(Global.keyboard.GetPress("Space")){
                line.lineSegment.from = Global.mouseControl.getMousePosition();
            }

            if(intersectionDetector2D.pointInBox2D(Global.mouseControl.getMousePosition(),LL)){
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
            Box2D box = LL;
            Vector2 center = box.getRigidbody2D().getPosition();

            Vector2 rotatedStartLine = MarsMath.rotate(line.lineSegment.getStart(),- box.getRigidbody2D().getRotation(),center);
            Vector2 rotatedEndLine = MarsMath.rotate(line.lineSegment.getEnd(),-box.getRigidbody2D().getRotation(),center);

            AABB aabb = new AABB(box.size,box.getRigidbody2D().getPosition());
            LineSegment localRotatedLine = new LineSegment(rotatedStartLine,rotatedEndLine);
            Line2D rotatedL = new Line2D(localRotatedLine);
            rotatedL.Draw(OFFSET);

        }
    }
}