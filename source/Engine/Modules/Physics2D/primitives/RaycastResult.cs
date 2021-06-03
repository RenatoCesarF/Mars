using Microsoft.Xna.Framework;

namespace Mars
{
    public class RaycastResult
    {
        private Vector2 point;
        private Vector2 normal;
        private float t;
        private bool hit;


        public RaycastResult(){
            this.point = new Vector2();
            this.normal = new Vector2();
            this.t = -1;
            this.hit = false;
        }
        public void init(Vector2 point, Vector2 normal, float t, bool hit){
            this.point = point;
            this.normal = normal;
            this.t = t;
            this.hit = hit;
        }
        public static void reset(RaycastResult restul){
            if(restul == null) return;
            restul.point = Vector2.Zero;
            restul.normal = Vector2.Zero;
            restul.t = -1;
            restul.hit = false; 

        }
        
    }
}