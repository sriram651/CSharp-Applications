namespace CovidVaccinationDrive
{
    public class VaccineDetails
    {
        /// <summary>
        /// Enumerated type Vaccine that contains the values of the Vaccine
        /// </summary>
        public enum Vaccine{Covishield, Covaccine}
        /// <summary>
        /// private field that stores the unique ID of the Vaccine in the integer format, auto increments
        /// </summary>
        private static int s_vaccineID = 100;
        /// <summary>
        /// Unique ID of the Vaccin in the string format initialized using the private field
        /// </summary>
        public string VaccineID { get;}
        /// <summary>
        /// Enum Vaccine type Property that has the Name of the Vaccine
        /// </summary>
        public Vaccine VaccineName { get; set; }
        /// <summary>
        /// Total number of vaccine doses that the user has taken
        /// </summary>
        /// <value>1/2/3</value>
        public int NoOfDoseAvailable { get; set; }
        /// <summary>
        /// Parameterized constructor that initializes all the properties and fields in the class
        /// </summary>
        /// <param name="vaccineName">Vaccine type property that stores the vaalue of the name of the Vaccine</param>
        /// <param name="dosesAvailable">Total number of doses that the user has taken</param>
        
        public  VaccineDetails(Vaccine vaccineName, int dosesAvailable)
        {
            ++s_vaccineID;
            VaccineID = "CID" + s_vaccineID;
            VaccineName = vaccineName;
            NoOfDoseAvailable = dosesAvailable;
        }

        public void vaccinate()
        {
            NoOfDoseAvailable--;
        }
    }
}