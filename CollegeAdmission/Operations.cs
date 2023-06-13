using System.Runtime.ConstrainedExecution;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;

namespace CollegeAdmission;
public static class Operations
{
    static List<StudentDetails> studentList = new List<StudentDetails>();
    static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
    static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
    static StudentDetails currentStudent = null;

    public static void MainMenu()
    {
        int userChoice;
        do
        {
            Console.WriteLine($"\n--------------------Main Menu--------------------");
            Console.WriteLine($"\n1. Registration");
            Console.WriteLine($"\n2. Login");
            Console.WriteLine($"\n3. Exit");
            Console.WriteLine($"\nEnter your choice:");
            userChoice = Int32.Parse(Console.ReadLine());

            switch(userChoice)
            {
                case 1:
                {
                    StudentRegistration();
                    break;
                }
                case 2:
                {
                    StudentLogin();
                    break;
                }
                case 3:
                {
                    Console.WriteLine($"\nExiting Main Menu...");
                    break;
                }
            }
        }while(userChoice != 3);
    }

    public static void StudentRegistration()
    {
        Console.WriteLine($"\n-------------------Registration Form-------------------\n");
        Console.WriteLine($"\nEnter Student Name: ");
        string studentName = Console.ReadLine();
        Console.WriteLine($"\nEnter Father's Name: ");
        string fatherName = Console.ReadLine();
        Console.WriteLine($"\nEnter Date of Birth(dd/MM/yyyy): ");
        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.WriteLine($"\nEnter the Gender: ");
        Gender studentGender = Enum.Parse<Gender>(Console.ReadLine(), true);
        Console.WriteLine($"\nEnter the Physics Mark: ");
        double physicsMark = double.Parse(Console.ReadLine());
        Console.WriteLine($"\nEnter the chemistry Mark: ");
        double chemistryMark = double.Parse(Console.ReadLine());
        Console.WriteLine($"\nEnter the Maths Mark: ");
        double mathsMark = double.Parse(Console.ReadLine());

        StudentDetails student = new StudentDetails(studentName, fatherName, dob, studentGender, physicsMark, chemistryMark, mathsMark);
        studentList.Add(student);

        Console.WriteLine($"\nStudent Registered Successfully!");
        Console.WriteLine($"Student ID = {student.StudentID}");

        /*Console.WriteLine($"\n-------------------Student Details-------------------");
        foreach(StudentDetails student1 in studentList)
        {
            Console.WriteLine($"Student ID: {student1.StudentID}");
            Console.WriteLine($"\nName: {student1.StudentName}");
            Console.WriteLine($"\nFather Name: {student1.FatherName}");
            Console.WriteLine($"\nDate of Birth: {student1.DOB}");
            Console.WriteLine($"\nGender: {student1.StudentGender}");
            Console.WriteLine($"\nPhysics MarK: {student1.PhysicsMark}");
            Console.WriteLine($"\nChemistry Mark: {student1.ChemistryMark}");
            Console.WriteLine($"\nMaths Mark: {student1.MathsMark}");
        }*/
    }

    public static void StudentLogin()
    {
        Console.WriteLine($"\n-------------------Login Form-------------------\n");
        Console.WriteLine($"\nEnter Student ID:");
        string studentID = Console.ReadLine().ToUpper();
        bool flag = false;
        foreach(StudentDetails student in studentList)
        {
            if (studentID == student.StudentID)
            {
                flag = true;
                currentStudent = student;
                Console.WriteLine($"\nLogged in Successfully");
            }
        }
        if(!flag)
        {
            Console.WriteLine($"\nInvalid Student ID!");
        }
        else
        {
            SubMenu();
        }
    }

    public static void SubMenu()
    {
        int userChoice;
        do
        {
            Console.WriteLine($"\n--------------------Sub Menu--------------------");
            Console.WriteLine($"\n1. Check Eligibility");
            Console.WriteLine($"\n2. Show Details");
            Console.WriteLine($"\n3. Take Admission");
            Console.WriteLine($"\n4. Cancel Admission");
            Console.WriteLine($"\n5. Show Admission Details");
            Console.WriteLine($"\n6. Exit");
            Console.WriteLine($"\nEnter your Choice:");
            userChoice = Int32.Parse(Console.ReadLine());

            switch(userChoice)
            {
                case 1:
                {
                    CheckEligibility();
                    break;
                }
                case 2:
                {
                    ShowDetails();
                    break;
                }
                case 3:
                {
                    TakeAdmission();
                    break;
                }
                case 4:
                {
                    CancelAdmission();
                    break;
                }
                case 5:
                {
                    AdmissionHistory();
                    break;
                }
                case 6:
                {
                    Console.WriteLine($"\n------------------Exiting Sub Menu------------------");
                    break;
                }
            }
        }while (userChoice != 6);
    }

    public static void CheckEligibility()
    {
        Console.WriteLine($"\n-----------------Check Elgibility-----------------\n");
        if (currentStudent.CheckEligibility(75))
        {
            Console.WriteLine($"\nYou are Eligible to Take Admission");
        }
        else
        {
            Console.WriteLine($"\nYou are not Eligible to take Admission");
        }
    }
    
    public static void ShowDetails()
    {
        Console.WriteLine($"-------------Student Details-------------\n");
        
        foreach(StudentDetails student in studentList)
        {
            if (currentStudent.StudentID == student.StudentID)
            {
                Console.WriteLine($"Student ID: {student.StudentID}");
                Console.WriteLine($"Student Name: {student.StudentName}");
                Console.WriteLine($"Student Date of Birth: {student.DOB.ToShortDateString()}");
                Console.WriteLine($"Student Gender: {student.StudentGender}");
                Console.WriteLine($"Physics Mark: {student.PhysicsMark}");
                Console.WriteLine($"Chemistry Mark: {student.ChemistryMark}");
                Console.WriteLine($"Maths Mark: {student.MathsMark}\n");
            }
        }
            
    } 
    
    public static void TakeAdmission()
    {
        Console.WriteLine($"\n---------------------Take Admission---------------------\n");
        Console.WriteLine($"\n******Department Details******");
        foreach(DepartmentDetails department in departmentList)
        {
            Console.WriteLine($"Department ID: {department.DepartmentID}");
            Console.WriteLine($"Department Name: {department.DepartmentName}");
            Console.WriteLine($"Seats Available: {department.NumberOfSeats}\n");
        }

        Console.WriteLine($"\nEnter the Department ID:");
        string departmentID = Console.ReadLine().ToUpper();
        bool check = false;
        foreach(DepartmentDetails department in departmentList)
        {
            if (departmentID == department.DepartmentID)
            {
                check = true;
                int count = 0;
                if (department.NumberOfSeats > 0)
                {
                    if (currentStudent.CheckEligibility(75))
                    {
                        foreach(AdmissionDetails admission in admissionList)
                        {
                            if (currentStudent.StudentID == admission.StudentID && admission.StudentAdmissionStatus == AdmissionStatus.Admitted)
                            {
                                count++;
                            }
                        }
                        if (count > 0)
                        {
                            Console.WriteLine($"\nYou have already been Admitted!");
                        }
                        else
                        {
                            department.NumberOfSeats--;
                            AdmissionDetails admit = new AdmissionDetails(currentStudent.StudentID, department.DepartmentID, DateTime.Now, AdmissionStatus.Admitted);
                            admissionList.Add(admit);
                            Console.WriteLine($"\nYour Admission ID is {admit.AdmissionID}");
                        }
                    }
                }
            }
        }
        if (!check)
        {
            Console.WriteLine($"\nInvalid Department ID!");
        }
    }

    public static void CancelAdmission()
    {
        foreach(AdmissionDetails admit in admissionList)
        {
            if (currentStudent.StudentID == admit.StudentID && admit.StudentAdmissionStatus == AdmissionStatus.Admitted)
            {
                admit.StudentAdmissionStatus = AdmissionStatus.Cancelled;
                foreach(DepartmentDetails department in departmentList)
                {
                    if(admit.DepartmentID == department.DepartmentID)
                    {
                        department.NumberOfSeats++;
                        Console.WriteLine($"\nAdmission Cancelled Successfully!");   
                    }
                }
            }
        }
    }

    public static void AdmissionHistory()
    {
        Console.WriteLine($"\n-------------------------Admission History-------------------------\n");
        foreach(AdmissionDetails admit in admissionList)
        {
            if (currentStudent.StudentID == admit.StudentID)
            {
                Console.WriteLine($"\nAdmission ID: {admit.AdmissionID}");
                Console.WriteLine($"\nDepartment ID: {admit.DepartmentID}");
                Console.WriteLine($"\nStudent ID: {admit.StudentID}");
                Console.WriteLine($"\nAdmission Date: {admit.AdmissionDate}");
                Console.WriteLine($"\nAdmission Status: {admit.StudentAdmissionStatus}\n");
            }
        }
    }

    public static void AddDefaultValues()
    {
        // Student Default
        StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999,11,11), Gender.Male, 95, 95, 95);
        studentList.Add(student1);
        StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999,11,11), Gender.Male, 95, 95, 95);
        studentList.Add(student2);

        // Department Default
        DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
        departmentList.Add(department1);
        DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
        departmentList.Add(department2);
        DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
        departmentList.Add(department3);
        DepartmentDetails department4 = new DepartmentDetails("ECE", 30);
        departmentList.Add(department4);

        // Admission Default
        AdmissionDetails admission1 = new AdmissionDetails("SF3001", "DID101", new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
        admissionList.Add(admission1);
        AdmissionDetails admission2 = new AdmissionDetails("SF3002", "DID102", new DateTime(2022, 05, 12), AdmissionStatus.Admitted);
        admissionList.Add(admission2);
    }
}