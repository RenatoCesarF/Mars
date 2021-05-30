using System;
using Microsoft.Xna.Framework;
using Mars.Components;

namespace Mars
{
    public class ConsoleMessage
    {
        public Text content;
        public Vector2 position;
        public bool isShowing;
        public MarsTimer timer;

        public ConsoleMessage(Vector2 position, String text){
            isShowing = true;
            timer = new MarsTimer(2500);
            content = new Text(position, text,new Vector2(0.5f,0.5f),"white");
        }
        public void Update(){
            timer.UpdateTimer();
        
            if(!timer.hasFinished()) return;

            isShowing = false;
        }
        public void Draw(){
            if(isShowing == false) return;

            content.Draw();
        }

    }
}