using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Mars.Components;

namespace Mars
{
    public class ConsoleMessage
    {
        public Text content;
        public bool isShowing;
        public MarsTimer timer;

        public ConsoleMessage(Vector2 position, String text){
            isShowing = true;
            timer = new MarsTimer(5000);
            timer.SetTimer(0);
            content = new Text(position, text);
        }
        public void Update(){
            timer.UpdateTimer();

            if(!timer.hasFinished()){return;}

            isShowing = false;
        }
        public void Draw(){
            if(isShowing == false){return;}

            content.Draw();
        }

    }
}