using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private ProgressBar ShowerBar { get; set; }
        private ProgressBar EatBar { get; set; }
        private ProgressBar SleepBar { get; set; }
        public Kitty(ProgressBar playBar, ProgressBar showerBar, ProgressBar eatBar, ProgressBar sleepBar)
        {
            //Ustawiamy domyślne wartości
            play = 1f; 
            shower = 1f; 
            eat = 1f; 
            sleep = 1f;

            //Przypisujemy bary
            PlayBar = playBar;
            PlayBar.Fraction = play;

            ShowerBar = showerBar;
            ShowerBar.Fraction = shower;

            EatBar = eatBar;
            EatBar.Fraction = eat;

            SleepBar = sleepBar;
            SleepBar.Fraction = sleep;

            Loop();
        }

        private void Loop()
        {
            Thread thread = new(() =>
            {
                //Czekamy 5sec żeby UI się napewno załadował
                Thread.Sleep(5000);
                while(true)
                {
                    play -= 0.01f;
                    shower -= 0.01f;
                    eat -= 0.02f;
                    sleep -= 0.01f;

                    PlayBar.Fraction = play;
                    ShowerBar.Fraction = shower;
                    EatBar.Fraction = eat;
                    SleepBar.Fraction = sleep;

                    //Workaround żeby UI się aktuzalizował
                    typeof(Application).GetMethod("TerminalResized", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
                    Thread.Sleep(2000);
                }
            });

            thread.Start();
        }
    }
}
