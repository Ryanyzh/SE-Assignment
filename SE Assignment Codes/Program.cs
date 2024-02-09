using System;
using System.IO;
using System.Xml.Linq;
using SE_Assignment_Codes;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

public class Global
{
    static List<SeasonPass> seasonpass = new List<SeasonPass>();
}

class Program
{

    static void Main()
    {
        //Replace with csv reader 
        SeasonPass seasonPass = null;
        

        // Get the directory where the executable is located
        string directory = AppDomain.CurrentDomain.BaseDirectory;

        // Combine the directory with the file name to get the full path
        string filePath = Path.Combine(directory, "SeasonPass.txt");

        // Display the full path
        //Console.WriteLine($"The SeasonPass.txt file is located at: {filePath}");
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line = sr.ReadLine();
                seasonPass = ProcessSeasonPassDetails(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

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
                    ApplyForNewSeasonPass(seasonPass);
                    break;

                    case "2":
                        ProcessSeasonPassApplication();
                        break;

                case "3":
                    TerminateSeasonPass(seasonPass);
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
    public static SeasonPass ProcessSeasonPassDetails(string line)
    {
        SeasonPass seasonPass = null;
        try
        {
            string[] keyValuePairs = line.Split(',');

            string seasonPassId = getValueFromKey(keyValuePairs[0]);
            string username = getValueFromKey(keyValuePairs[1]);
            string pass = getValueFromKey(keyValuePairs[2]);
            string name = getValueFromKey(keyValuePairs[3]);
            string uId = getValueFromKey(keyValuePairs[4]);
            string mobile = getValueFromKey(keyValuePairs[5]);
            string lp = getValueFromKey(keyValuePairs[6]);
            string iu = getValueFromKey(keyValuePairs[7]);
            string vt = getValueFromKey(keyValuePairs[8]);
            string sm = getValueFromKey(keyValuePairs[9]).Substring(0, getValueFromKey(keyValuePairs[9]).LastIndexOf('/'));
            string em = getValueFromKey(keyValuePairs[10]).Substring(0, getValueFromKey(keyValuePairs[10]).LastIndexOf('/'));
            string seasonPassState = getValueFromKey(keyValuePairs[11]);
            string pt = getValueFromKey(keyValuePairs[12]);
            string pm = getValueFromKey(keyValuePairs[13]);
            string ut = getValueFromKey(keyValuePairs[14]);


            User loadedUser = new User(name,uId,username, pass, mobile, ut);
            Vehicle loadedVehicle = new Vehicle(lp, iu, vt);

            if (pt == "Monthly")
            {
                seasonPass = new MonthlySeasonPass(Int32.Parse(seasonPassId), loadedUser, DateTime.Parse(sm), DateTime.Parse(em), pm, loadedVehicle, pt);
                if (seasonPassState == "SE_Assignment_Codes.ProcessingState") { seasonPass.State = seasonPass.ProcessingState; }
                else if (seasonPassState == "SE_Assignment_Codes.TerminatedState") { seasonPass.State = seasonPass.TerminatedState; }
                else if (seasonPassState == "SE_Assignment_Codes.ValidState") { seasonPass.State = seasonPass.ValidState; }
                else if (seasonPassState == "SE_Assignment_Codes.ExpiredState") { seasonPass.State = seasonPass.ExpiredState; }
            }
            else
            {
                seasonPass = new DailySessonPass(Int32.Parse(seasonPassId), loadedUser, DateTime.Parse(sm), DateTime.Parse(em), pm, loadedVehicle, pt);
                if (seasonPassState == "SE_Assignment_Codes.ProcessingState") { seasonPass.State = seasonPass.ProcessingState; }
                else if (seasonPassState == "SE_Assignment_Codes.TerminatedState") { seasonPass.State = seasonPass.TerminatedState; }
                else if (seasonPassState == "SE_Assignment_Codes.ValidState") { seasonPass.State = seasonPass.ValidState; }
                else if (seasonPassState == "SE_Assignment_Codes.ExpiredState") { seasonPass.State = seasonPass.ExpiredState; }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        return seasonPass;
    }

    public static string getValueFromKey(string keyAndValue)
    {
        string[] value = keyAndValue.Split(':');
        return value[1].Trim();
    }

    public static void ApplyForNewSeasonPass(SeasonPass seasonPass)
    {
        Console.WriteLine("Applying for a new season pass...");

        // Prompt the applicant to provide necessary details
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        //Console.Write("Select your user type: ");
        //string userType = Console.ReadLine();

        string userType;
        while (true)
        {
            // Prompt user to select user type
            Console.WriteLine("Select user type:");
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Staff");
            Console.Write("Enter your choice (1 for Student, 2 for Staff): ");
            string userTypeOption = Console.ReadLine();

            if (userTypeOption == "1")
            {
                userType = "Student";
                break;
            }
            else if (userTypeOption == "2")
            {
                userType = "Staff";
                break;
            }
            else
            {
                Console.WriteLine("Invalid option selected. Please try again.");
            }
        }


        Console.Write("Enter your student/staff ID: ");
        string applicantId = Console.ReadLine();


        Console.Write("Enter your mobile number: ");
        string mobileNumber = Console.ReadLine();

        Console.Write("Enter your license plate number: ");
        string licensePlateNumber = Console.ReadLine();

        Console.Write("Enter your IU number: ");
        string iuNumber = Console.ReadLine();

        //Console.Write("Enter vehicle type: ");
        //string vehicleType = Console.ReadLine();


        string vehicleType;
        while (true)
        {
            // Prompt user to select payment mode
            Console.WriteLine("Select vehicle type:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Motorbike");
            Console.Write("Enter your choice (1 for Car, 2 for Motorbike): ");
            string vehicleTypeOption = Console.ReadLine();

            if (vehicleTypeOption == "1")
            {
                vehicleType = "Car";
                break;
            }
            else if (vehicleTypeOption == "2")
            {
                vehicleType = "Motorbike";
                break;
            }
            else
            {
                Console.WriteLine("Invalid option selected. Please try again.");
            }
        }



        Console.Write("Enter start month (MM/YYYY): ");
        string startMonthStr = Console.ReadLine();
        DateTime startMonth;

        // Keep prompting the user until the input is in the correct format
        while (!DateTime.TryParseExact(startMonthStr, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out startMonth))
        {
            // Inform the user about the incorrect format
            Console.WriteLine("Invalid format. Please enter the start month in MM/YYYY format.");

            // Prompt the user again for input
            Console.Write("Enter start month (MM/YYYY): ");
            startMonthStr = Console.ReadLine();
        }

        Console.Write("Enter end month (MM/YYYY): ");
        string endMonthStr = Console.ReadLine();
        DateTime endMonth;

        // Keep prompting the user until the input is in the correct format
        while (!DateTime.TryParseExact(endMonthStr, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out endMonth))
        {
            // Inform the user about the incorrect format
            Console.WriteLine("Invalid format. Please enter the end month in MM/YYYY format.");

            // Prompt the user again for input
            Console.Write("Enter end month (MM/YYYY): ");
            endMonthStr = Console.ReadLine();
        }

        //Console.Write("Enter season pass type: ");
        //string passType = Console.ReadLine();

        string passType;
        while (true)
        {
            // Prompt user to select season pass type
            Console.WriteLine("Select season pass type:");
            Console.WriteLine("1. Daily");
            Console.WriteLine("2. Monthly");
            Console.Write("Enter your choice (1 for Daily, 2 for Monthly): ");
            string passTypeOption = Console.ReadLine();

            if (passTypeOption == "1")
            {
                passType = "Daily";
                break;
            }
            else if (passTypeOption == "2")
            {
                passType = "Monthly";
                break;
            }
            else
            {
                Console.WriteLine("Invalid option selected. Please try again.");
            }
        }

        //Console.Write("Enter payment mode: ");
        //string paymentMode = Console.ReadLine();
        string paymentMode;
        while (true)
        {
            // Prompt user to select payment mode
            Console.WriteLine("Select payment mode:");
            Console.WriteLine("1. Debit Card");
            Console.WriteLine("2. Credit Card");
            Console.Write("Enter your choice (1 for Debit Card, 2 for Credit Card): ");
            string paymentModeOption = Console.ReadLine();

            if (paymentModeOption == "1")
            {
                paymentMode = "Debit Card";
                break;
            }
            else if (paymentModeOption == "2")
            {
                paymentMode = "Credit Card";
                break;
            }
            else
            {
                Console.WriteLine("Invalid option selected. Please try again.");
            }
        }

        // Create User object with collected details
        User user = new User(name, applicantId, username, password, mobileNumber, userType);

        // Create Vehicle object with collected details
        Vehicle vehicle = new Vehicle(licensePlateNumber, iuNumber, vehicleType);

        

        Console.WriteLine(MonthlySeasonPass.GetNumberOfMonthlyPassAvailable());
        if (passType=="Monthly" && MonthlySeasonPass.GetNumberOfMonthlyPassAvailable() <= 0)
        {
            Console.Write("Monthly passes are currently unavailable. Would you like to be added to the waiting list (Y/N)?");
            string waititngList = Console.ReadLine();

            if (waititngList.ToUpper() == "Y")
            {
                // Add user to the waiting list
                MonthlySeasonPass.AddToWaitingList(user);
                Console.WriteLine("You have been added to the waiting list.");
            }
            else
            {
                Console.WriteLine("Returning to the main menu...");
                return;
            }
                
        }
        else
        {
            // Confirm details
            Console.WriteLine("\nConfirm details:");
            Console.WriteLine("-------------------------------------------------");
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
                Console.WriteLine("Payment received....");

                // Create and process the season pass application
                seasonPass = new SeasonPass(0, user, startMonth, endMonth, paymentMode, vehicle, passType);

                // Write full SeasonPass details to the file
                WriteToSeasonPassFile(seasonPass);

                Console.WriteLine($"Season Pass State: {seasonPass.State}");

                // Update status to 'processing'
                // seasonPass.Apply();

                Console.WriteLine($"Season Pass State: {seasonPass.State}");

                Console.WriteLine("Season pass application submitted successfully.");
            }
            else
            {
                Console.WriteLine("Season pass application cancelled.");
                return;
            }
        }

        
    }


    // add data to season pass text file
    static void WriteToSeasonPassFile(SeasonPass seasonPass)
    {
        try
        {
            // Append the new season pass details to the file
            using (StreamWriter sw = File.AppendText("SeasonPass.txt"))
            {
                sw.Write($"SeasonPassId: {seasonPass.PassNumber},");
                sw.Write($"Username: {seasonPass.User.Username},");
                sw.Write($"Password: {seasonPass.User.Password},");
                sw.Write($"Name: {seasonPass.User.Name},");
                sw.Write($"UserId: {seasonPass.User.ID},");
                sw.Write($"MobileNumber: {seasonPass.User.MobileNumber},");
                sw.Write($"LicensePlateNumber: {seasonPass.Vehicle.LicensePlateNumber},");
                sw.Write($"IUNumber: {seasonPass.Vehicle.IUNumber},");
                sw.Write($"VehicleType: {seasonPass.Vehicle.VehicleType},");
                sw.Write($"StartMonth: {seasonPass.StartMonth},");
                sw.Write($"EndMonth: {seasonPass.EndMonth},");
                sw.Write($"SeasonPassState: {seasonPass.State},");
                sw.Write($"PassType: {seasonPass.Type},");
                sw.Write($"PaymentMode: {seasonPass.PaymentMode},");
                sw.Write($"UserType: {seasonPass.User.UserType}");
                sw.WriteLine(); // Add an empty line for better readability

                //sw.Write($"SeasonPassId: {seasonPass.PassNumber},");
                //sw.Write($"User: {seasonPass.User.saveUserDetails()},");
                //sw.Write($"Vehicle: {seasonPass.Vehicle.saveVehicleDetails()},");
                //sw.Write($"StartMonth: {seasonPass.StartMonth},");
                //sw.Write($"EndMonth: {seasonPass.EndMonth},");
                //sw.Write($"SeasonPassState: {seasonPass.State},");
                //sw.Write($"PassType: {seasonPass.Type},");
                //sw.Write($"PaymentMode: {seasonPass.PaymentMode}");
                //sw.WriteLine(); // Add an empty line for better readability
            }

            Console.WriteLine("SeasonPass details successfully written to the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
        }
    }



    public static void ProcessSeasonPassApplication()
    {
        Console.WriteLine();

    }

    public static void TerminateSeasonPass(SeasonPass seasonPass)
    {
        //For testing

        //Check for existing season pass

        //End check

        int cancel = 0;
        while(cancel != 1 && cancel != 2)
        {
            try
            {
                Console.Write("Confirm that you want to terminate season pass\n[1]Yes [2] No\nEnter option:");
                cancel = Int32.Parse(Console.ReadLine());
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
            seasonPass.Terminate(response);
            if (seasonPass is MonthlySeasonPass && seasonPass.State.GetType().ToString() == "SE_Assignment_Codes.TerminatedState")
            {
                MonthlySeasonPass mp = (MonthlySeasonPass)seasonPass;
                if (mp.refundedPass == false)
                {
                    mp.RefundUnusedMonths();
                }
                else
                {
                    Console.WriteLine("Pass has been refunded previously!");
                }
            }
        }
        else if (cancel == 2)
        {
            Console.WriteLine("Season pass was NOT cancelled\n");
        }
    }

    public static void GenerateFinancialReport()
    {

        DateTime targetMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        DateTime earliestMonthReport = new DateTime(DateTime.Now.Year - 2, DateTime.Now.Month, 1);

        while (targetMonth != earliestMonthReport)
        {
            Aggregate aggregate = null;

            while (aggregate == null)
            {
                Console.Write("Generate report for:\n  [1] Student\n  [2] Staff\n  [3] Everyone\n\n  [0] Exit\nEnter your choice: ");
                string response = Console.ReadLine().ToLower();

                switch (response)
                {
                    case "1":
                        aggregate = new ByStudent();
                        break;
                    case "2":
                        aggregate = new ByStaff();
                        break;
                    case "3":
                        aggregate = new AllChanges();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                }
            }

            string monthName = targetMonth.ToString("MMMM yyyy");
            string aggregateType = aggregate.GetType().Name;

            Console.WriteLine($"Report for {monthName}, {aggregateType}");

            GenerateMonthlyReport(targetMonth, aggregate);

            targetMonth = targetMonth.AddMonths(-1);

            if (targetMonth == earliestMonthReport)
            {
                Console.Write("That is as far back as our records go!");
                return;
            }

            while (true)
            {
                Console.Write("Generate report for the month before (" + targetMonth.ToString("MMMM yyyy") + ") [Y/N]? ");
                string response = Console.ReadLine().ToLower();

                if (response == "y")
                {
                    break;
                }
                else if (response == "n")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Try again.");
                }
            }

        }
    }

    public static void GenerateMonthlyReport(DateTime month, Aggregate aggregate)
    {
        
        var iterator = aggregate.CreateIterator();

        int records = 0;
        double revenue = 0;

        Console.WriteLine("Record No. | Role    | Entry Date/Time      | Exit Date/Time       | Amount Charged");
        Console.WriteLine("-----------+---------+----------------------+----------------------+---------------");

        while (iterator.HasNext())
        {
            var record = (ParkingRecord)iterator.Next();

            if (record.EntryDateTime.Month == month.Month && record.EntryDateTime.Year == month.Year)
            {
                records++;
                revenue += record.AmountCharged;

                Console.WriteLine(record.ToString());
            }
            else if (month > record.EntryDateTime)
            {
                break;
            }
        }
        
        Console.WriteLine($"\n\nNumber of Records: {records}");

        string formattedRevenue = revenue.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

        Console.WriteLine($"          Revenue: ${formattedRevenue}");
    }
}
