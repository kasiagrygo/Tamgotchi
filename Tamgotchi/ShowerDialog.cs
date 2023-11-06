using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Tamgotchi
{
    internal class ShowerDialog: Dialog
    {
        public ShowerDialog(string name, int width, int height, Kitty kitty) : base(name, width, height)
        {
            Button back = new Button("Back")
            {
                X = Pos.Center(),
                Y = 7
            };
            Button brushTeeth = new Button("Brush Teeth")
            {
                X = 2,
                Y = 2
            };
            Label brushTeethLabel = new Label("15%")
            {
                X = 2,
                Y = 3
            };
            Button takeShower = new Button("Take Shower")
            {
                X = Pos.Right(brushTeeth) + 2,
                Y = 2
            };
            Label takeShowerLabel = new Label("70%")
            {
                X = Pos.Right(brushTeeth) + 2,
                Y = 3
            };

            brushTeeth.Clicked += () =>
            {
                kitty.shower = kitty.shower + 0.15F > 1F ? 1F : kitty.shower + 0.15F;
            };

            takeShower.Clicked += () =>
            {
                kitty.shower = kitty.shower + 0.7F > 1F ? 1F : kitty.shower + 0.7F;
            };

            back.Clicked += () =>
            {
                Visible = false;
            };

            Add(back);
            Add(brushTeeth);
            Add(brushTeethLabel);
            Add(takeShower);
            Add(takeShowerLabel);
        }
    }
}
