using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Tamgotchi
{
    internal class Kitty
    {
        public float play { get; set; }
        
        public float shower { get; set; }

        public float eat { get; set; }
    
        public float sleep {  get; set; }

        public Kitty()
        {
            play = 1f; 
            shower = 1f; 
            eat = 1f; 
            sleep = 1f;
            //TimeLoop();
        }

        private void TimeLoop()
        {
            new Thread(() =>
            {
                while (true)
                {
                    
                    Application.Refresh();

                    Thread.Sleep(3000);
                }
            }).Start();
            
        }
    }
}
