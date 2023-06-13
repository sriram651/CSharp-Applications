namespace CovidVaccinationDrive
{
    /// <summary>
    /// Enumerated type Gender that stores any of the 3 Values Male/Female/Others
    /// </summary>
    public enum Gender {Male, Female, Others}
    public class BeneficiaryDetails
    {
        /// <summary>
        /// Private Fields that auto increments and stores the Unique ID of the Person in integer format
        /// </summary>
        private static int s_regID = 1000;
        /// <summary>
        /// Public Property that stores the unique ID of the Beneficiary in the string format
        /// </summary>
        /// <value>BID1000</value>
        public string BeneficiaryID { get;}
        /// <summary>
        /// Public property that stores the Name of the beneficiary in the string format
        /// </summary>
        public string BenificiaryName { get; set; }
        /// <summary>
        /// Enumerated type Gender that contains the beneficiary's gender 
        /// </summary>
        /// <value>Male/Female/Others</value>
        public Gender BeneficiaryGender { get; set; }
        /// <summary>
        /// String Property that stores the mobile number of the beneficiary
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Has the string value of the City that the user lives in.
        /// </summary>
        /// <value></value>
        public string City { get; set; }
        /// <summary>
        /// Integer property that stores the Age of the Beneficiary
        /// </summary>
        public int BeneficiaryAge { get; set; }
        /// <summary>
        /// Parameterized Constructor that initializes the Properties of this class from the user input
        /// </summary>
        /// <param name="beneficiaryName">User input of the Beneficiary's Name</param>
        /// <param name="beneficiaryGender">User input of the Gender of the Beneficiary</param>
        /// <param name="mobileNumber">Mobile Number of the Beneficiary</param>
        /// <param name="city">City that the User lives in</param>
        /// <param name="beneficiaryAge">Input of the Age of the User</param>
        public BeneficiaryDetails(string beneficiaryName, Gender beneficiaryGender, string mobileNumber, string city, int beneficiaryAge)
        {
            ++s_regID;
            BeneficiaryID =  "BID" + s_regID;
            BenificiaryName = beneficiaryName;
            BeneficiaryGender = beneficiaryGender;
            MobileNumber = mobileNumber;
            City = city;
            BeneficiaryAge = beneficiaryAge;
        }
    }
}