using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Mars
{
    public class InputKeyboard
    {

        public KeyboardState newKeyboard, oldKeyboard;
        private MarsTimer pressTimer;


        public List<InputKey> pressedKeys = new List<InputKey>(), previousPressedKeys = new List<InputKey>();

        public InputKeyboard(){
            pressTimer = new MarsTimer(130,true);
        }

        public virtual void Update(){
            pressTimer.UpdateTimer();

            newKeyboard = Keyboard.GetState();
            GetPressedKeys();
        }

        public void UpdateOld(){
            oldKeyboard = newKeyboard;

            previousPressedKeys = new List<InputKey>();

            for(int i=0;i<pressedKeys.Count;i++){
                previousPressedKeys.Add(pressedKeys[i]);
            }
        }


        public bool GetPress(string KEY){
            if(!pressTimer.hasFinished()){ return false;}


            for(int i=0;i<pressedKeys.Count;i++)
            {
                if(pressedKeys[i].key == KEY)
                {
                    Global.console.print(KEY.ToString());
                    pressTimer.ResetToZero();
                    return true;
                }
            }
            return false;
        }


        public virtual void GetPressedKeys()
        {
            // bool found = false;

            pressedKeys.Clear();
            for(int i=0; i<newKeyboard.GetPressedKeys().Length; i++)
            {
                pressedKeys.Add(new InputKey(newKeyboard.GetPressedKeys()[i].ToString(), 1));
            }
        }

    }
}