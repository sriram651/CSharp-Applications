using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityBillGenerator;
public class Operations
{
    static List<UserDetails> userList = new List<UserDetails>();
    static UserDetails currentUser = null;
    long userPhoneNumber;
    int userChoice;
    double unitsUsed;
    string userMailID, userName, meterID;

    public void UserRegistration()
    {
        MainMenuPage.EBHeader();
        Console.WriteLine($"\n\t\t---------------------------------User Registration---------------------------------");
        
        Console.Write("\nEnter your Name: ");
        userName = Console.ReadLine();
        Console.Write("\nEnter your Contact Number: ");
        userPhoneNumber = long.Parse(Console.ReadLine());
        Console.Write("\nEnter your Mail ID: ");
        userMailID = Console.ReadLine();

        UserDetails user = new UserDetails(userName,userPhoneNumber,userMailID);

        userList.Add(user);
        Console.WriteLine($"\nNew User {userName} created Successfully!");
        
        Console.WriteLine($"\nYour Meter ID: {user.MeterID}");
        string enter = Console.ReadLine();
    }

    // User Login

    public void UserLogin()
    {
        MainMenuPage.EBHeader();
        Console.WriteLine($"\n\t\t---------------------------------User Login---------------------------------");
        Console.WriteLine($"\n\nEnter your Meter ID:");
        meterID = Console.ReadLine().ToLower();
        foreach(UserDetails user1 in userList)
        {
            if (meterID == user1.MeterID.ToLower())
            {
                currentUser = user1;
                break;
            }
        }
        
        if(currentUser != null)
        {
            do
            {
                MainMenuPage.EBHeader();
                Console.WriteLine($"\nWelcome, {currentUser.UserName}!");
                Console.WriteLine($"\n1. Calculate Electricity Bill");
                Console.WriteLine($"\n2. Display User Details");
                Console.WriteLine($"\n3. Exit");
                Console.WriteLine($"\nEnter your Choice:\n");
                userChoice = Int32.Parse(Console.ReadLine());

                switch(userChoice)
                {
                    case 1:
                        Console.WriteLine($"\nEnter the total Units Used:");
                        unitsUsed = double.Parse(Console.ReadLine());
                        currentUser.CalculateElectricityBill(unitsUsed);
                        Console.WriteLine($"\nYour Electricity Bill has been Calculated, Check Details Page.");
                        break;
                    case 2:
                        displayUserDetails();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine($"\nInvalid Choice!");
                        break;
                }
                string enter = Console.ReadLine();
            }while(userChoice != 3);
            currentUser = null;
        }

        else
        {
            Console.WriteLine($"\nUser Not Found!");
            string enter = Console.ReadLine();
        }
    }

    // Display User Details Function

    public void displayUserDetails()
    {
        MainMenuPage.EBHeader();
        Console.WriteLine($"\n\t\t---------------------------------User Details---------------------------------");
        Console.WriteLine($"\nMeter ID: {currentUser.MeterID}");
        Console.WriteLine($"\nUser Name: {currentUser.UserName}");
        Console.WriteLine($"\nContact Number: {currentUser.UserContactNumber}");
        Console.WriteLine($"\nMail ID: {currentUser.UserMailID}");
        Console.WriteLine($"\nUnits Used: {currentUser.UnitsUsed}");
        Console.WriteLine($"\nTotal Amount to be Paid for {currentUser.UnitsUsed} units @Rs.5.00 per Unit = Rs.{currentUser.EBBill}\n");            
    }
}