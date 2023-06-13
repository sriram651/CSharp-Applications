using System;
using System.Collections.Generic;

namespace BankingApplication
{
    public static class Operations
    {
        static List<CustomerDetails> customerList = new List<CustomerDetails>();
        static List<TransactionDetails> transactionList = new List<TransactionDetails>();
        static CustomerDetails currentCustomer = null;
        static CustomerDetails currentCustomer2 = null;
        
        public static void MainMenu()
        {
            int userChoice;
            do
            {
                Console.WriteLine($"\n-------------------------Main Menu-------------------------\n");
                Console.WriteLine($"\n1. Account Creation\n2. Login\n3. Exit\nEnter Your Choice:");
                userChoice = Int32.Parse(Console.ReadLine());
                switch(userChoice)
                {
                    case 1:
                    {
                        AccountCreation();
                        break;
                    }
                    case 2:
                    {
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine($"\n------------------Exiting Main Menu------------------\n");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine($"\nInvalid Choice!");
                        break;
                    }
                }
            }while(userChoice != 3);
        }

        public static void AccountCreation()
        {
            Console.WriteLine($"\n--------------------Account Creation--------------------\n");
            Console.WriteLine($"\nEnter your Name:");
            string userName = Console.ReadLine();
            Console.WriteLine($"\nEnter your Gender(Male/Female/Others):");
            Gender userGender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine($"\nEnter your Mobile Number:");
            string mobileNumber = Console.ReadLine();
            Console.WriteLine($"\nEnter Account Type(SB/CA/RD/FD):");
            AccType userAccType = Enum.Parse<AccType>(Console.ReadLine(), true);
            Console.WriteLine($"\nEnter the Account Balance:");
            double balance = double.Parse(Console.ReadLine());
            Console.WriteLine($"\nEnter Date of Birth(dd/MM/yyyy):");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.WriteLine($"\nEnter Mail ID:");
            string userMailID = Console.ReadLine();
            Console.WriteLine($"\nEnter Address:");
            string userAddress = Console.ReadLine();
            
            CustomerDetails customer = new CustomerDetails(userName, userGender, mobileNumber, userAccType, balance, dob, userMailID, userAddress);
            customerList.Add(customer);

            Console.WriteLine($"\nYour Account Number is {customer.AccountNumber}");
            
        }
        
        public static void Login()
        {
            Console.WriteLine($"\n--------------------Login--------------------\n");
            Console.WriteLine($"\nEnter your Account Number: ");
            int inputAccountNumber = Int32.Parse(Console.ReadLine());
            bool flag = false;
            foreach(CustomerDetails customer in customerList)
            {
                if (inputAccountNumber == customer.AccountNumber)
                {
                    flag = true;
                    currentCustomer = customer;
                    break;
                }
            }
            if(!flag)
            {
                Console.WriteLine($"\nInvalid Account Number!");
            }
            else
            {
                Console.WriteLine($"\nLogged in Successfully!");
                SubMenu();
            }
        }
        
        public static void SubMenu()
        {
            int userChoice;
            do
            {
                Console.WriteLine($"\n-------------------Sub Menu-------------------\n");
                Console.WriteLine($"\n1. Show Account Details");
                Console.WriteLine($"\n2. Deposit");
                Console.WriteLine($"\n3. Withdraw");
                Console.WriteLine($"\n4. Show Balance");
                Console.WriteLine($"\n5. Transfer Amount");
                Console.WriteLine($"\n6. Show Transaction History");
                Console.WriteLine($"\n7. Exit");
                Console.WriteLine($"\nEnter your choice:");
                userChoice = Int32.Parse(Console.ReadLine());

                switch(userChoice)
                {
                    case 1:
                    {
                        ShowAccountDetails();
                        break;
                    }
                    case 2:
                    {
                        Deposit();
                        break;
                    }
                    case 3:
                    {
                        Withdraw();
                        break;
                    }
                    case 4:
                    {
                        ShowBalance();
                        break;
                    }
                    case 5:
                    {
                        Transfer();
                        break;
                    }
                    case 6:
                    {
                        ShowTransactionHistory();
                        break;
                    }
                    case 7:
                    {
                        Console.WriteLine($"\n---------------Exiting Sub Menu---------------");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine($"\nInvalid Choice!");
                        break;
                    }
                }
            }while(userChoice != 7);
        }

        public static void ShowAccountDetails()
        {
            Console.WriteLine($"\n---------------Show Account Details---------------");
            Console.WriteLine($"\nAccount Number: {currentCustomer.AccountNumber}");
            Console.WriteLine($"\nName: {currentCustomer.CustomerName}");
            Console.WriteLine($"\nGender: {currentCustomer.CustomerGender}");
            Console.WriteLine($"\nMail ID: {currentCustomer.CustomerMailID}");
            Console.WriteLine($"\nMobile Number: {currentCustomer.MobileNumber}");
            Console.WriteLine($"\nAccount Type: {currentCustomer.AccountType}");
            Console.WriteLine($"\nAddress: {currentCustomer.Address}");
            Console.WriteLine($"\nDate of Birth: {currentCustomer.DOB}");
            Console.WriteLine($"\nBalance: {currentCustomer.Balance}\n");
        }


        public static void Deposit()
        {
            Console.WriteLine($"\n------------------Deposit------------------\n");
            Console.WriteLine($"\nEnter the amount to deposit:");
            double depositAmount = Double.Parse(Console.ReadLine());
            currentCustomer.Deposit(depositAmount);
            TransactionDetails transaction = new TransactionDetails(currentCustomer.AccountNumber, currentCustomer.AccountNumber, currentCustomer.AccountType, Transact.Deposit, depositAmount, DateTime.Now);
            transactionList.Add(transaction);
            Console.WriteLine($"\nTransaction Successful!");
            Console.WriteLine($"\nYour Updated Account Balance is Rs.{currentCustomer.Balance}");
            Console.WriteLine($"\nYour Transaction ID is {transaction.TransactionID}\n");
        }


        public static void Transfer()
        {
            Console.WriteLine($"\n------------------Wire Transfer------------------\n");
            Console.WriteLine($"\nEnter the Payee's Account Number:");
            int payeeAccountNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"\nEnter the Payee's Account Type:");
            AccType accountType = Enum.Parse<AccType>(Console.ReadLine(), true);
            foreach (CustomerDetails customer in customerList)
            {
                if(payeeAccountNumber == customer.AccountNumber && accountType == customer.AccountType)
                {
                    currentCustomer2 = customer;
                    break;
                }   
            }
            if (currentCustomer2 != null)
            {
                Console.WriteLine($"\nEnter the Amount to be Transferred: ");
                double transferAmount = double.Parse(Console.ReadLine());
                if (transferAmount <= currentCustomer.Balance)
                {
                    currentCustomer.Withdraw(transferAmount);
                    currentCustomer2.Deposit(transferAmount);
                    TransactionDetails transaction = new TransactionDetails(currentCustomer.AccountNumber, currentCustomer2.AccountNumber, accountType, Transact.Transfer, transferAmount, DateTime.Now);
                    transactionList.Add(transaction);
                    Console.WriteLine($"\nTransaction Successful!");
                    Console.WriteLine($"\nYour Current Balance is Rs.{currentCustomer.Balance}");
                    Console.WriteLine($"\nThe Transaction ID for this transfer is {transaction.TransactionID}\n");
                }
            }
            else
            {
                Console.WriteLine($"\nPayee's Account Details do not match with our Database, Kindly Check the entered values!");
            }
        }


        
        public static void Withdraw()
        {
            Console.WriteLine($"\n----------------------Withdraw----------------------\n");
            Console.WriteLine($"\nEnter the amount to withdraw:");
            double withdrawAmount = double.Parse(Console.ReadLine());
            if (withdrawAmount <= currentCustomer.Balance)
            {
                currentCustomer.Withdraw(withdrawAmount);
                TransactionDetails transaction = new TransactionDetails(currentCustomer.AccountNumber, currentCustomer.AccountNumber, currentCustomer.AccountType, Transact.Withdraw, withdrawAmount, DateTime.Now);
                transactionList.Add(transaction);
                Console.WriteLine($"\nTransaction Successful!");
                Console.WriteLine($"\nYour Updated Account Balance is Rs.{currentCustomer.Balance}");
            }
            else
            {
                Console.WriteLine($"\nInsufficient Account Balance!");
            }
        }


        public static void ShowBalance()
        {
            Console.WriteLine($"\n---------------Show Balance---------------\n");
            Console.WriteLine($"\nYour Account Balance is Rs. {currentCustomer.Balance}\n");
        }


        public static void ShowTransactionHistory()
        {
            Console.WriteLine($"\n---------------Show Transaction History---------------\n");
            foreach(TransactionDetails transaction in transactionList)
            {
                if (transaction.FromAccount == currentCustomer.AccountNumber || transaction.ToAccount == currentCustomer.AccountNumber)
                {
                    Console.WriteLine($"\nTransaction ID: {transaction.TransactionID}");
                    Console.WriteLine($"\nFrom Account: {transaction.FromAccount}");
                    Console.WriteLine($"\nTo Account: {transaction.ToAccount}");
                    Console.WriteLine($"\nAccount Type: {transaction.AccountType}");
                    Console.WriteLine($"\nAmount: {transaction.Amount}");
                    Console.WriteLine($"\nTransaction Type: {transaction.TransactionType}");
                    Console.WriteLine($"\nTransaction Date: {transaction.TransactionDate}\n");
                }
            }
        }


        public static void AddDefaultValues()
        {
            // Customer Details Default
            CustomerDetails customer1 = new CustomerDetails("Ravi", Gender.Male, "995699", AccType.SB, 10000, new DateTime(1999,11,11), "ravi@mail.com", "Theni");
            customerList.Add(customer1);
            CustomerDetails customer2 = new CustomerDetails("Baskaran", Gender.Male, "959558", AccType.SB, 10000, new DateTime(1999,11,11), "baskar@mail.com", "Chennai");
            customerList.Add(customer2);
            CustomerDetails customer3 = new CustomerDetails("Ravi", Gender.Male, "995699", AccType.CA, 50000, new DateTime(1999,11,11), "ravi@mail.com", "Theni");
            customerList.Add(customer3);

            // Transaction Details Default
            TransactionDetails transaction1 = new TransactionDetails(10001, 10001, AccType.SB, Transact.Deposit, 10000, new DateTime(2022,11,10));
            transactionList.Add(transaction1);
            TransactionDetails transaction2 = new TransactionDetails(10001, 10002, AccType.SB, Transact.Transfer, 5000, new DateTime(2022, 11, 10));
            transactionList.Add(transaction2);
            TransactionDetails transaction3 = new TransactionDetails(10002, 10003, AccType.CA, Transact.Transfer, 6000, new DateTime(2022,10,15));
            transactionList.Add(transaction3);
            TransactionDetails transaction4 = new TransactionDetails(10002, 10002, AccType.SB, Transact.Withdraw, 1000, new DateTime(2022, 10, 17));
            transactionList.Add(transaction4);
        }
    }
}