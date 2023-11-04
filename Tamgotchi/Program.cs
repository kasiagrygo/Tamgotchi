using NStack;
using System;
using System.Xml.Linq;
using Tamgotchi;
using Terminal.Gui;

namespace Tamagotchi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            Colors.Base = Colors.ColorSchemes["Error"];

            var top = Application.Top;

            Kitty kitty = new Kitty();

            Window mainWindow = new Window("Tamagotchi")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            Button start = new Button("Start")
            {
                X = Pos.Center(), 
                Y = Pos.Percent(50) - 1,
            };

            Button about = new Button("About")
            {
                X = Pos.Center(), 
                Y = Pos.Bottom(start) + 1
            };

            Button exit = new Button("Exit")
            {
                X = Pos.Center(),
                Y = Pos.Bottom(about) + 1
            };


            start.Clicked += () =>
            {

                Window optionsWindow = new Window("Options")
                {
                    X = 0,
                    Y = 1,
                    Width = Dim.Percent(15),
                    Height = Dim.Fill()
                };

                Window gameWindow = new Window("Game")
                {
                    X = Pos.Right(optionsWindow),
                    Y = 1,
                    Width = Dim.Percent(85),
                    Height = Dim.Fill()
                };


                ProgressBar progressBarPlay = new ProgressBar()
                {
                    X = 10,
                    Y = 1,
                    Width = Dim.Percent(35),
                    Fraction = kitty.play,
                    
                };

                ProgressBar progressBarShower = new ProgressBar()
                {
                    X = Pos.Right(progressBarPlay) + 10,
                    Y = 1,
                    Width = Dim.Percent(35),
                    Fraction = kitty.shower
                };

                
                ProgressBar progressBarEat = new ProgressBar()
                {
                    X = 10,
                    Y = 3,
                    Width = Dim.Percent(35),
                    Fraction = kitty.eat
                };

                ProgressBar progressBarSleep = new ProgressBar()
                {
                    X = Pos.Right(progressBarEat) + 10,
                    Y = 3,
                    Width = Dim.Percent(35),
                    Fraction = kitty.sleep
                };

                gameWindow.Add(progressBarPlay);
                gameWindow.Add(progressBarShower);
                gameWindow.Add(progressBarEat); 
                gameWindow.Add(progressBarSleep);   
                    

                Button backButton = new Button("Back")
                {
                    X = 3,
                    Y = 22
                };

                Button playButton = new Button("Play")
                {
                    X = 3,
                    Y = 3
                };

                Button showerButton = new Button("Shower")
                {
                    X = 2,
                    Y = 7
                };

                Button eatButton = new Button("Food")
                {
                    X = 3,
                    Y = 11
                };


                Button sleepButton = new Button("Sleep")
                {
                    X = 2,
                    Y = 15
                };


                backButton.Clicked += () =>
                {
                    gameWindow.Visible = false;
                    optionsWindow.Visible = false;

                    Application.Refresh();

                    mainWindow.Add(start, about, exit);
                };

                optionsWindow.Add(backButton);
                optionsWindow.Add(playButton);
                optionsWindow.Add(showerButton);
                optionsWindow.Add(eatButton);
                optionsWindow.Add(sleepButton);

                mainWindow.Add(optionsWindow);
                mainWindow.Add(gameWindow);
                
                Application.Refresh();
            };

            mainWindow.Add(start, about, exit);

            top.Add(mainWindow);

            Application.MainLoop.Invoke(() =>
            {
                while (true)
                {
                    kitty.play -= 0.1F;
                    Thread.Sleep(1000);
                }
            });
            Application.Run();
        }
    }
}