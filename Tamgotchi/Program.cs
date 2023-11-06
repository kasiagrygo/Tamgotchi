using NStack;
using System;
using System.ComponentModel;
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



            //mainWindow           
            Label nameLabel = new Label(@"
 
              ████████╗ █████╗ ███╗   ███╗ █████╗  ██████╗  ██████╗ ████████╗ ██████╗██╗  ██╗██╗
              ╚══██╔══╝██╔══██╗████╗ ████║██╔══██╗██╔════╝ ██╔═══██╗╚══██╔══╝██╔════╝██║  ██║██║
                 ██║   ███████║██╔████╔██║███████║██║  ███╗██║   ██║   ██║   ██║     ███████║██║
                 ██║   ██╔══██║██║╚██╔╝██║██╔══██║██║   ██║██║   ██║   ██║   ██║     ██╔══██║██║
                 ██║   ██║  ██║██║ ╚═╝ ██║██║  ██║╚██████╔╝╚██████╔╝   ██║   ╚██████╗██║  ██║██║
                 ╚═╝   ╚═╝  ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝    ╚═╝    ╚═════╝╚═╝  ╚═╝╚═╝
            ")
            {
                X = 4,
                Y = 0
            };
            
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





            //Button Start
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
                    Y = 2,
                    Width = Dim.Percent(35),
                    ProgressBarStyle = ProgressBarStyle.Continuous,
                    ProgressBarFormat = ProgressBarFormat.SimplePlusPercentage
                };

                ProgressBar progressBarShower = new ProgressBar()
                {
                    X = Pos.Right(progressBarPlay) + 10,
                    Y = 2,
                    Width = Dim.Percent(35),
                    ProgressBarStyle = ProgressBarStyle.Continuous,
                    ProgressBarFormat = ProgressBarFormat.SimplePlusPercentage
                };
                
                ProgressBar progressBarEat = new ProgressBar()
                {
                    X = 10,
                    Y = 5,
                    Width = Dim.Percent(35),
                    ProgressBarStyle = ProgressBarStyle.Continuous,
                    ProgressBarFormat = ProgressBarFormat.SimplePlusPercentage
                };

                ProgressBar progressBarSleep = new ProgressBar()
                {
                    X = Pos.Right(progressBarEat) + 10,
                    Y = 5,
                    Width = Dim.Percent(35),
                    ProgressBarStyle = ProgressBarStyle.Continuous,
                    ProgressBarFormat = ProgressBarFormat.SimplePlusPercentage
                };

                Label floor = new Label("--------------------------------------------------------------------------------------------------")
                {
                    X = 0,
                    Y = 20,
                    Width = Dim.Percent(100)
                };

                Label playLabel = new Label("Play")
                {
                    X = 10,
                    Y = 1
                };

                Label playShower = new Label("Shower")
                {
                    X = Pos.Right(progressBarPlay) + 10,
                    Y = 1
                };

                Label playEat = new Label("Eat")
                {
                    X = 10,
                    Y = 4
                };

                Label playSleep = new Label("Sleep")
                {
                    X = Pos.Right(progressBarEat) + 10,
                    Y = 4
                };

                Kitty kitty = new Kitty(progressBarPlay, progressBarShower, progressBarEat, progressBarSleep);

                gameWindow.Add(kitty.KittyDraw());
                gameWindow.Add(progressBarPlay);
                gameWindow.Add(progressBarShower);
                gameWindow.Add(progressBarEat); 
                gameWindow.Add(progressBarSleep);
                gameWindow.Add(playLabel);
                gameWindow.Add(playShower);
                gameWindow.Add(playEat);
                gameWindow.Add(playSleep);
                gameWindow.Add(floor);



                //Arrows
                Button goLeft = new Button(@"Left")
                {
                    X = 38,
                    Y = 22
                };

                Button goRight = new Button(@"Right")
                {
                    X = Pos.Right(goLeft) + 2,
                    Y = 22
                };

       

                goLeft.Clicked += () =>
                {
                    kitty.kittyLabel.X -= 3;
                    Application.Refresh();

                };

                goRight.Clicked += () =>
                {
                    kitty.kittyLabel.X += 3;
                    Application.Refresh();
                };

                gameWindow.Add(goLeft);
                gameWindow.Add(goRight);




                //Options Window Buttons
                Button backButton = new Button("Back")
                {
                    X = 3,
                    Y = 22
                };

                backButton.Clicked += () =>
                {
                    gameWindow.Visible = false;
                    optionsWindow.Visible = false;

                    Application.Refresh();

                    mainWindow.Add(start, about, exit);
                };

                Button playButton = new Button("Play")
                {
                    X = 3,
                    Y = 3
                };

                playButton.Clicked += () =>
                {
                    PlayDialog playDialog = new PlayDialog("Game", 40, 10, kitty);
                    gameWindow.Add(playDialog);

                };

                Button showerButton = new Button("Shower")
                {
                    X = 2,
                    Y = 7
                };

                showerButton.Clicked += () =>
                {
                    ShowerDialog showerDialog = new ShowerDialog("Shower", 40, 10, kitty);
                    gameWindow.Add(showerDialog);

                };

                Button eatButton = new Button("Eat")
                {
                    X = 3,
                    Y = 11
                };

                eatButton.Clicked += () =>
                {
                    EatDialog eatDialog = new EatDialog("Food", 30, 10, kitty);
                    gameWindow.Add(eatDialog);
                    
                };
            

                Button sleepButton = new Button("Sleep")
                {
                    X = 2,
                    Y = 15
                };

                sleepButton.Clicked += () =>
                {
                    SleepDialog sleepDialog = new SleepDialog("Sleep", 40, 15, kitty);
                    gameWindow.Add(sleepDialog);
                    while (kitty.sleep < 0.99F)
                    {
                        Thread.Sleep(1000);
                        kitty.sleep = kitty.sleep + 0.01F > 1F ? 1F : kitty.sleep + 0.01F;
                    }
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
            mainWindow.Add(nameLabel);

            top.Add(mainWindow);

           
            Application.Run();
        }
    }
}