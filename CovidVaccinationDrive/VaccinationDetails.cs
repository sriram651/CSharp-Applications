using System;

namespace CovidVaccinationDrive
{
    public class VaccinationDetails
    {
        /// <summary>
        /// private field of the Unique ID of the Vaccination History
        /// </summary>
        private static int s_vaccinationID = 1000;
        /// <summary>
        /// Unique String ID of the Vaccination history
        /// </summary>
        public string VaccinationID { get;}
        /// <summary>
        /// Unique ID of the User in string
        /// </summary>
        public string BeneficiaryID { get; set; }
        /// <summary>
        /// Unique ID of the Vaccine that the user took in string Format
        /// </summary>
        public string VaccineID { get; set; }
        /// <summary>
        /// Public Property that stores the total number of doses a user has taken
        /// </summary>
        /// <value>0/1/2/3</value>
        public int DoseNumber { get; set; }
        /// <summary>
        /// DateTime Property that tells when the user has been vaccinated
        /// </summary>
        public DateTime VaccinationDate { get; set; }
        /// <summary>
        /// Parameterized Constructor that initializes all the properties and fields in the Class
        /// </summary>
        /// <param name="beneficiaryID">Auto Initialized string that has the Unique ID of the user in string format</param>
        /// <param name="vaccineID">String format unique ID of the vaccine that the user has taken</param>
        /// <param name="doseNumber">Total number of doses that the user has taken so far</param>
        /// <param name="vaccinationDate">Date of vaccination for the user</param>

        public VaccinationDetails(string beneficiaryID, string vaccineID, int doseNumber, DateTime vaccinationDate)
        {
            ++s_vaccinationID;
            VaccinationID = "VID" + s_vaccinationID;
            BeneficiaryID = beneficiaryID;
            VaccineID = vaccineID;
            DoseNumber = doseNumber;
            VaccinationDate = vaccinationDate;
        }
    }
}