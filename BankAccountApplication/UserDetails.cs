using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    public class UserDetails
    {
        private static int s_customerID = 1000;
        public string RegistrationNumber { get; }
        public string UserName { get; set; }
        public string UserGender { get; set; }
        public string MailID { get; set; }
        public string ContactNumber { get; set; }
        public double AccountBalance { get; set; }
        public DateTime DOB { get; set; }
        public UserDetails(string customerName, string customerGender, string customerMailID, string customerPhoneNumber, double accBalance, DateTime dob)
        {
            s_customerID++;
            RegistrationNumber = "HDFC" + s_customerID;
            UserName = customerName;
            UserGender = customerGender;
            MailID = customerMailID;
            ContactNumber = customerPhoneNumber;
            AccountBalance = accBalance;
            DOB = dob;
        }

        public void Deposit()
        {
            Console.Clear();
            Console.WriteLine($"\n------------Money Deposit------------\n");
            double amountToDeposit;
            Console.WriteLine($"\nEnter Amount to Deposit: ");
            amountToDeposit = double.Parse(Console.ReadLine());
            AccountBalance += amountToDeposit;
            Console.WriteLine($"\nAmount Deposited Successfully!\n");
            Console.ReadKey();
        }

        public void Withdraw()
        {
            Console.Clear();
            Console.WriteLine($"\n------------Money Withdrawal------------\n");
            double amountToWithdraw;
            Console.WriteLine($"\nEnter Amount to Withdraw: ");
            amountToWithdraw = double.Parse(Console.ReadLine());
            
            // Check for Balance
            if (amountToWithdraw <= AccountBalance)
            {
                AccountBalance -= amountToWithdraw;
                Console.WriteLine($"\nWithdrawal of Rs.{amountToWithdraw} is Successful\n");
            }
            else
            {
                Console.WriteLine($"\nInsufficient Funds!");
            }
            Console.ReadKey();
        }

        public void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine($"\n------------Check Balance------------\n");
            Console.WriteLine($"\nAvailable Balance = Rs.{AccountBalance}\n");
            Console.ReadKey();
        }
    }
}