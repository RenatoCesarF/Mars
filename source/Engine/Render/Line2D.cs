using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace RocketFramework
{
    
public class Line2D
{
    public Texture2D SimpleTexture; 
    public float rotation;
    private Vector2 originVector;
    private Rectangle rectangle;
    
    ///<summary>
    ///A line segment that receves, position, thikness and lenght
    ///</summary>
    public Line2D(Vector2 position,int thikness = 2, int lenght = 100){
        this.rectangle = new Rectangle((int)(position.X),(int)(position.Y),lenght,thikness);
        this.SimpleTexture = new Texture2D(Game1.device, 1,1);
        this.originVector =  new Vector2(0.5f,0.5f);//Vector2(SimpleTexture.Bounds.Width/2,SimpleTexture.Bounds.Height/2);
        SimpleTexture.SetData(new[] { Color.White });
    }
    public virtual void Draw(float customLayerDepth =0.0f){
        Global.spriteBatch.Draw(
            SimpleTexture, this.rectangle, null,
            Color.Red, this.rotation, originVector, 
            SpriteEffects.None, customLayerDepth
        );
    }
    public virtual void Update(){
        this.rotation +=0.1f;
    }
}
}