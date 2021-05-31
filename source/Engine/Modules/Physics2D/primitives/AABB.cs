using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

///</summary>
///Axis Aling Bounding Box
/// <summary>
namespace Mars
{
    public class AABB
    {
        private Vector2 size;
        private Vector2 halfSize;
        private Rigidbody2D rigidbody;
        public AABB(Vector2 size, Vector2 position){
            this.size = size;
            this.halfSize =  this.size * 0.5f;
            this.rigidbody = new Rigidbody2D(position);
        }

        public Vector2 getMin(){
            return this.rigidbody.getPosition() - this.halfSize;
        }
        public Vector2 getMax(){
            return this.rigidbody.getPosition() + this.halfSize;
        }

        public void Draw(){
            Texture2D pixel = new Texture2D(Global.spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
			pixel.SetData(new[]{ Color.White });
            Global.spriteBatch.Draw(pixel,this.rigidbody.getPosition(),null,Color.Aqua,0,new Vector2(0.5f,0.5f),this.size,Microsoft.Xna.Framework.Graphics.SpriteEffects.None,0);

            Global.spriteBatch.Draw(pixel,this.getMin(),null,Color.Blue,0,new Vector2(0.5f,0.5f),new Vector2(10,10),Microsoft.Xna.Framework.Graphics.SpriteEffects.None,0);
            Global.spriteBatch.Draw(pixel,this.getMax(),null,Color.Blue,0,new Vector2(0.5f,0.5f),new Vector2(10,10),Microsoft.Xna.Framework.Graphics.SpriteEffects.None,0);

        }

        public Vector2 getSize() => this.size;

    }
}