using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Tamgotchi
{
    internal class PlayDialog : Dialog
    {
        private int random {  get; set; }
        public PlayDialog(string name, int width, int height, Kitty kitty) : base(name, width, height)
        {
            random = RandomNumber();

            Button back = new Button("Back")
            {
                X = Pos.Center(),
                Y = 7
            };

            back.Clicked += () =>
            {
                Visible = false;
            };

            Add(back);

            Label label = new Label("Please enter a number between 1 and 99")
            {
                X = Pos.Center(),
                Y = 1
            };

            TextField field = new TextField()
            {
                X = Pos.Center(),
                Y = Pos.Center(),
                Width = Dim.Percent(15)
            };

            field.KeyPress += (args) =>
            {
                if (args.KeyEvent.KeyValue == (int)Key.Enter)
                {
                    string input = field.Text.ToString();
                    int inputNumber = 0;
                    bool result = int.TryParse(input, out inputNumber);

                    
                    if (result == false)
                        label.Text = "The number does not meet the standards";
                    else if (inputNumber < random) 
                    {
                        label.Text = "Your number is too low";
                    }
                    else if (inputNumber > random)
                    {
                        label.Text = "Your number is too high";
                    }
                    if (inputNumber == random)
                    {
                        label.Text = "You win!!!";
                        kitty.play = kitty.play + 0.3F > 1F ? 1F : kitty.play + 0.3F;
                    }
                }

                

            };


            field.TextChanged += (e) =>
            {
                if (field.Text.Length > 2)
                {
                    field.Text = field.Text.Substring(0, 2);
                }
            };

            Add(label);
            Add(field);
        }

        public int RandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(1, 99);
        }

    }
}
