using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    public class Operations
    {
        static List<UserDetails> customerList = new List<UserDetails>();
        static UserDetails currentUser = null;

        // Get User details function for registration

        public void GetUserDetails()
        {

            string inputName, userGender, contactNumber, userMailID;
            double accountBalance;
            DateTime dob = new DateTime();

            Console.Clear();

            Console.WriteLine($"\n----------------User Registration----------------\n");

            // Get Customer Details

            Console.Write("\nEnter Customer Name: ");
            inputName = Console.ReadLine();
            Console.Write("\nEnter Customer Gender: ");
            userGender = Console.ReadLine();
            Console.Write("\nEnter Date of Birth (dd/MM/yyyy): ");
            dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("\nEnter Mail ID: ");
            userMailID = Console.ReadLine();
            Console.Write("\nEnter Contact Number: ");
            contactNumber = Console.ReadLine();
            Console.Write("\nEnter Account Balance: ");
            accountBalance = double.Parse(Console.ReadLine());

            // Create Object for the Class
            UserDetails customer = new UserDetails(inputName, userGender, userGender, contactNumber, accountBalance, dob);

            // Add Object to List
            customerList.Add(customer);
            Console.Write($"\nCustomer ID: {customer.RegistrationNumber}");
        }

        // Login Function

        public void UserLogin()
        {

            string customerID;
            int userChoice;
            Console.Clear();

            Console.WriteLine($"\n----------------User Login----------------\n");

            Console.Write("\nEnter Customer ID: ");
            customerID = Console.ReadLine().ToLower();

            // Validating Customer ID
            foreach (UserDetails userDetail in customerList)
            {
                if (customerID == userDetail.RegistrationNumber.ToLower())
                {
                    currentUser = userDetail;
                    break;
                }
            }

            // Continue to Banking Operations only if the Customer ID was found
            if (currentUser != null)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine($"\nWelcome {currentUser.UserName}!");
                    Console.WriteLine($"\n1. Deposit");
                    Console.WriteLine($"\n2. Withdraw");
                    Console.WriteLine($"\n3. Check Balance");
                    Console.WriteLine($"\n4. Back to Main Menu");
                    Console.Write($"\nEnter your Choice: ");
                    userChoice = Int32.Parse(Console.ReadLine());

                    switch (userChoice)
                    {
                        case 1:
                            currentUser.Deposit();
                            break;
                        case 2:
                            currentUser.Withdraw();
                            break;
                        case 3:
                            currentUser.CheckBalance();
                            break;
                        case 4:
                            currentUser = null;
                            break;
                        default:
                            Console.WriteLine($"\nInvalid Choice!");
                            break;
                    }
                } while (userChoice != 4);
            }

            // If Entered Customer ID was Not found
            else
            {
                Console.WriteLine($"User Not Found!");
            }
            string enter =  Console.ReadLine();
        }
    }
}