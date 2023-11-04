using System;
using Tamgotchi;
using Terminal.Gui;

namespace Tamagotchi
{
    internal class Program
    {
        public static bool RollMode { get; set; }
        public static bool Muted { get; set; }
        public static Toplevel top { get; set; }
        private static string muteString { get; set; }

        static void Main(string[] args)
        {
            Application.Init();
            Colors.Base = Colors.ColorSchemes["Error"];

            muteString = "Mute";

            top = Application.Top;

            Window mainWindow = new Window("KCK Casino")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            FrameView frameView = new FrameView("Window 1.")
            {
                X = 0,
                Y = 1,
                Width = Dim.Percent(50),
                Height = Dim.Fill()
            };
            FrameView frameView2 = new FrameView("Window 2.")
            {
                X = Pos.Right(frameView),
                Y = 1,
                Width = Dim.Percent(50),
                Height = Dim.Fill()
            };

            mainWindow.Add(frameView);
            mainWindow.Add(frameView2);

            top.Add(CreateMenuBar());

            LoginWindow loginWindow = new(null)
            {
                OnExit = () => Application.RequestStop(),

                OnLogin = (loginData) =>
                {
                    // for thread-safety
                    Application.MainLoop.Invoke(() =>
                    {

                        top.Add(mainWindow);
                    });

                    Application.Run(top);
                },
            };

            Application.Run(loginWindow);


            //Game myGame = new Game();
            //myGame.Start();
        }
        private static MenuBar CreateMenuBar()
        {
            return new MenuBar(new MenuBarItem[]
            {
                new MenuBarItem("_App", new MenuItem[]
                {
                    new MenuItem("_Quit", "", () => Application.RequestStop())
                }), // end of file menu

                new MenuBarItem("_Help", new MenuItem[]
                {
                    new MenuItem("_About", "", ()
                                => MessageBox.Query(50, 5, "About", "KCK Casino v0.1", "Ok")),
                    new MenuItem("_Roulette rules", "", ()
                                => MessageBox.Query(50, 10, "Rules", $"Earn your bet times {2} by getting two same symbols side by side, or {3} when all three symbols are the same.", "Ok")),
                }), // end of the help menu
            });
        }
    }


}