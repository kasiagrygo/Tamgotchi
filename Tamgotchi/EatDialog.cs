using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Tamgotchi
{
    internal class EatDialog: Dialog
    {
        public EatDialog(string name, int width, int height, Kitty kitty) : base(name, width, height) 
        {
            Button back = new Button("Back")
            {
                X = Pos.Center(),
                Y = 7
            };
            Button fries = new Button("Fries")
            {
                X = 2,
                Y = 2
            };
            Label friesLabel = new Label("20%")
            {
                X = 2,
                Y = 3
            };
            Button hamburger = new Button("Hamburger")
            {
                X = Pos.Right(fries) + 2,
                Y = 2
            };
            Label hamburgerLabel = new Label("40%")
            {
                X = Pos.Right(fries) + 2,
                Y = 3
            };

            fries.Clicked += () =>
            {
                kitty.eat = kitty.eat + 0.2F > 1F ? 1F : kitty.eat + 0.2F;
            };

            hamburger.Clicked += () =>
            {
                kitty.eat = kitty.eat + 0.4F > 1F ? 1F : kitty.eat + 0.4F;
            };

            back.Clicked += () =>
            {
                Visible = false;
            };

            Add(back);
            Add(fries);
            Add(friesLabel);
            Add(hamburger);
            Add(hamburgerLabel);
        }
    }
}
