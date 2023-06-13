using System.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityBillGenerator;
public static class MainMenuPage
{
    static Operations performOperations = new Operations();
    public static void MainMenu()
    {
        int userChoice;
        do
        {
            EBHeader();
            Console.WriteLine($"\n1. New Registration");
            Console.WriteLine($"\n2. Existing User Login");
            Console.WriteLine($"\n3. Exit");
            Console.WriteLine($"\nEnter your Choice:\n");
            userChoice = Int32.Parse(Console.ReadLine());

            switch(userChoice)
            {
                case 1:
                    performOperations.UserRegistration();
                    break;
                case 2:
                    performOperations.UserLogin();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine($"\nInvalid Choice!");
                    break;
            }
        }while(userChoice != 3);
    }


    // Header

    public static void EBHeader()
    {
        Console.Clear();
        Console.Write($"\n\t\t\t\t\t+-------------------------------------+");
        Console.Write($"\n\t\t\t\t\t|     Tamil Nadu Electricity Board    |");
        Console.Write($"\n\t\t\t\t\t+-------------------------------------+\n");   
    }
}