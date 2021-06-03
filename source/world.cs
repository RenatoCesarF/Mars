using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mars.Components;
using Mars.Primitivies;
using System.Collections.Generic;

namespace Mars{
    public class World{
     
        public List<Component> entities;
        public World(Game game){
         
        }
        public virtual void Update(){
    
        }
        public virtual void Draw(Vector2 OFFSET){

        }
    }
}