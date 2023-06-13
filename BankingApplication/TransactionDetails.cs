using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApplication
{
    public enum AccType{Default, SB, CA, RD, FD}
    public enum Transact{Default, Deposit, Withdraw, Transfer}
    public class TransactionDetails
    {
        private static int s_transactionID = 5000;
        public string TransactionID { get; set; }
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public AccType AccountType { get; set; }
        public Transact TransactionType { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        public TransactionDetails(int fromAccount, int toAccount, AccType accType, Transact transactionType, double amount, DateTime transactionDate)
        {
            ++s_transactionID;
            TransactionID = "TID" + s_transactionID;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            AccountType = accType;
            TransactionType = transactionType;
            Amount = amount;
            TransactionDate = transactionDate;
        }
    }
}