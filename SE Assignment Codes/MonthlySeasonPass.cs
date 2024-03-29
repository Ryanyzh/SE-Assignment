﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SE_Assignment_Codes
{
	class MonthlySeasonPass : SeasonPass
	{
		// Static variable representing the total number of monthly passes

		private static int monthlySeasonPassTotal = 8;

		// Static variable representing the number of available monthly passes
		private static int monthlySeasonPassAvailable;

		private static List<User> WaitingList { get; } = new List<User>();

		// Static constructor to initialize the number of available passes from the file
		static MonthlySeasonPass()
		{
			// Fetch the number of available monthly passes from SeasonPass.txt
			monthlySeasonPassAvailable = FetchAvailableMonthlyPasses();
		}

		public MonthlySeasonPass(int passNumber, User user, DateTime startMonth, DateTime endMonth, string paymentMode, Vehicle vehicle, string type)
            : base(passNumber, user, startMonth, endMonth, paymentMode, vehicle, type)
		{
			// Update the number of available monthly passes after creating a new pass
			monthlySeasonPassAvailable = FetchAvailableMonthlyPasses();
		}
        public static List<User> GetWaitingList()
        {
            // Return a copy of the waiting list to avoid external modifications.
            return new List<User>(WaitingList);
        }
        public static void addSeasonPass()
		{
			monthlySeasonPassAvailable += 1;
		}
		public static void subtractSeasonPass()
		{
			monthlySeasonPassAvailable -= 1;
		}

		// Method to fetch the number of available monthly passes from SeasonPass.txt
		private static int FetchAvailableMonthlyPasses()
		{
			try
			{
				// Read all lines from the SeasonPass.txt file
				string[] lines = File.ReadAllLines("SeasonPass.txt");

				// Count the number of passes with "PassType: Monthly"
				int monthlyPassCount = lines.Count(line => line.Contains("PassType: Monthly") && line.Contains("SeasonPassState: SE_Assignment_Codes.ProcessingState"));
				//Console.WriteLine(monthlyPassCount);

				//Console.WriteLine($"monthlyPassCount {monthlyPassCount}");

				// Calculate the number of available monthly passes by subtracting the counted passes from the total
				return monthlySeasonPassTotal - monthlyPassCount;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred while reading from the file: {ex.Message}");
				return 0; // Return 0 if an error occurs
			}
		}

		public static int GetNumberOfMonthlyPassAvailable()
        {
			monthlySeasonPassAvailable = FetchAvailableMonthlyPasses();
			return monthlySeasonPassAvailable;
        }

		public static void AddToWaitingList(User user)
		{
			WaitingList.Add(user);

			// Create or append to the "WaitingList.txt" file and save user details
			try
			{
				using (StreamWriter sw = File.AppendText("WaitingList.txt"))
				{
					string userDetails = $"{{Name: {user.Name}, ID: {user.ID}, Username: {user.Username}, Password: {user.Password}, MobileNumber: {user.MobileNumber}, UserType: {user.UserType}}}";
					sw.WriteLine(userDetails);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred while adding user to the waiting list: {ex.Message}");
			}
		}

        // Method to refund unused months
        public void RefundUnusedMonths()
        {
            int remainingMonths = ((EndMonth.Year - DateTime.Now.Year) * 12) + EndMonth.Month - DateTime.Now.Month; //Check if the end date includes that month
            double amountRefunded = remainingMonths * 150; //Assume that each month costs $150
            Console.WriteLine($"A refund of ${amountRefunded} has been sent to your account");
            addSeasonPass();
        }
        public static void ReadnLoadFromWaitingList()
        {
            string filePath = "WaitingList.txt";
            try
            {
                // Open the file for reading
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    // Read and display lines from the file until the end of the file is reached
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Extracting user details from the line
                        string[] parts = line
                            .Trim('{', '}')
                            .Split(new string[] { ", " }, StringSplitOptions.None);

                        string name = parts[0].Split(':')[1].Trim();
                        string id = parts[1].Split(':')[1].Trim();
                        string username = parts[2].Split(':')[1].Trim();
                        string password = parts[3].Split(':')[1].Trim();
                        string mobileNumber = parts[4].Split(':')[1].Trim();
                        string userType = parts[5].Split(':')[1].Trim();

                        User user = new User(name, id, username, password, mobileNumber, userType);
                        WaitingList.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding user to the waiting list: {ex.Message}");
            }
        }
    }
}

