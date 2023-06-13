using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    public class MainMenu
    {
        // Display Menu Function
        public int DisplayMainMenu()
        {
            Console.Clear();

            int userInput;
            bool check;
            BankHeader();

            
            Console.WriteLine($"\n1. Registration\n");
            Console.WriteLine($"\n2. Login\n");
            Console.WriteLine($"\n3. Exit\n");
            Console.Write("\nEnter your Choice: ");
            check = Int32.TryParse(Console.ReadLine(), out userInput);

            while (!check)
            {
                Console.WriteLine($"Invalid Input!");
                Console.WriteLine($"Enter Again: ");
                check = Int32.TryParse(Console.ReadLine(), out userInput);
            }

            return userInput;
        }

        public void BankHeader()
        {
            Console.Clear();
            Console.WriteLine($"\n\t\t\t\t+------------------------------+");
            Console.WriteLine($"\t\t\t\t|          HDFC BANK           |");
            Console.WriteLine($"\t\t\t\t+------------------------------+");
        }
    }
}