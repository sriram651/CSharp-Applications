using System;
using System.Collections.Generic;
using System.Linq;
namespace Application
{
    public delegate void EventManager();
    public class AppointmentManager
    {
        public static List<Doctor> doctorList = new List<Doctor>();
        public static List<Patient> patientList = new List<Patient>();
        public static List<Appointment> appointmentList = new List<Appointment>();
        public static Patient currentPatient = null;
        public static EventManager Start;
        public static EventManager register, appointmentAdded, login, subMenu, bookAppointment, displayAppointments, editProfile, displayDepartments;
        public static void Starter()
        {
            Subscribe();
            Start();
        }
        public static void Subscribe()
        {
            Start += new EventManager(AddDefaultData);
            Start += new EventManager(MainMenu);


            register += new EventManager(Register);
            login += new EventManager(Login);
            subMenu += new EventManager(SubMenu);
            bookAppointment += new EventManager(BookAppointment);
            displayAppointments += new EventManager(DisplayAppointments);
            displayDepartments += new EventManager(DisplayDepartments);
            editProfile += new EventManager(EditProfile);
            appointmentAdded += new EventManager(AppointmentAdded);
        }
        public static void MainMenu()
        {
            int userChoice;
            do
            {
                Console.WriteLine($"\nMain Menu");
                Console.WriteLine($"\n1.Register\n2.Login\n3.Exit");
                Console.WriteLine($"\nEnter your choice: ");
                userChoice = int.Parse(Console.ReadLine());

                switch(userChoice)
                {
                    case 1:
                    {
                        register();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine($"\nLogin");
                        login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine($"\nExit");
                        break;
                    }
                }
            }while(userChoice != 3);
        }


        public static void Register()
        {
            /*
            PatientID (should be unique and created automatically)
            Name
            Password
            Age
            Gender
            */
            Console.WriteLine($"\nEnter your Name:");
            string patientName = Console.ReadLine();
            Console.WriteLine($"\nEnter your new Password:");
            string password = Console.ReadLine();
            Console.WriteLine($"\nEnter your Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nEnter your Gender:");
            Patient.Gender gender = Enum.Parse<Patient.Gender>(Console.ReadLine(), true);

            Patient newPatient = new Patient(patientName, password, age, gender);
            patientList.Add(newPatient);

            Console.WriteLine($"\nRegistered Successfully, Your Patient ID {newPatient.PatientID}");
        }

        public static void Login()
        {
            Console.WriteLine($"\nEnter your Patient ID:");
            int patientID = int.Parse(Console.ReadLine());
            bool patientFound = false;

            foreach (Patient patient in patientList)
            {
                if (patientID == patient.PatientID)
                {
                    currentPatient = patient;
                    patientFound = true;
                    break;
                }
            }

            if(patientFound)
            {
                Console.WriteLine($"\nEnter Password: ");
                string password = Console.ReadLine();
                if (password == currentPatient.Password)
                {
                    Console.WriteLine($"\nLogged in");
                    subMenu();
                }
                else
                {
                    Console.WriteLine($"\nIncorrect Password!");
                } 
            }
            else
            {
                Console.WriteLine($"\nInvalid Patient ID!");
            }
        }

        public static void SubMenu()
        {
            int userChoice;
            do
            {
                Console.WriteLine($"\nSub Menu");
                Console.WriteLine($"\n1. Book Appointment");
                Console.WriteLine($"\n2. View Appointment details");
                Console.WriteLine($"\n3. Edit my profile");
                Console.WriteLine($"\n4. Exit");
                Console.WriteLine($"\nEnter your choice:");
                userChoice = int.Parse(Console.ReadLine());

                switch(userChoice)
                {
                    case 1:
                    {
                        Console.WriteLine($"\nBook Appointment");
                        bookAppointment();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine($"\nView Appointment Details");
                        displayAppointments();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine($"\nEdit my profile");
                        editProfile();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine($"\nExit");
                        break;
                    }
                }

            }while(userChoice != 4);
            
            
        }

        public static void BookAppointment()
        {
            displayDepartments();
            Console.Write($"\nEnter your choice of Department: ");
            int userChoice = int.Parse(Console.ReadLine());
            string dept = "";

            switch(userChoice)
            {
                case 1:
                {
                    dept = "Anaesthesiology";
                    break;
                }
                case 2:
                {
                    dept = "Cardiology";
                    break;
                }
                case 3:
                {
                    dept = "Diabetology";
                    break;
                }
                case 4:
                {
                    dept = "Neonatology";
                    break;
                }
                case 5:
                {
                    dept = "Nephrology";
                    break;
                }
            }
            DateTime findDateAvailability = IsDoctorAvailable(dept, out Doctor doctor);
            Console.WriteLine($"\nAppointment is available on {findDateAvailability.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"\nPress 'Y' to confirm and 'N' to Cancel");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "y")
            {
                Console.WriteLine($"Enter your Problem: ");
                string problem = Console.ReadLine();
                Appointment appointment = new Appointment(currentPatient.PatientID, doctor.DoctorID, findDateAvailability, problem);
                appointmentList.Add(appointment);
                Console.WriteLine($"\nYour Appointment is Confirmed on {findDateAvailability.ToString("dd/MM/yyyy")}");
                appointmentAdded();
            }
            else
            {
                Console.WriteLine($"Your Booking has been cancelled!");
            }
        }

        public static void DisplayAppointments()
        {
            foreach(Appointment appoint in appointmentList)
            {
                if (currentPatient.PatientID == appoint.PatientID)
                {
                    Console.WriteLine($"\nAppointment ID: {appoint.AppointmentID}");
                    Console.WriteLine($"\nPatient ID: {appoint.PatientID}");
                    Console.WriteLine($"\nDoctor ID: {appoint.DoctorID}");
                    Console.WriteLine($"\nDate of Appointment: {appoint.Date.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"\nProblem: {appoint.Problem}");
                }
            }
        }

        public static void EditProfile()
        {
            int userChoice;
            string answer;
            do 
            {
                Console.WriteLine($"\n1. Name\n2. Password\n3. Age\n4. Gender\nEnter Which detail you want to Change: ");
                userChoice = int.Parse(Console.ReadLine());
                switch(userChoice)
                {
                    case 1:
                    {
                        Console.WriteLine($"\nEnter new Name: ");
                        string name = Console.ReadLine();
                        currentPatient.PatientName = name;
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine($"\nEnter new Password: ");
                        string password = Console.ReadLine();
                        currentPatient.Password = password;
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine($"\nEnter new Age: ");
                        int age = int.Parse(Console.ReadLine());
                        currentPatient.Age = age;
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine($"\nEnter Gender: ");
                        Patient.Gender gender = Enum.Parse<Patient.Gender>(Console.ReadLine(), true);
                        currentPatient.UserGender = gender;
                        break;
                    }
                }
                Console.WriteLine($"\nDo you want to modify another detail?(yes/no): ");
                answer = Console.ReadLine().ToLower();
            }while(answer == "yes"); 
        }

        public static void DisplayDepartments()
        {
            int i = 0;
            foreach(Doctor doc in doctorList)
            {
                Console.WriteLine($"\n{(++i)}. {doc.Department}");
            }
        }

        public static void AppointmentAdded()
        {
            Console.WriteLine($"New Appointment Added");
        }

        public static DateTime IsDoctorAvailable(string dept, out Doctor doctor)
        {
            int count = 0;
            DateTime doa = DateTime.Now;
            doctor = null;
            foreach(Doctor doc in doctorList)
            {
                if (dept == doc.Department)
                {
                    foreach(Appointment appoint in appointmentList)
                    {
                        if (doc.DoctorID == appoint.DoctorID)
                        {
                            if (appoint.Date.ToString("dd/MM/yyyy") == doa.ToString("dd/MM/yyyy"))
                            {
                                count++;
                            }
                        }
                    }
                    if (count > 1)
                    {
                        doa = doa.AddDays(1);
                    }
                    else
                    {
                        doctor = doc;
                    }
                }
            }
            return doa;
        }

        public static void AddDefaultData()
        {
            // Doctors
            doctorList.Add(new Doctor("Nancy", "Anaesthesiology"));
            doctorList.Add(new Doctor("Andrew", "Cardiology"));
            doctorList.Add(new Doctor("Janet", "Diabetology"));
            doctorList.Add(new Doctor("Margaret", "Neonatology"));
            doctorList.Add(new Doctor("Steven", "Nephrology"));

            doctorList = doctorList.OrderBy(x => x.DoctorID).ToList();

            // Patients
            patientList.Add(new Patient("Robert", "welcome", 40, Patient.Gender.Male));
            patientList.Add(new Patient("Laura", "welcome", 36, Patient.Gender.Female));
            patientList.Add(new Patient("Anne", "welcome", 42, Patient.Gender.Female));

            patientList = patientList.OrderBy(x => x.Age).ToList();

            // Appointments 
            appointmentList.Add(new Appointment(1, 2, new DateTime(2012,3,8), "Heart Problem"));
            appointmentList.Add(new Appointment(1, 5, new DateTime(2012,3,8), "Spinal cord injury"));
            appointmentList.Add(new Appointment(2, 2, new DateTime(2012,3,8), "Heart attack"));

            appointmentList = appointmentList.OrderBy(x => x.AppointmentID).ToList();
        }
    }
}
/*

AppointmentID	PatientID	DoctorID	Date	Problem
1	1	2	8/3/2012	Heart problem
2	1	5	8/3/2012	Spinal cord injury
3	2	2	8/3/2012	Heart attack


*/