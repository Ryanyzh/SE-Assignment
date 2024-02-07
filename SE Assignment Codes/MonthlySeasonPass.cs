using System;
using System.Collections.Generic;

namespace SE_Assignment_Codes
{
	class MonthlySeasonPass : SeasonPass
	{
        private static int monthlySeasonPassAvailable { get; set; }
		private static List<User> waitingList { get; set; } = new List<User>();
        public MonthlySeasonPass(int passNumber, User user, DateTime startMonth, DateTime endMonth, string paymentMode, Vehicle vehicle, string type, int value)
            : base(passNumber, user, startMonth, endMonth, paymentMode, vehicle, type)
		{
			monthlySeasonPassAvailable = value;
		}
		public void addSeasonPass()
		{
			monthlySeasonPassAvailable += 1;
		}
		public void subtractSeasonPass()
		{
			monthlySeasonPassAvailable -= 1;
		}
		public int test()
		{
			return monthlySeasonPassAvailable;
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
	}
}

