using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace Mars.Primitivies{
  public static class FontBase{
    public static void WriteText( Vector2 position, String text = ""){
        Global.spriteBatch.DrawString(Global.spriteFont,text, position,Color.Black);
    }
    
}  
}