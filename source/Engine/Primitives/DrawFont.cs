using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace Mars.Primitivies{
  public static class FontBase{
    public static void WriteText(SpriteFont fontSource, SpriteBatch spriteBatch, Vector2 position, String text = ""){
        spriteBatch.DrawString(fontSource,text, new Vector2(50,50),Color.Black);
    }
    
}  
}