using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollManagement;
public enum Gender{Male, Female, Others}
public enum WorkLocation{AnnaNagar, Kilpauk, WFH}
    public class EmployeeDetails
    {
        private static int s_empID = 1000;
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeRole { get; set; }
        public string EmployeeTeamName { get; set; }
        public Gender EmployeeGender { get; set; }
        public WorkLocation EmployeeWorkLocation { get; set; }
        public DateTime EmployeeDOJ { get; set; }
        public int WorkingDaysCount { get; set; }
        public int LeaveDaysCount { get; set; }
        public double MonthlySalary { get; set; }

        // Parameterized Constructor to set the values of the employee details

        public EmployeeDetails(string employeeName, string employeeRole, Gender employeeGender, WorkLocation employeeWorkLocation, string  employeeTeamName, DateTime doj, int workingDaysCount, int leaveCount)
        {
            s_empID++;
            EmployeeID = "SF" + s_empID;
            EmployeeName = employeeName;
            EmployeeRole = employeeRole;
            EmployeeGender = employeeGender;
            EmployeeWorkLocation = employeeWorkLocation;
            EmployeeTeamName = employeeTeamName;
            EmployeeDOJ = doj;
            WorkingDaysCount = workingDaysCount;
            LeaveDaysCount = leaveCount;
        }

        // Salary Calculation
        public void CalculateSalary()
        {
            MonthlySalary = (WorkingDaysCount - LeaveDaysCount) * 500;
        }

    }