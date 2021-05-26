	
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mars.Draw.DrawPrimitive
{
		
	public static class DrawPrimitive{
		private static Texture2D pixel;
		
		/// <summary>
		/// Creates a new Texture in the selected spriteBatch
		/// </summary>
		private static void createTexture(SpriteBatch spriteBatch){
			pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
			pixel.SetData(new[]{ Color.White });
		}


		#region Draw Line
		/// <summary>
		/// Draws a line from point1 to point2 with an offset
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="point">The starting point</param>
		/// <param name="length">The length of the line</param>
		/// <param name="angle">The angle of this line from the starting point</param>
		/// <param name="color">The color to use</param>
		/// <param name="thickness">The thickness of the line</param>
		public static void DrawLine(this SpriteBatch spriteBatch, Vector2 point, float length, float angle, Color color, float thickness){
			if (pixel == null){createTexture(spriteBatch);}
			// stretch the pixel between the two vectors
			spriteBatch.Draw(
				pixel,point,null,
				color,angle,
				new Vector2(0, (float)pixel.Height / 2),
				new Vector2(length, thickness),
				SpriteEffects.None,0
			);
		}

		/// <summary>
		/// Draws a line from one point to another
		/// </summary>
		/// <param name="spriteBatch">The destination drawing surface</param>
		/// <param name="fromPoint">The first origin point</param>
		/// <param name="toPoint">The end point</param>
		/// <param name="color">The color to use</param>
		/// <param name="thickness">The thickness of the line</param>
		public static void DrawLineToPoint(this SpriteBatch spriteBatch, Vector2 fromPoint, Vector2 toPoint, Color color, float thickness){
				// calculate the distance between the two vectors
				float distance = Vector2.Distance(fromPoint, toPoint);

				// calculate the angle between the two vectors
				float angle = (float)Math.Atan2(toPoint.Y - fromPoint.Y, toPoint.X - fromPoint.X);

				DrawLine(spriteBatch, fromPoint, distance, angle, color, thickness);
		}
		#endregion
	}

}
