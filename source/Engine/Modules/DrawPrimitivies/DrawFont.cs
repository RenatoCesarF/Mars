using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace Mars.Primitivies{
  public static class FontBase{
    public static void WriteText( Vector2 position, Vector2 scale,String text = "", String color = "black"){
      Color textColor;

      if(color == "white"){
        textColor = Color.GhostWhite;
      }else{

        textColor = Color.Black;
      }
      
      Global.spriteBatch.DrawString(Global.spriteFont,text, position,textColor,0,Vector2.Zero,scale,SpriteEffects.None,0);
    }
    
}  
}