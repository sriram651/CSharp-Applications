using System;
using System.Collections.Generic;

namespace CovidVaccinationDrive;
public class Operations
{
    static List<BeneficiaryDetails> beneficiaryList = new List<BeneficiaryDetails>();
    static List<VaccinationDetails> vaccinationList = new List<VaccinationDetails>();
    static List<VaccineDetails> vaccineList = new List<VaccineDetails>();
    static BeneficiaryDetails currentBeneficiary = null;
    static VaccinationDetails lastVaccination = null;
    static VaccineDetails currentVaccine = null;
    public static void MainMenu()
    {
        int userChoice;
        do
        {
            Console.WriteLine($"\n--------------------Main Menu--------------------");
            Console.WriteLine($"\n1. Beneficiary Registration");
            Console.WriteLine($"\n2. Beneficiary Login");
            Console.WriteLine($"\n3. Exit");
            Console.WriteLine($"\nEnter your choice:");
            userChoice = Int32.Parse(Console.ReadLine());

            switch(userChoice)
            {
                case 1:
                {
                    BeneficiaryRegistration();
                    break;
                }
                case 2:
                {
                    BeneficiaryLogin();
                    break;
                }
                case 3:
                {
                    Console.WriteLine($"\nExiting Main Menu\n");
                    break;
                }
            }
        }while(userChoice != 3);
    }

    public static void BeneficiaryRegistration()
    {
        Console.WriteLine($"\n--------------------Beneficiary Registration--------------------\n");
        Console.WriteLine($"\nEnter your Name: ");
        string userName = Console.ReadLine();
        // age gender Mobile number city
        Console.WriteLine($"\nEnter your age:");
        int age = Int32.Parse(Console.ReadLine());
        Console.WriteLine($"\nEnter the gender:");
        Gender userGender = Enum.Parse<Gender>(Console.ReadLine(), true);
        Console.WriteLine($"\nEnter the mobile Number: ");
        string mobileNumber = Console.ReadLine();
        Console.WriteLine($"\nEnter City: ");
        string city = Console.ReadLine();
        
        BeneficiaryDetails beneficiary = new BeneficiaryDetails(userName, userGender, mobileNumber, city, age);
        beneficiaryList.Add(beneficiary);

        Console.WriteLine($"\nBeneficiary Registered Successfully!\n");
        Console.WriteLine($"\nYour Beneficiary ID is {beneficiary.BeneficiaryID}\n");
    }

    public static void BeneficiaryLogin()
    {
        string beneficiaryID;
        Console.WriteLine($"\nEnter the Beneficiary ID:");
        beneficiaryID = Console.ReadLine().ToUpper();
        bool flag = false;
        foreach(BeneficiaryDetails beneficiary in beneficiaryList)
        {
            if (beneficiaryID == beneficiary.BeneficiaryID)
            {
                flag = true;
                currentBeneficiary = beneficiary;
                Console.WriteLine($"\nLogged in Successfully");
            }
        }
        if(!flag)
        {
            Console.WriteLine($"\nInvalid Beneficiary ID!");
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
            Console.WriteLine($"\n-----------------Sub Menu-----------------");
            Console.WriteLine($"\n1. Show My Details");
            Console.WriteLine($"\n2. Take Vaccination");
            Console.WriteLine($"\n3. My Vaccination History");
            Console.WriteLine($"\n4. Next Due Date");
            Console.WriteLine($"\n5. Exit");
            Console.WriteLine($"\nEnter your Choice: ");
            userChoice = Int32.Parse(Console.ReadLine());
            switch(userChoice)
            {
                case 1:
                {
                    ShowDetails();
                    break;
                }
                case 2:
                {
                    TakeVaccine();
                    break;
                }
                case 3:
                {
                    VaccinationHistory();
                    break;
                }
                case 4:
                {
                    NextDueDate();
                    break;
                }
                case 5:
                {
                    Console.WriteLine($"\n-----------------Exiting Sub Menu-----------------");
                    break;
                }
            }
        }while(userChoice != 5);
    }

    public static void ShowDetails()
    {
        Console.WriteLine($"\n--------------------Show Details--------------------\n");
        Console.WriteLine($"\nBeneficiary ID: {currentBeneficiary.BeneficiaryID}");
        Console.WriteLine($"\nBeneficiary Name: {currentBeneficiary.BenificiaryName}");
        Console.WriteLine($"\nGender: {currentBeneficiary.BeneficiaryGender}");
        Console.WriteLine($"\nMobile Number: {currentBeneficiary.MobileNumber}");
        Console.WriteLine($"\nCity: {currentBeneficiary.City}");
        Console.WriteLine($"\nBeneficiary Age: {currentBeneficiary.BeneficiaryAge}\n");
    }

    public static void TakeVaccine()
    {
        Console.WriteLine($"\n-----------------------Vaccine Details-----------------------");
        foreach(VaccineDetails vaccine in vaccineList)
        {
            Console.WriteLine($"Vaccine ID: {vaccine.VaccineID}\nVaccine Name: {vaccine.VaccineName}\nDoses Available: {vaccine.NoOfDoseAvailable}\n");
        }

        Console.WriteLine($"\nEnter the Vaccine ID: ");
        string vaccineID = Console.ReadLine().ToUpper();
        
        foreach(VaccineDetails vaccine in vaccineList)
        {
            if (vaccineID == vaccine.VaccineID)
            {
                currentVaccine = vaccine;
                break;
            }
        }
        if (currentVaccine != null)
        {
            foreach(VaccinationDetails vacDetail in vaccinationList)
            {
                if (currentBeneficiary.BeneficiaryID  == vacDetail.BeneficiaryID)
                {
                    lastVaccination = vacDetail;
                }
            }
            if (currentVaccine.NoOfDoseAvailable > 0)
            {
                if (lastVaccination != null)
                {
                    if (vaccineID == lastVaccination.VaccineID)
                    {
                        if (lastVaccination.DoseNumber == 3)
                        {
                            Console.WriteLine($"\nYou have taken all 3 doses!");
                        }
                        else if (lastVaccination.DoseNumber == 2 || lastVaccination.DoseNumber == 1)
                        {
                            if ((DateTime.Now - lastVaccination.VaccinationDate).Days >= 30)
                            {
                                VaccinationDetails newVaccination = new VaccinationDetails(currentBeneficiary.BeneficiaryID, vaccineID, (lastVaccination.DoseNumber + 1), DateTime.Now);
                                vaccinationList.Add(newVaccination);
                                currentVaccine.vaccinate();
                                Console.WriteLine($"\nYou have been Vaccinated!");
                                Console.WriteLine($"\nYour Vaccination ID is {newVaccination.VaccinationID}\n");
                            }
                            else
                            {
                                Console.WriteLine($"\nPlease wait till {lastVaccination.VaccinationDate.AddDays(30).ToShortDateString()} to get your next Vaccination");
                            }
                        }
                    } 
                    else
                    {
                        Console.WriteLine($"\nYou took a different vaccine last time!");
                        Console.WriteLine($"Choose the Same vaccine that you took last time");
                    }
                }
                else
                {
                    if (currentBeneficiary.BeneficiaryAge >= 14)
                    {
                        Console.WriteLine($"\nYou haven't taken any dose, So take your first dose now!");
                        VaccinationDetails newVaccination = new VaccinationDetails(currentBeneficiary.BeneficiaryID, vaccineID, 1, DateTime.Now);
                        vaccinationList.Add(newVaccination);
                        Console.WriteLine($"\nYou have been Vaccinated!");
                        Console.WriteLine($"\nYour Vaccination ID is {newVaccination.VaccinationID}\n");
                    } 
                }
            }
            else
            {
                Console.WriteLine($"\nSorry, We do not have any doses available with us right now, please come back Later!");
            }    
        }
        else
        {
            Console.WriteLine($"\nInvalid Vaccine ID!");
        }
    }


    public static void VaccinationHistory()
    {
        Console.WriteLine($"\n---------------------Vaccination History---------------------");
        foreach(VaccinationDetails vacDetail in vaccinationList)
        {
            if (currentBeneficiary.BeneficiaryID == vacDetail.BeneficiaryID)
            {
                Console.WriteLine($"\nBeneficiary ID: {vacDetail.BeneficiaryID}");
                Console.WriteLine($"\nVaccination ID: {vacDetail.VaccinationID}");
                Console.WriteLine($"\nVaccine ID: {vacDetail.VaccineID}");
                Console.WriteLine($"\nDose Number: {vacDetail.DoseNumber}");
                Console.WriteLine($"\nVaccination Date: {vacDetail.VaccinationDate.ToShortDateString()}\n");
            }
        }
        
    }

    public static void NextDueDate()
    {
        foreach(VaccinationDetails vacDetail in vaccinationList)
        {
            if (currentBeneficiary.BeneficiaryID == vacDetail.BeneficiaryID)
            {
                lastVaccination = vacDetail;
            }
        }
        if (lastVaccination == null)
        {
            Console.WriteLine($"\nYou can Take the Vaccine Now!");
        }
        else if (lastVaccination.DoseNumber == 1 || lastVaccination.DoseNumber == 2)
        {
            DateTime nextDate = lastVaccination.VaccinationDate.AddDays(30);
            Console.WriteLine($"\nYou can take your next dose of Vaccination on {nextDate.ToShortDateString()}");
        }
        else if (lastVaccination.DoseNumber == 3)
        {
            Console.WriteLine($"\nYou have Completed the Vaccination Course!");
            Console.WriteLine($"\nThank you for participating in the Vaccination Drive!");
        }
    }

    public static void AddDefaultValues()
    {
        BeneficiaryDetails beneficiary1 = new BeneficiaryDetails("Ravichandran", Gender.Male, "8484484", "Chennai", 21);
        BeneficiaryDetails beneficiary2 = new BeneficiaryDetails("Baskaran", Gender.Male, "8484747", "Chennai", 22);
        beneficiaryList.Add(beneficiary1);
        beneficiaryList.Add(beneficiary2);

        // Add Vaccine Details
        vaccineList.Add(new VaccineDetails(VaccineDetails.Vaccine.Covishield, 50));
        vaccineList.Add(new VaccineDetails(VaccineDetails.Vaccine.Covaccine, 50));

        // Add Vaccination List
        DateTime date = new DateTime(2021, 11, 11);
        vaccinationList.Add(new VaccinationDetails("BID1001", "CID101", 1, date));
        date = new DateTime(2022, 03, 11);
        vaccinationList.Add(new VaccinationDetails("BID1001", "CID101", 2, date));
        date = new DateTime(2022, 04, 04);
        vaccinationList.Add(new VaccinationDetails("BID1002", "CID102", 1, date));
    }
}
