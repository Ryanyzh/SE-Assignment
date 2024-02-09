using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    public class Report
    {
        public DateTime Month { get; set; }

        private int StaffParkingRecords;
        private int StudentParkingRecords;
        private double StaffParkingRecordsRevenue;
        private double StudentParkingRecordsRevenue;

        public Report(DateTime month, int staffParkingRecords, int studentParkingRecords, double staffParkingRecordsRevenue, double studentParkingRecordsRevenue)
        {
            Month = month;

            StaffParkingRecords = staffParkingRecords;
            StudentParkingRecords = studentParkingRecords;
            StaffParkingRecordsRevenue = staffParkingRecordsRevenue;
            StudentParkingRecordsRevenue = studentParkingRecordsRevenue;
        }

        public void OutputReport()
        {
            string monthName = Month.ToString("MMMM yyyy");

            string report = $"Report for {monthName}\n\n" +
                            $"Staff:\n" +
                            $"  Parking Records: {StaffParkingRecords} \n" +
                            $"  Revenue: ${StaffParkingRecordsRevenue}\n\n" +
                            $"Student:\n" +
                            $"  Parking Records: {StaffParkingRecords} \n" +
                            $"  Revenue: ${StudentParkingRecordsRevenue}\n\n\n" +
                            $"All Vehicles (total):\n" +
                            $"  Parking Records: {StudentParkingRecords + StaffParkingRecords} \n" +
                            $"  Revenue: ${StaffParkingRecordsRevenue + StudentParkingRecordsRevenue}";

            Console.WriteLine(report);
        }
    }
}
