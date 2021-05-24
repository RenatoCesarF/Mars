using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace RocketFramework
{
    
public class Line2D :DrawableGameComponent 
{
    private static Texture2D _texture;
    public Texture2D SimpleTexture; 
    public float rotation;
    private Vector2 originVector;

    public Line2D(Game game): base (game){
        SimpleTexture = new Texture2D(Game1.device, 1,1);
        SimpleTexture.SetData(new[] { Color.White });
        originVector =  new Vector2(SimpleTexture.Bounds.Width/2,SimpleTexture.Bounds.Height/2);
    }
    public override void Draw(GameTime gameTime){
        Global.spriteBatch.Draw(
            SimpleTexture, new Rectangle(100, 100, 300, 10), null,
            Color.Blue, this.rotation, new Vector2(0.5f,0.5f), SpriteEffects.None, 1f
        );
        base.Draw(gameTime);
    }

    public override void Update(GameTime gameTime){
        this.rotation +=0.1f;
        Console.WriteLine(SimpleTexture.Bounds.Width/2);
        base.Update(gameTime);

    }
}
}