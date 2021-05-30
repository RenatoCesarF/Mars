using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Mars
{
    public class MarsTimer
    {
        public bool goodToGo;
        protected int miliSeconds;
        protected TimeSpan timer = new TimeSpan();
        

        public MarsTimer(int miliseconds){
            goodToGo = false;
            this.miliSeconds = miliseconds;
        }
        public MarsTimer(int miliseconds, bool STARTLOADED){
            goodToGo = STARTLOADED;
            this.miliSeconds = miliseconds;
        }

        public int MiliSeconds{
            get{ return this.miliSeconds; }
            set{ this.miliSeconds = value; }
        }
        public int Timer{
            get { return (int)timer.TotalMilliseconds; }
        }

        

        public void UpdateTimer(){
            timer += Global.gameTime.ElapsedGameTime;
        }

        public void UpdateTimer(float SPEED){
            timer += TimeSpan.FromTicks((long)(Global.gameTime.ElapsedGameTime.Ticks * SPEED));
        }

        public virtual void AddToTimer(int MSEC){
            timer += TimeSpan.FromMilliseconds((long)(MSEC));
        }

        public bool hasFinished(){
            if(timer.TotalMilliseconds >= this.miliSeconds || goodToGo){
                return true;
            }
            else{
                return false;
            }
        }

        public void Reset(){
            timer = timer.Subtract(new TimeSpan(0, 0, this.miliSeconds/60000, this.miliSeconds/1000, this.miliSeconds%1000));
            if(timer.TotalMilliseconds < 0)
            {
                timer = TimeSpan.Zero;
            }
            goodToGo = false;
        }

        public void Reset(int NEWTIMER){
            timer = TimeSpan.Zero;
            this.miliSeconds = NEWTIMER;
            goodToGo = false;
        }

        public void ResetToZero(){
            timer = TimeSpan.Zero;
            goodToGo = false;
        }

        public virtual XElement ReturnXML(){
            XElement xml= new XElement("Timer",
                            new XElement("miliSeconds", this.miliSeconds),
                            new XElement("timer", Timer)
            );
            return xml;
        }

        public void SetTimer(TimeSpan TIME){
            timer = TIME;
        }

        public virtual void SetTimer(int MSEC){
            timer = TimeSpan.FromMilliseconds((long)(MSEC));
        }
    }
}
