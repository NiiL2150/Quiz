using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class KeyboardInput
    {
        readonly int maxChoice;
        private int choice;
        public int Choice
        {
            get
            {
                return choice;
            }
            set
            {
                if (value < 1)
                {
                    choice = maxChoice;
                }
                else if(value > maxChoice)
                {
                    choice = 1;
                }
                else
                {
                    choice = value;
                }
            }
        }
        public int Input(ConsoleKeyInfo keyInfo)
        {
            if(keyInfo.Key == ConsoleKey.UpArrow)
            {
                return --Choice;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                return ++Choice;
            }
            return Choice;
        }
        public KeyboardInput(int maxChoice)
        {
            this.maxChoice = maxChoice;
            choice = 0;
        }
    }
}
