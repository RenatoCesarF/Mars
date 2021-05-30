using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mars{
    public class MarsConsole{   
        private List<ConsoleMessage> messages;
        private float consoleWidthPosition = 10;
        private float consoleHeightPosition = 345;
        private Vector2[] positions;

        ///<summary>
        /// A console that show messages inside the game screen
        ///<summary>
        public MarsConsole(int totalOfMessages = 10){
            positions = new Vector2[totalOfMessages];

            for(int i = 0; i< totalOfMessages; i++){
                positions[i] = new Vector2(this.consoleWidthPosition, consoleHeightPosition);
                consoleHeightPosition += 18;
            }
            messages = new List<ConsoleMessage>(totalOfMessages);
            messages.Reverse();
        }

        public void print(String message){
            if(this.messages.Count >= this.messages.Capacity) {
                messages.RemoveAt(0);
            };
            messages.Add(new ConsoleMessage(Vector2.Zero,message));
        }

        public void Update(){
            foreach (ConsoleMessage mss in messages){
                if(mss.timer.hasFinished()){
                    messages.Remove(mss);
                    return;
                }
                mss.content.position = positions[messages.IndexOf(mss)];
                mss.Update();
            }
        }

        public void Draw(){
            if(!Global.debugging) return;

            Texture2D pixel = new Texture2D(Global.spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
			pixel.SetData(new[]{ Color.White });

            Global.spriteBatch.Draw(pixel,new Rectangle(0,340,150,150),null,new Color(0,0,0,140),0,Vector2.Zero,SpriteEffects.None,0);

            foreach (ConsoleMessage mss in messages){
                mss.Draw();
            }
        }
    }
}