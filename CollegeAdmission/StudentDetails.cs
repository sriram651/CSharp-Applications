using System;

namespace CollegeAdmission;
public enum Gender{Unknown, Male, Female, Transgender}
public class StudentDetails
{
    private static int s_studentID = 3000;
    public string StudentID { get;}
    public string StudentName { get; set; }
    public string  FatherName { get; set; }
    public DateTime DOB { get; set; }
    public Gender StudentGender { get; set; }
    public double PhysicsMark { get; set; }
    public double ChemistryMark { get; set; }
    public double MathsMark { get; set; }


    // Constructor
    public StudentDetails(string studentName, string fatherName, DateTime dob, Gender studentGender, double physicsMark, double chemistryMark, double mathsMark)
    {
        ++s_studentID;
        StudentID = "SF" + s_studentID;
        StudentName = studentName;
        FatherName = fatherName;
        DOB = dob;
        StudentGender = studentGender;
        PhysicsMark = physicsMark;
        ChemistryMark = chemistryMark;
        MathsMark = mathsMark;
    }

    public bool CheckEligibility(double cutOff)
    {
        double total = PhysicsMark + ChemistryMark + MathsMark;
        double average = total / 3;
        if (average > cutOff)
        {
            return true;
        }
        return false;
    }
}