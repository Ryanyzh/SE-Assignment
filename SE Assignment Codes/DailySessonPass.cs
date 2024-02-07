using System;
namespace SE_Assignment_Codes
{
	class DailySessonPass : SeasonPass
	{
        public static double dailyCharge { get; set; }
        public DailySessonPass(int passNumber, User user, DateTime startMonth, DateTime endMonth, string paymentMode, Vehicle vehicle, string type, double amount)
            : base(passNumber, user, startMonth, endMonth, paymentMode, vehicle, type)
        {
            dailyCharge = amount;
		}
	}
}