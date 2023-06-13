using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{
    
    public class Operations
    {
        static List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
        static EmployeeDetails currentEmployee = null;
        // MainMenuPage mainMenuPage = new MainMenuPage();
        string employeeName, employeeRole, teamName;
        DateTime doj = new DateTime();
        Gender employeeGender;
        WorkLocation employeeWorkLocation;
        int workingDays, leaveDays;
        public void EmployeeRegistration()
        {
            MainMenuPage.CompanyHeader();
            
            Console.WriteLine($"\n\t\t\t\t\t\t------------Employee Registration Form------------\n");
            
            Console.Write("\nEnter Employee Name: ");
            employeeName = Console.ReadLine();
            Console.Write("\nEnter Employee Role: ");
            employeeRole = Console.ReadLine();
            Console.Write("\nEnter Employee Gender(Male/Female/Others): ");
            employeeGender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("\nEnter Date of Joining: ");
            doj = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("\nEnter Team Name: ");
            teamName = Console.ReadLine();
            Console.Write("\nEnter Work Location(AnnaNagar/Kilpauk/WFH): ");
            employeeWorkLocation = Enum.Parse<WorkLocation>(Console.ReadLine(), true);
            Console.Write("\nEnter the Working Days Count: ");
            workingDays = Int32.Parse(Console.ReadLine());
            Console.Write("\nEnter Leave Count: ");
            leaveDays = Int32.Parse(Console.ReadLine());

            EmployeeDetails employee = new EmployeeDetails(employeeName, employeeRole, employeeGender,employeeWorkLocation, teamName, doj, workingDays, leaveDays);
            
            employeeList.Add(employee);
            Console.WriteLine($"\nYour Employee ID is {employee.EmployeeID}");

        }


        public void EmployeeLogin()
        {
            string employeeID;
            int userChoice;
            MainMenuPage.CompanyHeader();
            
            Console.WriteLine($"\n\t\t\t\t\t\t------------------Employee Login------------------\n");

            Console.WriteLine("\nEnter the Employee ID: ");
            employeeID = Console.ReadLine().ToLower();
            
            foreach(EmployeeDetails employeeDetail in employeeList)
            {
                if (employeeID == (employeeDetail.EmployeeID).ToLower())
                {
                    currentEmployee = employeeDetail;
                    break;
                }
            }

            if (currentEmployee != null)
            {

                do
                {
                    MainMenuPage.CompanyHeader();
                    Console.WriteLine($"\nWelcome {currentEmployee.EmployeeName},");
                    Console.WriteLine($"\n1. Calculate Salary");
                    Console.WriteLine($"\n2. Display Details");
                    Console.WriteLine($"\n3. Back to Main Menu");
                    Console.WriteLine($"\nEnter your choice: ");
                    userChoice = Int32.Parse(Console.ReadLine());

                    switch(userChoice)
                    {
                        case 1:
                            currentEmployee.CalculateSalary();
                            Console.WriteLine($"\nYour Salary has been Calculated, Check Details page!");
                            break;
                        case 2:
                            DisplayDetails();
                            break;
                        case 3:
                            break;
                        default:
                            Console.WriteLine($"\nInvalid Choice!");
                            break;                        
                    }
                    string enter = Console.ReadLine();
                }while (userChoice != 3);
            }

            else
            {
                Console.WriteLine($"\nEmployee not Found!");
                string enter = Console.ReadLine();
            }
        }


        // Function for Displaying Employee Details

        public void DisplayDetails()
        {
            MainMenuPage.CompanyHeader();
            Console.WriteLine($"\n\t\t\t\t\t---------------------Employee Details---------------------\n");
            Console.WriteLine($"\nEmployee ID: {currentEmployee.EmployeeID}");
            Console.WriteLine($"\nEmployee Name: {currentEmployee.EmployeeName}");
            Console.WriteLine($"\nEmployee Role: {currentEmployee.EmployeeRole}");
            Console.WriteLine($"\nEmployee Gender: {currentEmployee.EmployeeGender}");
            Console.WriteLine($"\nEmployee Team Name: {currentEmployee.EmployeeTeamName}");
            Console.WriteLine($"\nEmployee Work Location: {currentEmployee.EmployeeWorkLocation}");
            Console.WriteLine($"\nDate of Joining: {(currentEmployee.EmployeeDOJ).ToShortDateString()}");
            Console.WriteLine($"\nLeave Taken: {currentEmployee.LeaveDaysCount} Days");
            Console.WriteLine($"\nMonthly Salary: Rs.{currentEmployee.MonthlySalary}");
        }
    }
}