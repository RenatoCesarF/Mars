using Microsoft.Xna.Framework;

public class Rigidbody2D
{
    private Vector2 position;
    private float rotation = 0.0f;

    public Rigidbody2D(Vector2 position){
        this.position = position;
        this.rotation = 0.0f;
    }    
    public void setPosition(Vector2 position){
        this.position = position;
    }

    public Vector2 getPosition() => this.position;

    public void setRotation(float rotation){
        this.rotation = rotation;
    }
    public float getRotation() => this.rotation;
}