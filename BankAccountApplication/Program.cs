using System.Collections.Generic;
using System;
namespace BankAccountApplication;
class Program
{
    static Operations performOperation = new Operations();
    static MainMenu openMenu = new MainMenu();

    public static void Main(string[] args)
    {
        int choice;
        do
        {
            choice = openMenu.DisplayMainMenu();
            switch (choice)
            {
                case 1:
                    performOperation.GetUserDetails();
                    break;
                case 2:
                    performOperation.UserLogin();
                    break;
                case 3:
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($"Invalid Choice!");
                    Console.ReadLine();
                    break;
            }
        } while (choice != 3);
    }
}