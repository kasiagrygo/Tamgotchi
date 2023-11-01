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
                                                                                  

                                                                                 
Welcome to the Tamagotchi";
            string[] options = { "Start", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunFirstChoice();
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

        private void RunFirstChoice() 
        {
            Clear();
            WriteLine("Game");
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
