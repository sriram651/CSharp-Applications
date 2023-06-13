using System;
namespace EmployeePayrollManagement;
class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        MainMenuPage mainMenuPage = new MainMenuPage();
        mainMenuPage.MainMenu();
    }
}