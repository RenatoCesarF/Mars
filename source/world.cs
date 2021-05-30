using Microsoft.Xna.Framework;
using Mars.Components;
using Mars.Primitivies;
using System.Collections.Generic;

namespace Mars{
    public class World{
        public Line2D line;
        public static RigidBody2D square,square2;
        private Basic2D basic;
        public List<Component> entities;

        public World(Game game){
            entities = new List<Component>();

            square = new RigidBody2D(game,new Vector2(10,50),Color.Orange, mass:0.2f);
            entities.Add(square);

            square2 = new RigidBody2D(game,new Vector2(10,10), Color.CornflowerBlue, mass:0.5f);
            entities.Add(square2);

            basic = new Basic2D("sprite", new Vector2(100,30),new Vector2(100,100));
            entities.Add(basic);
            
            line = new Line2D( new LineSegment(new Vector2(40,20), new Vector2(40,250)));
            entities.Add(line);
        }
        public virtual void Update(){
            foreach (Component entity in entities)
            {
                entity.Update();
            }

            Vector2 mousePos =  new Vector2(Global.mouseControl.newMouse.X,Global.mouseControl.newMouse.Y);

            // if(intersectionDetector2D.pointOnCircle(mousePos,new Circle()));
        }
        public virtual void Draw(Vector2 OFFSET){
            foreach (Component entity in entities)
            {
                entity.Draw(OFFSET);
            }
            Mars.Primitivies.Primitives2D.DrawCircle(Global.spriteBatch,new Vector2(200,200),
            60,1000,Color.Blue,5);
        }
    }
}