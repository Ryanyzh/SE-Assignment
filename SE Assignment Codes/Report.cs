using System;
using System.Collections.Generic;
using System.Linq;

namespace SE_Assignment_Codes
{
    class Report
    {
        private List<ParkingRecord> Records;
        private int Year;
        private int Month;


        public Report(List<ParkingRecord> records, int month, int year)
        {
            Records = records.Where(r => r.EntryDateTime.Month == month && r.EntryDateTime.Year == year).ToList();
            Year = year;
            Month = month;
        }

        public void Generate()
        {
            List<ParkingRecord> staffParkingRecords = Records.Where(r => r.User.IsStaff).ToList();
            double staffEarnings = staffParkingRecords.Aggregate(0, (double acc, ParkingRecord record) => acc + record.AmountCharged);
            int staffNumberOfRecords = staffParkingRecords.Count;

            List<ParkingRecord> studentParkingRecords = Records.Where(r => !r.User.IsStaff).ToList();
            double studentEarnings = studentParkingRecords.Aggregate(0, (double acc, ParkingRecord record) => acc + record.AmountCharged);
            int studentNumberOfRecords = studentParkingRecords.Count;

            Console.WriteLine($"Monthly report for {Month}/{Year}");
            Console.WriteLine("------------------------------");

            Console.WriteLine($"Students");
            Console.WriteLine($"  Revenue           : ${Math.Round(studentEarnings, 2)}");
            Console.WriteLine($"  Number of Records : {studentNumberOfRecords}");

            Console.WriteLine($"\nStaff");
            Console.WriteLine($"  Revenue           : ${Math.Round(staffEarnings, 2)}");
            Console.WriteLine($"  Number of Records : {staffNumberOfRecords}");

            Console.WriteLine("\n------------------------------\n");
            Console.WriteLine($"Total");
            Console.WriteLine($"  Revenue           : ${Math.Round(studentEarnings + staffEarnings, 2)}");
            Console.WriteLine($"  Number of Records : {staffNumberOfRecords + studentNumberOfRecords}");
        }
    }
}
