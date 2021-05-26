using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace RocketFramework
{
    
public class Line2D
{
    private Texture2D SimpleTexture; 
    private Vector2 fromPosition, toPosition;
    private float rotation;
    private Vector2 originVector;
    private Rectangle rectangle;
    
    ///<summary>
    ///A line segment that receves, position, thikness and lenght
    ///</summary>
    public Line2D(Vector2 fromPosition , Vector2 toPosition){
        this.fromPosition = fromPosition;
        this.toPosition = toPosition;
        // this.rectangle =
        this.SimpleTexture = new Texture2D(Game1.device, 1,1);
        this.originVector =  new Vector2(0.5f,0.5f);//Vector2(SimpleTexture.Bounds.Width/2,SimpleTexture.Bounds.Height/2);

        SimpleTexture.SetData(new[] { Color.White });
    }
    public virtual void Draw(float customLayerDepth =0.0f){
        /*
        Pra fazer esse lance do from e to position temos que calcular o angulo entre as duas posições 
        setar o angulo da reta pra esse angulo e adicionar largura na mesma até que essa chegue até a posição do segundo objeto

        pra questão do numero negativo tenho algumas teorias: 
            - Verificar se a subtração é negativa, se for inverte quem é o from e to position e inverte quem é o lenght
        */
        Global.spriteBatch.Draw(
            SimpleTexture,  new Rectangle((int)(fromPosition.X),(int)(fromPosition.Y),(int)(toPosition.X),(int)(toPosition.Y)), null,
            Color.Red, this.rotation, Vector2.Zero, 
            SpriteEffects.None, customLayerDepth
        );
    }
    public virtual void Update(){

    }
}
}