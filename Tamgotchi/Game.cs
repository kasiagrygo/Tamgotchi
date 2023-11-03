using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Tamgotchi
{
    internal class Game
    {
        public void Start()
        {
            Title = "Tamagotchi";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = @"
 
              ████████╗ █████╗ ███╗   ███╗ █████╗  ██████╗  ██████╗ ████████╗ ██████╗██╗  ██╗██╗
              ╚══██╔══╝██╔══██╗████╗ ████║██╔══██╗██╔════╝ ██╔═══██╗╚══██╔══╝██╔════╝██║  ██║██║
                 ██║   ███████║██╔████╔██║███████║██║  ███╗██║   ██║   ██║   ██║     ███████║██║
                 ██║   ██╔══██║██║╚██╔╝██║██╔══██║██║   ██║██║   ██║   ██║   ██║     ██╔══██║██║
                 ██║   ██║  ██║██║ ╚═╝ ██║██║  ██║╚██████╔╝╚██████╔╝   ██║   ╚██████╗██║  ██║██║
                 ╚═╝   ╚═╝  ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝    ╚═╝    ╚═════╝╚═╝  ╚═╝╚═╝



            ";
            string[] options = { "Start", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunStart();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }

        private void RunStart() 
        {
            Clear();
            
            string prompt = @"Choose your character
            
            ";
            string[] options = { @"
──────▄▀▄─────▄▀▄──────
─────▄█░░▀▀▀▀▀░░█▄─────
─▄▄──█░░░░░░░░░░░█──▄▄─
█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█", @"


───▄▀▀▀▄▄▄▄▄▄▄▀▀▀▄───
───█▒▒░░░░░░░░░▒▒█───
────█░░█░░░░░█░░█────
─▄▄──█░░░▀█▀░░░█──▄▄─
█░░█─▀▄░░░░░░░▄▀─█░░█"};

            Menu chooseMenu = new Menu(prompt, options);
            int selectedIndex = chooseMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    break;
                case 1:
                    Clear();
                    break;
            }

            ReadKey(true);
            RunMainMenu();
        }
        private void DisplayAboutInfo()
        {
            Clear();
            WriteLine("Info");
            ReadKey(true);
            RunMainMenu();
        }

        private void ExitGame()
        {
            WriteLine("\nPress any key to exit.. ");
            ReadKey(true);
            Environment.Exit(0);
        }
    }
}
