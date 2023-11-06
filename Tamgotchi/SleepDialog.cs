using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Tamgotchi
{
    internal class SleepDialog: Dialog
    {
        public SleepDialog(string name, int width, int height, Kitty kitty) : base(name, width, height)
        {
            Label sleepLabel = new Label(@"      
       |\      _,,,---,,_
ZZZzz /,`.-'`'    -.  ;-;;,_
     |,4-  ) )-,_. ,\ (  `'-'
    '---''(_/--'  `-'\_)")
            {
                X = Pos.Center(),
                Y = Pos.Center()
            };
            Button back = new Button("Back")
            {
                X = Pos.Center(),
                Y = 10
            };

            back.Clicked += () =>
            {
                Visible = false;
            };

            Add(sleepLabel);
            Add(back);
        }
    }
}
