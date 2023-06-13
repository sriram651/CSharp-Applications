using System;

namespace AdventureParkManagement
{
    public class RideHistoryDetails
    {
        /// <summary>
        /// Private Static Field that Stores the Integer Value of the Unique ID of a Ride History and this Auto Increments
        /// </summary>
        private static int s_rideHistoryID = 5000;
        /// <summary>
        /// Stores the String value of the Unique ID of a ride History
        /// </summary>
        /// <value>"RHID" and concatenated by value from 5000</value>
        public string RideHistoryID { get; set; }
        /// <summary>
        /// Stores the User's Card ID in string type
        /// </summary>
        /// <value>CID and concatenated by values from 1001</value>
        public string CardID { get; set; }
        /// <summary>
        /// This property contains the ID of the raid stored as a string "RID" concatenated with the private field ride ID
        /// </summary>
        /// <value>"RID" followed by the Unique Identification Value from 201</value>
        public string RideID { get; set; }
        /// <summary>
        /// Enumerated Type RideType Stores the Type of the particular Ride
        /// </summary>
        public Ride RideType { get; set; }
        /// <summary>
        /// Stores the Date and time value of the Ride taken by the user
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// Parameterized Constructor of this class initializes the Properties of this class using the argument values
        /// </summary>
        /// <param name="cardID">String Parameter that stores the Customer's Unique Card ID</param>
        /// <param name="rideID">String Parameter that stores the Ride's Unique ID</param>
        /// <param name="rideType">Enumerated Ride Type Parameter that stores the Ride's Type(Dry/Water)</param>
        /// <param name="time"></param>
        public RideHistoryDetails(string cardID, string rideID, Ride rideType, DateTime time)
        {
            ++s_rideHistoryID;
            RideHistoryID = "RHID" + s_rideHistoryID;
            CardID = cardID;
            RideID = rideID;
            RideType = rideType;
            Time = time;
        }
    }
}
