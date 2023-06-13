using System;

namespace CollegeAdmission;
public enum AdmissionStatus{Admitted, Cancelled}
public class AdmissionDetails
{
    private static int s_admissionID = 1000;
    public string AdmissionID { get; }
    public string DepartmentID { get; set; }
    public string StudentID { get; set; }
    public DateTime AdmissionDate { get; set; }
    public AdmissionStatus StudentAdmissionStatus { get; set; }
    public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus studentAdmissionStatus)
    {
        ++s_admissionID;
        AdmissionID = "AID" + s_admissionID;
        DepartmentID = departmentID;
        StudentID = studentID;
        AdmissionDate = admissionDate;
        StudentAdmissionStatus = studentAdmissionStatus;
    }
}