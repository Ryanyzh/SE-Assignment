using System;
using System.Collections.Generic;
using SE_Assignment_Codes;


class Program
{
    static void Main()
    {

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
                    ApplyForNewSeasonPass();
                    break;

                case "2":
                    ProcessSeasonPassApplication();
                    break;

                case "3":
                    TerminateSeasonPass();
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

    public static void ApplyForNewSeasonPass()
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
            seasonPass.State.Apply();

            Console.WriteLine("Season pass application submitted successfully.");
        }
        else
        {
            Console.WriteLine("Season pass application cancelled.");
        }
    }

    public static void ProcessSeasonPassApplication()
    {
        Console.WriteLine("Executing Process season pass application function...");
        // Your implementation for option 2 goes here
    }

    public static void TerminateSeasonPass()
    {
        Console.WriteLine("TerminateSeasonPass...");
        // Your implementation for option 3 goes here
    }

    public static void GenerateFinancialReport()
    {
        Console.WriteLine("Generating Financial Report...");

        // Prompt the applicant to provide necessary details
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        Console.WriteLine("Generate report for:");
        Console.WriteLine("1. All vehicles");
        Console.WriteLine("2. Vehicles owned by staff");
        Console.WriteLine("3. Vehicles owned by students");
        Console.WriteLine("0. Back");

        Console.Write("Enter your choice: ");

        User user = new User("name", "applicantId", "username", "password", "mobileNumber");
        Report report = new Report(user);

        List<ReportFilter> reportFilters = new List<ReportFilter>();
        string choice = Console.ReadLine();

        while (reportFilters.Count == 0)
        {
            switch (choice)
            {
                case "1":
                    reportFilters.Add(ReportFilter.vehiclesOwnedByStaff);
                    reportFilters.Add(ReportFilter.vehiclesOwnedByStudent);
                    break;
                case "2":
                    reportFilters.Add(ReportFilter.vehiclesOwnedByStaff);
                    break;

                case "3":
                    reportFilters.Add(ReportFilter.vehiclesOwnedByStudent);
                    break;

                case "0":
                    return;

                default:
                    Console.Write("Invalid choice. Please enter a valid option: ");
                    choice = Console.ReadLine();
                    break;
            }
        }
        report.setReportFilters(reportFilters);


        Console.Write("Enter report month (MM/YYYY): ");
        string reportMonthStr = Console.ReadLine();

        while (!report.setReportMonth(reportMonthStr))
        {
            Console.Write("Re-enter the month (MM/YYYY): ");
            reportMonthStr = Console.ReadLine();
        }
    }
}
