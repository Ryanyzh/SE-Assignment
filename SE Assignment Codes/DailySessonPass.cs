using System;
namespace SE_Assignment_Codes
{
	class DailySessonPass : SeasonPass
	{
        private static double dailyCharge;
        public DailySessonPass(int passNumber, User user, DateTime startMonth, DateTime endMonth, string paymentMode, Vehicle vehicle, string type)
            : base(passNumber, user, startMonth, endMonth, paymentMode, vehicle, type)
        {
            dailyCharge = 20;
		}
        public double getDailyCharge()
        {
            return dailyCharge;
        }
        public void RefundUnusedMonths()
        {
            Console.WriteLine($"A refund of $0 has been sent to your account");
        }
    }
}