using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class ParkingRecord
    {
        public int RecordNumber { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime ExitDateTime { get; set; }
        public double AmountCharged { get; set; }

        public User User { get; set; }

        // Constructor
        public ParkingRecord(int recordNumber, DateTime entryDateTime, User user)
        {
            RecordNumber = recordNumber;
            EntryDateTime = entryDateTime;
            User = user;
        }

        // Capture parking data
        public void CaptureParkingData(DateTime exitDateTime, double amountCharged)
        {
            ExitDateTime = exitDateTime;
            AmountCharged = amountCharged;
        }

        // Calculate parking charge
        public double CalculateCharge()
        {
            // Sample calculation, replace with actual logic
            TimeSpan duration = ExitDateTime - EntryDateTime;
            double charge = duration.TotalMinutes * 0.05; // Sample charge rate of $0.05 per minute
            return charge;
        }

        // Generate report
        public void GenerateReport()
        {
            // Sample report generation logic
            Console.WriteLine($"Parking Record Number: {RecordNumber}");
            Console.WriteLine($"Entry Date Time: {EntryDateTime}");
            Console.WriteLine($"Exit Date Time: {ExitDateTime}");
            Console.WriteLine($"Amount Charged: {AmountCharged}");
        }

        // Get vehicle details
        public void GetVehicleDetails()
        {
            // Sample implementation, replace with actual logic
            Console.WriteLine("Retrieving vehicle details...");
        }

        // Get car park details
        public void GetCarParkDetails()
        {
            // Sample implementation, replace with actual logic
            Console.WriteLine("Retrieving car park details...");
        }
    }
}
