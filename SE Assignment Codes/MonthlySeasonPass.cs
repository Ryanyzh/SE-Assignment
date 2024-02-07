using System;
using System.Collections.Generic;

namespace SE_Assignment_Codes
{
	class MonthlySeasonPass : SeasonPass
	{
        private static int monthlySeasonPassAvailable { get; set; }
		//public List<User> WaitingList { get; set; } error
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
	}
}

