using System;
using System.Xml.Linq;
using SE_Assignment_Codes;
using System.Collections.Generic;
using System.IO;

public class Global
{
    static List<SeasonPass> seasonpass = new List<SeasonPass>();
}

class Program
{
    static void Main()
    {
        User user = new User("Hong Wei", "S1020927J", "S10203927", "TheLowLowLow", "81176336");
        Vehicle vehicle = new Vehicle("SHUAT999", "IAMBIGFANOFIU", "Plane");
        DateTime sd = DateTime.ParseExact("01/2003", "MM/yyyy", null);
        DateTime ed = DateTime.ParseExact("07/2024", "MM/yyyy", null);
        SeasonPass seasonPass1 = new SeasonPass(0, user, sd, ed, "DollaDollaBills", vehicle, "Monthly");

            while (true)
            {
                Console.WriteLine("Parking Management System Menu:");
                Console.WriteLine("1. Apply for new season pass");
                Console.WriteLine("2. Process season pass application");
                Console.WriteLine("3. Terminate season pass");
                Console.WriteLine("4. Generate Financial Report");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ApplyForNewSeasonPass(seasonPass1);
                    break;

                    case "2":
                        ProcessSeasonPassApplication();
                        break;

                case "3":
                    TerminateSeasonPass(seasonPass1);
                    break;

                    case "4":
                        GenerateFinancialReport();
                        break;

                    case "0":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

            Console.WriteLine(); // Add a line break for better readability
        }
    }

    public static void ApplyForNewSeasonPass(SeasonPass seasonPass1)
    {
        Console.WriteLine("Applying for a new season pass...");

        // Prompt the applicant to provide necessary details
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your student/staff ID: ");
        string applicantId = Console.ReadLine();

        Console.Write("Enter your mobile number: ");
        string mobileNumber = Console.ReadLine();

        Console.Write("Enter your license plate number: ");
        string licensePlateNumber = Console.ReadLine();

        Console.Write("Enter your IU number: ");
        string iuNumber = Console.ReadLine();

        Console.Write("Enter vehicle type: ");
        string vehicleType = Console.ReadLine();

        Console.Write("Enter start month (MM/YYYY): ");
        string startMonthStr = Console.ReadLine();
        DateTime startMonth = DateTime.ParseExact(startMonthStr, "MM/yyyy", null);

        Console.Write("Enter end month (MM/YYYY): ");
        string endMonthStr = Console.ReadLine();
        DateTime endMonth = DateTime.ParseExact(endMonthStr, "MM/yyyy", null);

        Console.Write("Enter season pass type: ");
        string passType = Console.ReadLine();

        Console.Write("Enter payment mode: ");
        string paymentMode = Console.ReadLine();

        // Create User object with collected details
        User user = new User(name, applicantId, username, password, mobileNumber);

        // Create Vehicle object with collected details
        Vehicle vehicle = new Vehicle(licensePlateNumber, iuNumber, vehicleType);

        // Confirm details
        Console.WriteLine("\nConfirm details:");
        Console.WriteLine($"Username: {user.Username}");
        Console.WriteLine($"Password: {user.Password}");
        Console.WriteLine($"Name: {user.Name}");
        Console.WriteLine($"Student/Staff ID: {user.ID}");
        Console.WriteLine($"Mobile Number: {user.MobileNumber}");
        Console.WriteLine($"License Plate Number: {vehicle.LicensePlateNumber}");
        Console.WriteLine($"IU Number: {vehicle.IUNumber}");
        Console.WriteLine($"Vehicle Type: {vehicle.VehicleType}");
        Console.WriteLine($"Start Month: {startMonth:MM/yyyy}");
        Console.WriteLine($"End Month: {endMonth:MM/yyyy}");
        Console.WriteLine($"Season Pass Type: {passType}");
        Console.WriteLine($"Payment Mode: {paymentMode}");

        Console.Write("\nProceed with payment (Y/N)? ");
        string proceed = Console.ReadLine();

        if (proceed.ToUpper() == "Y")
        {
            // Payment verification (mock implementation)
            Console.WriteLine("Payment received. Updating status to 'Payment Received'...");

            // Create and process the season pass application
            SeasonPass seasonPass = new SeasonPass(0, user, startMonth, endMonth, paymentMode, vehicle, passType);

            // Update status to 'processing'
            seasonPass1.State.Apply();

            Console.WriteLine("Season pass application submitted successfully.");
        }
        else
        {
            Console.WriteLine("Season pass application cancelled.");
        }
    }

    public static void ProcessSeasonPassApplication()
    {
        Console.WriteLine();

    }

    public static void TerminateSeasonPass(SeasonPass seasonPass1)
    {
        //For testing

        //Check for existing season pass
        //Console.WriteLine(seasonPass.State.ToString() == "SE_Assignment_Codes.ProcessingState");
        //if ()
        //{

        //}

        int cancel = 0;
        while(cancel != 1 && cancel != 2)
        {
            try
            {
                Console.Write("Confirm that you want to terminate season pass\n[1]Yes [2] No\nEnter option:");
                cancel = Int32.Parse(Console.ReadLine());
                Console.WriteLine(cancel);
            }
            catch
            {
                Console.WriteLine("Input entered is not a number\n");
            }
        }
        if (cancel == 1)
        {
            Console.Write("Enter your reason for cancelling: ");
            string response = Console.ReadLine();
            seasonPass1.State.Terminate(response);
            //seasonPass.setState(seasonPass.ExpiredState);
            if (seasonPass1.Type == "Monthly") //Refund
            {
                double amtRefunded = seasonPass1.RefundUnusedMonths();
                Console.WriteLine($"A refund of ${amtRefunded} has been sent to your account");
            }
            Console.WriteLine("Season pass HAS BEEN cancelled\n");

        }
        else if (cancel == 2)
        {
            Console.WriteLine("Season pass was NOT cancelled\n");
        }
        //Console.WriteLine("TerminateSeasonPass...");
        // Your implementation for option 3 goes here
    }

    public static void GenerateFinancialReport()
    {
        Console.WriteLine("GenerateFinancialReport...");
        // Your implementation for option 4 goes here
    }


    //Sub-functions

}
