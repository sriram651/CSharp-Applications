using System.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class Patient
    {
        public enum Gender{Male, Female}
        private static int s_patientID = 0;
        public int PatientID { get; set; }
        public string Password { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public Gender UserGender { get; set; }
        public Patient(string patientName, string password, int age, Gender gender)
        {
            ++s_patientID;
            PatientID = s_patientID;
            PatientName = patientName;
            Password = password;
            Age = age;
            UserGender = gender;
        }
    }
}