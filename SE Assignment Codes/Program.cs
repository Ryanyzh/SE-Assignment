using System;

class Program
{
    static void Main()
    {
        ParkingManagementSystem parkingSystem = new ParkingManagementSystem();

        while (true)
        {
            Console.WriteLine("Parking Management System Menu:");
            Console.WriteLine("1. Apply for new season pass");
            Console.WriteLine("2. Process season pass application");
            Console.WriteLine("3. <item a>");
            Console.WriteLine("4. <item b>");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    parkingSystem.ApplyForNewSeasonPass();
                    break;

                case "2":
                    parkingSystem.ProcessSeasonPassApplication();
                    break;

                case "3":
                    parkingSystem.ItemAFunction();
                    break;

                case "4":
                    parkingSystem.ItemBFunction();
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
}

class ParkingManagementSystem
{
    public void ApplyForNewSeasonPass()
    {
        Console.WriteLine("Executing Apply for new season pass function...");
        // Your implementation for option 1 goes here
    }

    public void ProcessSeasonPassApplication()
    {
        Console.WriteLine("Executing Process season pass application function...");
        // Your implementation for option 2 goes here
    }

    public void ItemAFunction()
    {
        Console.WriteLine("Executing <item a> function...");
        // Your implementation for option 3 goes here
    }

    public void ItemBFunction()
    {
        Console.WriteLine("Executing <item b> function...");
        // Your implementation for option 4 goes here
    }
}