using System;
using System.Collections.Generic;
namespace AdventureParkManagement
{
    public class Operations
    {
        static List<UserDetails> userList = new List<UserDetails>();
        static List<RideDetails> rideDetailsList = new List<RideDetails>();
        static List<RideHistoryDetails> rideHistoryDetailsList = new List<RideHistoryDetails>();
        static UserDetails currentUser = null;
        static RideDetails currentRide = null;
        static RideHistoryDetails newRideHistory = null;
        public static void MainMenu()
        {
            bool choiceCheck;
            int userChoice;
            do
            {
                Console.WriteLine($"\n1. User Registration");
                Console.WriteLine($"\n2. User Login");
                Console.WriteLine($"\n3. Exit");
                Console.WriteLine($"\nEnter your choice: ");
                choiceCheck = Int32.TryParse(Console.ReadLine(), out userChoice);
                while(!choiceCheck)
                {
                    Console.WriteLine($"\nWrong Input! Enter an Integer: ");
                    choiceCheck = Int32.TryParse(Console.ReadLine(), out userChoice);
                }
                switch(userChoice)
                {
                    case 1:
                        UserRegistration();
                        break;
                    case 2:
                        UserLogin();
                        break;
                    case 3:
                        Console.WriteLine($"\nExit Successfull!");
                        break;
                    default:
                        Console.WriteLine($"\nInvalid Choice!");
                        break;
                }
            }while(userChoice != 3);
        }

        // UserRegistration Method to let the User Register themselves in the Adventure Park
        public static void UserRegistration()
        {
            string userName, userPhoneNumber;
            int userAge;
            bool checkInput;
            double userWeight, userwalletBalance;
            Console.WriteLine($"\nEnter your Name:");
            userName = Console.ReadLine();
            Console.WriteLine($"\nEnter your Age:");
            checkInput = Int32.TryParse(Console.ReadLine(), out userAge);
            while(!checkInput)
            {
                Console.WriteLine($"\nEnter age in Number: ");
                checkInput = Int32.TryParse(Console.ReadLine(), out userAge);
            }
            Console.WriteLine($"\nEnter your Weight:");
            checkInput = double.TryParse(Console.ReadLine(), out userWeight);
            while(!checkInput)
            {
                Console.WriteLine($"\nEnter Weight in Number: ");
                checkInput = double.TryParse(Console.ReadLine(), out userWeight);
            }
            Console.WriteLine($"\nEnter your Wallet Balance:");
            checkInput = double.TryParse(Console.ReadLine(), out userwalletBalance);
            while(!checkInput)
            {
                Console.WriteLine($"\nEnter Weight in Number: ");
                checkInput = double.TryParse(Console.ReadLine(), out userwalletBalance);
            }
            Console.WriteLine($"\nEnter your Phone Number: ");
            userPhoneNumber = Console.ReadLine();
            
            // Storing all the values in the UserDetails class by calling the constructor
            UserDetails user = new UserDetails(userName, userAge, userWeight, userwalletBalance, userPhoneNumber);
            userList.Add(user);

            // Displaying the Card ID
            Console.WriteLine($"\nNew User Registered Successfully!");
            Console.WriteLine($"\nYour Card ID is {user.CardID}");
            
        }

        // User Login Method to let the user to enjoy the adventure park
        public static void UserLogin()
        {
            string cardID;
            bool flag = false;
            
            Console.WriteLine($"\nEnter Card ID:");
            cardID = Console.ReadLine();
            foreach(UserDetails user in userList)
            {
                if (cardID.ToUpper() == user.CardID)
                {
                    flag = true;
                    currentUser = user;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"\nInvalid User ID!");
            }
            else
            {
                SubMenu();
            }
        }
            
        public static void SubMenu()
        {
            char userChoice;
            bool checkChoice;
            do
            {
                Console.WriteLine($"\na. Take Ride");
                Console.WriteLine($"\nb. Wallet Recharge");
                Console.WriteLine($"\nc. Ride History");
                Console.WriteLine($"\nd. Wallet Balance");
                Console.WriteLine($"\ne. Log Out");
                Console.WriteLine($"\nEnter your Choice:");
                checkChoice = char.TryParse(Console.ReadLine(), out userChoice);
                while(!checkChoice)
                {
                    Console.WriteLine($"\nEnter a Valid Character:");
                    checkChoice = char.TryParse(Console.ReadLine(), out userChoice);
                }
                switch(userChoice)
                {
                    case 'a':
                        TakeRide();
                        break;
                    case 'b':
                        RechargeWallet();
                        break;
                    case 'c':
                        RideHistory();
                        break;
                    case 'd':
                        DisplayWalletBalance();
                        break;
                    case 'e':
                        Console.WriteLine($"\nLog Out Successful!");
                        break;
                    default:
                        Console.WriteLine($"\nInvalid Choice!");
                        break;
                }
                Console.ReadLine();
            }while(userChoice != 'e');
            currentUser = null;
        }

        public static void TakeRide()
        {
            DisplayRideDetails();
            RideHistoryDetails latestRide = null;
            Console.WriteLine($"\nSelect the Ride by entering the Ride ID:");
            string rideID = Console.ReadLine().ToUpper();
            foreach(RideDetails ride in rideDetailsList)
            {
                if (rideID.ToUpper() == ride.RideID)
                {
                    currentRide = ride;
                    break;
                }
            }
            foreach(RideHistoryDetails rideHistory in rideHistoryDetailsList)
            {
                latestRide = rideHistory;
            }
            
            if (currentRide != null)
            {
                if(currentRide.RideType == Ride.Dry)
                {
                    if (latestRide != null && latestRide.RideType == Ride.Water)
                    {
                        Console.WriteLine($"\nYou have attended a water game previously. Due to safety reason, you are not eligible to take this ride");
                    }
                    else
                    {
                        if(currentUser.UserAge >= currentRide.MinimumAgeLimit && currentUser.UserAge <= currentRide.MaximumAgeLimit)
                        {
                            if (currentUser.UserWalletBalance >= currentRide.RidePrice)
                            {
                                currentUser.Withdraw(currentRide.RidePrice);
                                newRideHistory = new RideHistoryDetails(currentUser.CardID, currentRide.RideID, currentRide.RideType, DateTime.Now);
                                rideHistoryDetailsList.Add(newRideHistory);
                                Console.WriteLine($"\nYou have successfully opted for the selected ride!");
                                Console.WriteLine($"\nYour Updated Wallet Balance: Rs.{currentUser.UserWalletBalance}");
                            }
                            else
                            {
                                Console.WriteLine($"\nNot Enough Wallet Balance, Please Recharge and Come Back!");
                            }
                        }
                    }
                }
                else
                {
                    if (currentUser.UserWeight >= currentRide.MinimumWeight && currentUser.UserWeight <= currentRide.MaximumWeight)
                    {
                        if (currentUser.UserWalletBalance >= currentRide.RidePrice)
                        {
                            currentUser.Withdraw(currentRide.RidePrice);
                            newRideHistory = new RideHistoryDetails(currentUser.CardID, currentRide.RideID, currentRide.RideType, DateTime.Now);
                            rideHistoryDetailsList.Add(newRideHistory);
                            Console.WriteLine($"\nYou have successfully opted for the selected ride!");
                        }
                        else
                        {
                            Console.WriteLine($"\nNot Enough Wallet Balance, Please Recharge and Come Back!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nYou cannot take selected ride due to weight limit");
                    }
                        
                }
            }
            else
            {
                Console.WriteLine($"\nInvalid Ride ID!");
            }
            Console.ReadLine();        
        }

        public static void RechargeWallet()
        {
            double rechargeAmount;
            bool checkInput;
            Console.WriteLine($"\nEnter the Amount to recharge:");
            checkInput = double.TryParse(Console.ReadLine(), out rechargeAmount);
            while(!checkInput)
            {
                Console.WriteLine($"\nEnter amount in number only:");
                checkInput = double.TryParse(Console.ReadLine(), out rechargeAmount);
            }
            currentUser.RechargeWallet(rechargeAmount);
            Console.WriteLine($"\nYour Updated Wallet Balance: Rs.{currentUser.UserWalletBalance}");
        }

        // Ride History Method
        public static void RideHistory()
        {
            Console.WriteLine($"\nRide History ID\t\tRide ID\t\tCard ID\t\tRide Type\t\tTime of Ride");
            Console.WriteLine($"----------------------------------------------------------------------------------------------------");
            
            foreach(RideHistoryDetails rideHistory in rideHistoryDetailsList)
            {
                if (rideHistory.CardID == currentUser.CardID)
                {
                    Console.WriteLine($"{rideHistory.RideHistoryID}\t\t{rideHistory.RideID}\t\t{rideHistory.CardID}\t\t{rideHistory.RideType}\t\t\t{rideHistory.Time.TimeOfDay}");
                    Console.WriteLine($"----------------------------------------------------------------------------------------------------");
                }
            }
        }

        // Show Current logged in User's Wallet balance
        public static void DisplayWalletBalance()
        {
            Console.WriteLine($"\nYour Wallet Balance is Rs.{currentUser.UserWalletBalance}");
        }

        public static void DisplayRideDetails()
        {
            Console.WriteLine("+---------+-------------+--------+---------+---------+------------+------------+------+");
            Console.WriteLine("| Ride ID |  Ride Name  |  Type  | Min Age | Max Age | Min Weight | Max Weight | Cost |");
            Console.WriteLine("+---------+-------------+--------+---------+---------+------------+------------+------+");
            foreach(RideDetails ride in rideDetailsList)
            {
                Console.WriteLine("| {0, -7} | {1, -11} | {2, -6} | {3, -7} | {4, -7} | {5, -10} | {6, -10} | {7, -4} |", ride.RideID, ride.RideName, ride.RideType, ride.MinimumAgeLimit, ride.MaximumAgeLimit, ride.MinimumWeight, ride.MaximumWeight, ride.RidePrice);
                Console.WriteLine("+---------+-------------+--------+---------+---------+------------+------------+------+");
            }
        }

        // Adding Default Values
        public static void AddDefaultValues()
        {
            // Adding Default Ride Details
            RideDetails ride = new RideDetails("Dry Game", Ride.Dry, (int)5, (int)10, (double)12, (double)20, (double)50);
            rideDetailsList.Add(ride);
            // rideDetailsList.Add(new RideDetails("Dry Game", Ride.Dry, (int)5, (int)10, (double)12, (double)20, (double)50));
            rideDetailsList.Add(new RideDetails("Dry Game", Ride.Dry, (int)10, (int)17, (double)20, (double)35, (double)100));
            rideDetailsList.Add(new RideDetails("Dry Game", Ride.Dry, (int)18, (int)65, (double)35, (double)90, (double)200));
            rideDetailsList.Add(new RideDetails("Water Game", Ride.Water, (int)5, (int)10, (double)12, (double)20, (double)50));
            rideDetailsList.Add(new RideDetails("Water Game", Ride.Water, (int)10, (int)17, (double)20, (double)35, (double)100));
            rideDetailsList.Add(new RideDetails("Water Game", Ride.Water, (int)18, (int)65, (double)35, (double)90, (double)200));

            // Adding Default User Details
            userList.Add(new UserDetails("User1", 5, 12, 500, "9999999999"));
            userList.Add(new UserDetails("User2", 13, 39, 300, "8833884488"));
            userList.Add(new UserDetails("User3", 45, 80, 600, "7656635533"));
            userList.Add(new UserDetails("User4", 30, 100, 100, "8765774985"));
            userList.Add(new UserDetails("User5", 20, 30, 1000, "9857646543"));
        }
    }
}
