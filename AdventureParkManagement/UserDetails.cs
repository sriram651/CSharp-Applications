using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureParkManagement
{
    /// <summary>
    /// Class User Details Stores all the basic details of a registered User
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// Private Static Field that increments automatically when a new user is registered
        /// </summary>
        private static int s_cardID = 1000;
        /// <summary>
        /// Private Field that stores the User's Wallet Balance
        /// </summary>
        private double _walletBalance;
        /// <summary>
        /// Stores the Card ID of the User
        /// </summary>
        public string CardID { get; set; }
        /// <summary>
        /// Stores the Name of the Registered User
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// stores the Age of the registered user
        /// </summary>
        public int UserAge { get; set; }
        /// <summary>
        /// Stores a weight as double value of the registered User
        /// </summary>
        public double UserWeight { get; set; }
        /// <summary>
        /// Has the Total available balance in the user's Wallet
        /// </summary>
        public double UserWalletBalance { get{return _walletBalance;} }
        /// <summary>
        /// Stores the Phone Number of the User
        /// </summary>
        /// <value></value>
        public string UserPhoneNumber { get; set; }
        /// <summary>
        /// Parameterized Constructor that Initializes all the Values when the user inputs all the necessary values
        /// </summary>
        /// <param name="userName">Has the Input of the User Name</param>
        /// <param name="userAge">Contains the Age of the User</param>
        /// <param name="userWeight">Contains the Weight of the registered User</param>
        /// <param name="userWalletBalance">Contains the User's Wallet Balance</param>
        /// <param name="userPhoneNumber">Contains the User's Phone Number</param>
        public UserDetails(string userName, int userAge, double userWeight, double userWalletBalance, string userPhoneNumber)
        {
            ++s_cardID;
            CardID = "CID" + s_cardID;
            UserName = userName;
            UserAge = userAge;
            UserWeight = userWeight;
            _walletBalance = userWalletBalance;
            UserPhoneNumber = userPhoneNumber;
        }

        public void RechargeWallet(double rechargeAmount)
        {
            _walletBalance += rechargeAmount;
        }

        public void Withdraw(double amount)
        {
            _walletBalance -= amount;
        }
    }
}