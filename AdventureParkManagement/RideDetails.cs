using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureParkManagement
{
    /// <summary>
    /// Enumerated Type Ride Stores 3 Values of the Type of the ride
    /// </summary>
    public enum Ride {Default, Water, Dry}
    public class RideDetails
    {
        /// <summary>
        /// Private Static Field that stores the Unique ID of the Ride Detail and Also Auto Increments
        /// </summary>
        private static int s_rideID = 200;
        /// <summary>
        /// This property contains the ID of the raid stored as a string "RID" concatenated with the private field ride ID
        /// </summary>
        /// <value>"RID" followed by the Unique Identification Value from 201</value>
        public string RideID { get; set; }
        /// <summary>
        /// Stores and returns the Name of the Ride in String
        /// </summary>
        /// <value>Dry Game/ Water Game</value>
        public string RideName { get; set; }
        /// <summary>
        /// Enumerated Type RideType Stores the Type of the particular Ride
        /// </summary>
        public Ride RideType = Ride.Default;
        /// <summary>
        /// The Minimum Age Limit to Ride on a given Ride
        /// </summary>
        /// <value>Integer Value</value>
        public int MinimumAgeLimit { get; set; }
        /// <summary>
        /// The Maximum Age Limit to Ride on a given Ride
        /// </summary>
        /// <value>Integer Value</value>
        public int MaximumAgeLimit { get; set; }
        /// <summary>
        /// The Minimum Weight Limit to Ride on a given Ride
        /// </summary>
        /// <value>Integer Value</value>
        public double MinimumWeight { get; set; }
        /// <summary>
        /// The Minimum Weight Limit to Ride on a given Ride
        /// </summary>
        /// <value>Integer Value</value>
        public double MaximumWeight { get; set; }
        /// <summary>
        /// The Cost of riding that particular Ride
        /// </summary>
        public double RidePrice { get; set; }
        /// <summary>
        /// Parameterized constructor that initializes the Values of the properties in the Ride Details Class
        /// </summary>
        /// <param name="rideName">Given Input of the Ride Name</param>
        /// <param name="rideType">Given Input of the type of the ride</param>
        /// <param name="minimumAgeLimit">Given Input of the Minimum Age Limit to ride on that particular Ride</param>
        /// <param name="maximumAgeLimit">Given Input of the Maximum Age Limit to ride on that particular Ride</param>
        /// <param name="minimumWeight">Given Input of the Minimum Weight Limit to ride on that particular Ride</param>
        /// <param name="maximumWeight">Given Input of the Minimum Weight Limit to ride on that particular Ride</param>
        /// <param name="ridePrice">The total cost to enter a particular ride</param>
        public RideDetails(string rideName, Ride rideType, int minimumAgeLimit, int maximumAgeLimit, double minimumWeight, double maximumWeight, double ridePrice)
        {
            ++s_rideID;
            RideID = "RID" + s_rideID;
            RideName = rideName;
            RideType = rideType;
            MinimumAgeLimit = minimumAgeLimit;
            MaximumAgeLimit = maximumAgeLimit;
            MinimumWeight = minimumWeight;
            MaximumWeight = maximumWeight;
            RidePrice = ridePrice;
        }
    }
}
