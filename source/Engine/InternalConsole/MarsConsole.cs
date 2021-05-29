using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Mars{
    public class MarsConsole{   
        public List<ConsoleMessage> messages;

        ///<summary>
        /// A console that show messages inside the game screen
        ///<summary>
        public MarsConsole(int totalOfMessages = 10){
            messages = new List<ConsoleMessage>(totalOfMessages);
        }

        public void ConsoleLog(String message){
            if(this.messages.Count >= this.messages.Capacity) return;
            messages.Add(new ConsoleMessage(new Vector2(50,50),message));
        }

        public void Update(){
            if(Global.keyboard.GetPress("T")){
                ConsoleLog("AA");
            }

            foreach (ConsoleMessage mss in messages){
                if(mss.timer.hasFinished()){
                    messages.Remove(mss);
                    return;
                }
                
                mss.Update();
            }
        }

        public void Draw(){
            foreach (ConsoleMessage mss in messages){
                mss.Draw();
            }
        }
    }
}