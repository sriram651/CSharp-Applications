using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityBillGenerator
{
    public class UserDetails
    {
        private static int s_meterID = 1000;
        public string MeterID { get; set; }
        public string UserName { get; set; }
        public long UserContactNumber { get; set; }
        public string UserMailID { get; set; }
        public double UnitsUsed { get; set; }
        public double EBBill { get; set; }

        public UserDetails(string userName, long userPhoneNumber, string userMailID)
        {
            ++s_meterID;
            MeterID = "EB" + s_meterID;
            UserName = userName;
            UserContactNumber = userPhoneNumber;
            UserMailID = userMailID;
        }

        // Calculate EB Bill Method

        public void CalculateElectricityBill(double unitsUsed)
        {
            UnitsUsed = unitsUsed;
            EBBill = UnitsUsed * 5;
        }
    }
}