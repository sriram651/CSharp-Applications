using System;
using System.Collections.Generic;

namespace BankingApplication
{
    public enum Gender{Male, Female, Others}
    public class CustomerDetails
    {
        private double s_accountBalance;
        private static int s_accountNumber = 10000;
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public Gender CustomerGender { get; set; }
        public string MobileNumber { get; set; }
        public AccType AccountType { get; set; }
        public double Balance { get{return s_accountBalance;} set{s_accountBalance = value;} }
        public DateTime DOB { get; set; }
        public string CustomerMailID { get; set; }
        public string Address { get; set; }

        public CustomerDetails(string customerName, Gender customerGender, string mobileNumber, AccType accountType, double balance, DateTime dob, string mailID, string customerAddress)
        {
            ++s_accountNumber;
            AccountNumber = s_accountNumber;
            CustomerName = customerName;
            CustomerGender = customerGender;
            MobileNumber = mobileNumber;
            AccountType = accountType;
            Balance = balance;
            DOB = dob;
            CustomerMailID = mailID;
            Address = customerAddress;
        }

        public void Deposit(double depositAmount)
        {
            Balance += depositAmount;
        }

        public void Withdraw(double withdrawAmount)
        {
            Balance -= withdrawAmount;   
        }
    }
}