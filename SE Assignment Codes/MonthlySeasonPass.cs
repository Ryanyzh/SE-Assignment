using System;
using System.Collections.Generic;

namespace SE_Assignment_Codes
{
	class MonthlySeasonPass : SeasonPass
	{
		private static int monthlySeasonPassAvailable;
		private static List<User> waitingList = new List<User>();
        public MonthlySeasonPass(int passNumber, User user, DateTime startMonth, DateTime endMonth, string paymentMode, Vehicle vehicle, string type)
            : base(passNumber, user, startMonth, endMonth, paymentMode, vehicle, type)
		{
			monthlySeasonPassAvailable = 50;
		}
		public void addSeasonPass()
		{
			monthlySeasonPassAvailable += 1;
		}
		public void subtractSeasonPass()
		{
			monthlySeasonPassAvailable -= 1;
		}

		// Method to fetch initial number of available passes from a database or other data source
		private static int InitializeAvailablePasses()
		{
			int initalPassCount = 10;
			// read the text file for the number of monthly pass applied and subtract accordingly
			return 10; // Example: Initial number of available monthly passes is 100
		}

		public static int GetNumberOfMonthlyPassAvailable()
        {
			return monthlySeasonPassAvailable;
        }

		public static void AddToWaitingList(User user)
		{
			waitingList.Add(user);
		}

        // Method to refund unused months
        public void RefundUnusedMonths()
        {
            int remainingMonths = ((EndMonth.Year - DateTime.Now.Year) * 12) + EndMonth.Month - DateTime.Now.Month; //Check if the end date includes that month
            double amountRefunded = remainingMonths * 150; //Assume that each month costs $150
            Console.WriteLine($"A refund of ${amountRefunded} has been sent to your account");
            this.addSeasonPass();
        }
    }
}

