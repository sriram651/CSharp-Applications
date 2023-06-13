namespace ECommerceApplication
{
    public class CustomerDetails
    {
        private static int s_customerID = 1000;
        private double _walletBalance;
        public string CustomerID { get; }
        public string CustomerName { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerMailID { get; set; }
        public double CustomerWalletBalance { get{return _walletBalance;} }

        public CustomerDetails(string customerName, string customerCity, string customerPhoneNumber, string customerMailID, double customerWalletBalance)
        {
            ++s_customerID;
            CustomerID = "CID" + s_customerID;
            CustomerName = customerName;
            CustomerCity = customerCity;
            CustomerPhoneNumber = customerPhoneNumber;
            CustomerMailID = customerMailID;
            _walletBalance = customerWalletBalance;
        }

        public void RechargeWallet(double rechargeAmount)
        {
            _walletBalance += rechargeAmount;
        }

        public void Withdraw(double withdrawAmount)
        {
            _walletBalance -= withdrawAmount;
        }

    }
}