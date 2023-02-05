using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryService;

namespace MenuService
{
    internal static class Menu
    {
        static Menu() { }

        public static void StartMenu()
        {
            Console.Clear();


            int choice = 0;
            int tmpIndx = 0;
            Dictionary MainDictionary = new();


            Console.WriteLine("~--Menu--~\n" +
                "[1] - Create Dictionary\n" +
                "[2] - Edit Dictionary\n" +
                "[3] - Show Dictionary\n" +
                "[4] - Search The Word\n" +
                "[5] - Save To File Dictionary\n" +
                "[6] - Save To File Word\n" +
                "[7] - Exit Program\n" +
                "Press on number: \n"
                );
            ConsoleKeyInfo UserInput = Console.ReadKey();


            if (char.IsDigit(UserInput.KeyChar))
            {
                choice = Convert.ToInt32(UserInput.KeyChar.ToString());
            }
            else
            {
                Console.WriteLine("error");
                Menu.StartMenu();
            }


            switch (choice)
            {
                case 1:
                    MainDictionary.CreateDictionary();
                    Menu.StartMenu();
                    break;

                case 2:
                    if (MainDictionary == null)
                    {
                        Console.WriteLine("you cannot edit empty dictionary");
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.EditDictionary();
                        Menu.StartMenu();
                    }
                    break;

                case 3:
                    if (MainDictionary == null)
                    {
                        Console.WriteLine("cannot print null dictionary");
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {

                        MainDictionary.EditDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.PrintDictionary();
                        Menu.StartMenu();
                    }
                    break;

                case 4:
                    if (MainDictionary == null)
                    {
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {
                        MainDictionary.EditDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.FindWord();
                        Menu.StartMenu();
                    }
                    break;

                case 5:
                    if (MainDictionary == null)
                    {
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {
                        MainDictionary.EditDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.SaveToFile();
                        Menu.StartMenu();
                    }
                    break;

                case 6:
                    if (MainDictionary == null)
                    {
                        Console.WriteLine("cannot save word from null dictionary");
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {
                        MainDictionary.EditDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        Console.Write("enter index of word~# ");
                        tmpIndx = Convert.ToInt32(Console.ReadLine());

                        MainDictionary.translationPairs[tmpIndx - 1].SaveWord();
                        Menu.StartMenu();
                    }
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("error");
                    Menu.StartMenu();
                    break;
            }
        }
    }
}
}
