using Microsoft.Xna.Framework;

///</summary>
///Axis Aling Bounding Box
/// <summary>
namespace RocketFramework
{
class AABB
{
    private Vector2 size = new Vector2();
    private Vector2 halfSize = new Vector2();
    private Rigidbody2D rigidBody = null;
    public AABB(){
        this.halfSize = size/2;
    }
    public AABB(Vector2 min, Vector2 max){
        this.size = new Vector2(max.X - min.X, max.Y - min.Y);
        this.halfSize = this.size/2;
        // this.center = new Vector2(min.X + size.X*0.5f, min.Y + size.Y*0.5f);
    }

    public Vector2 getMin(){
        return new Vector2(
            this.rigidBody.getPosition().X - this.halfSize.X/2,
            this.rigidBody.getPosition().Y - this.halfSize.Y/2
        );
    }
    public Vector2 getMax(){
        return new Vector2(
            this.rigidBody.getPosition().X + this.halfSize.X/2,
            this.rigidBody.getPosition().Y + this.halfSize.Y/2
        );
    }
}
}