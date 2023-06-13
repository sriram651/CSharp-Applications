using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollManagement;
public  class MainMenuPage
{
    static Operations performOperation = new Operations();
    int userChoice;
    public void MainMenu()
    {
        do
        {
            CompanyHeader();
            Console.WriteLine($"\n1. Employee Registration");
            Console.WriteLine($"\n2. Employee Login");
            Console.WriteLine($"\n3. Exit");
            Console.Write("\nEnter your Choice: ");
            userChoice = Int32.Parse(Console.ReadLine());

            switch(userChoice)
            {
                case 1: 
                    performOperation.EmployeeRegistration();
                    break;
                case 2:
                    performOperation.EmployeeLogin();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine($"\nInvalid Choice!");
                    break;
            }
        }while (userChoice != 3);
        
    }

    // Company Header Function

    public static void CompanyHeader()
    {
        Console.Clear();
        Console.WriteLine($"\t\t\t\t\t\t+------------------------------------+");
        Console.WriteLine($"\t\t\t\t\t\t|         Syncfusion Software        |");
        Console.WriteLine($"\t\t\t\t\t\t+------------------------------------+\n");
    }
}