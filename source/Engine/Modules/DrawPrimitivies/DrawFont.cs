using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mars.Primitivies{
  public static class FontBase{
    public static void WriteText( Vector2 position, Vector2 scale,String text = "", String color = "black"){
      Color textColor = Color.Black;

      if(color == "white"){
        textColor = Color.GhostWhite;
      }

      Global.spriteBatch.DrawString(
        Global.spriteFont,text, position,
        textColor,0,Vector2.Zero,scale,SpriteEffects.None,0
      );
    }
  }  
}