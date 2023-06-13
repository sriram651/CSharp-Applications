using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class Doctor
    {
        private static int s_doctorID = 0;
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string Department { get; set; }
        public Doctor(string doctorName, string department)
        {
            ++s_doctorID;
            DoctorID = s_doctorID;
            DoctorName = doctorName;
            Department = department;
        }
    }
}