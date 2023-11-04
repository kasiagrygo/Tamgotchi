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
        private ProgressBar PlayBar { get; set; }
        public Kitty(ProgressBar playBar)
        {
            play = 1f; 
            shower = 1f; 
            eat = 1f; 
            sleep = 1f;

            PlayBar = playBar;

            TimeLoop();
        }

        private void TimeLoop()
        {
            new Thread(() =>
            {
                while (true)
                {

                    play -= 0.1F;
                    Application.MainLoop.Invoke(() => { PlayBar.SetChildNeedsDisplay(); });
                    Thread.Sleep(3000);
                }
            }).Start();
            
        }
    }
}
