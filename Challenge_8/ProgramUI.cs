using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    public class ProgramUI
    {
        InsuranceRepository _insurranceRepo = new InsuranceRepository();
        List<InsuranceContent> insuranceList;
        InsuranceContent newContent = new InsuranceContent();
        internal void Run()
        {
            InsuranceContent one = new InsuranceContent("Jose", "Caban", 36, 0, 0, 0, 0, false, 100m);
            InsuranceContent two = new InsuranceContent("Zadia", "Caban", 38, 3, 0, 5, 0, false, 100m);
            InsuranceContent three = new InsuranceContent("Eric", "Dawson", 39, 6, 6, 6, 4, true, 180m);
            _insurranceRepo.AddInsuranceContentToList(one);
            _insurranceRepo.AddInsuranceContentToList(two);
            _insurranceRepo.AddInsuranceContentToList(three);
            insuranceList = _insurranceRepo.GetInsuranceContentList();
            bool hadAccident = false;
            decimal premium = 0m;
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine($"Welcome to Smart Insurance customer/driver database.\n\n" +
                                   $"1. Enter new customer/driver information\n" +
                                   $"2. Remove customer/driver from database\n" +
                                   $"3. See customer/driver database\n" +
                                   $"0. Exit");
                int response = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (response)
                {
                    case 1:
                        Console.WriteLine("NOTE: Please have the new customer completed questionnaire in hand before continuing.");
                        Console.WriteLine("If you would like to continue enter (y)");
                        string answer = Console.ReadLine().ToLower();
                        if (answer != "y") { break; }
                        Console.Write("\nEnter driver's FIRST NAME: ");
                        newContent.FirstName = Console.ReadLine();
                        Console.Write("\nEnter driver's LAST NAME: ");
                        newContent.LastName = Console.ReadLine();
                        Console.WriteLine("\nEnter driver's AGE: ");
                        newContent.DriverAge = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nHow many times did this driver came close to swerving off the road in the last month?");
                        newContent.Swerve = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nHow many close accidents did this driver have last month?: ");
                        newContent.CloseAccident = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nDid this driver have any close accidents near a stop sign within the last month? If so, how many?");
                        newContent.StopSign = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nHow many times was this driver late for work in the last month? Intentional or unintentional.");
                        newContent.LateForWork = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nWas this driver involved in a vehicle accident within the last year? (y/n)");
                        string accidentResponse = Console.ReadLine().ToLower();
                        if (accidentResponse != "n")
                            hadAccident = true;
                        else
                            hadAccident = false;
                        newContent.HadAccident = hadAccident;
                        if (newContent.DriverAge <= 21)
                            premium = 100m;
                        else
                            premium = 70m;
                        if (newContent.Swerve >= 5)
                            premium += 25m;
                        if (newContent.CloseAccident <= 3)
                        {
                            if (newContent.CloseAccident != 0)
                            {
                                premium += 10m;
                            }
                        }
                        else
                            premium += 25m;
                        if (newContent.StopSign <= 3)
                        {
                            if (newContent.StopSign != 0)
                            {
                                premium += 10m;
                            }
                        }
                        else
                            premium += 25;
                        if (newContent.LateForWork <= 3)
                        {
                            if (newContent.LateForWork != 0)
                            {
                                premium += 10m;
                            }
                        }
                        else
                            premium += 20m;
                        if (newContent.HadAccident == true)
                            premium += 20m;
                        newContent.Premium = premium;
                        Console.WriteLine($"\nThis driver's estimated premium is: ${premium}");
                        _insurranceRepo.AddInsuranceContentToList(newContent);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("Customers/drivers currently on the databse: ");
                        foreach (InsuranceContent content in _insurranceRepo.GetInsuranceContentList())
                        {
                            Console.WriteLine($"{content.FirstName} {content.LastName}");
                        }
                        Console.WriteLine("\nEnter the first name of the customer/driver you would like to remove.");
                        string removecustomer = Console.ReadLine();
                        bool userwasdeleted = false;
                        foreach (InsuranceContent content in _insurranceRepo.GetInsuranceContentList())
                        {
                            if (removecustomer == content.FirstName)
                            {
                                _insurranceRepo.RemoveMenuContentFromList(content);
                                Console.WriteLine();
                                userwasdeleted = true;
                                break;
                            }
                        }
                        if (userwasdeleted != true)
                        {
                            Console.WriteLine("Name entered does not exist in the database.");
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        foreach (InsuranceContent content in _insurranceRepo.GetInsuranceContentList())
                            Console.WriteLine($"Customer's Name: {content.FirstName} {content.LastName},  Age: {content.DriverAge}" +
                                $"\n\tTimes this driver came close to swerving off-road within last month: #{content.Swerve}" +
                                $"\n\tTimes this driver came close to an accident within last month: #{content.CloseAccident}, and times close to a stop sign: #{content.StopSign}" +
                                $"\n\tAmmount of times late of work within last month: #{content.LateForWork}" +
                                $"\n\tThis driver has been in an accident within the last year: {content.HadAccident}" +
                                $"\n\tCurrent premium: ${content.Premium}\n");
                        break;
                    case 0:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
    }
}
