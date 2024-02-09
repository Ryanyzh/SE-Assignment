using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    public class ParkingRecord
    {
        public int RecordNumber { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime ExitDateTime { get; set; }
        public double AmountCharged { get; set; }

        public bool IsStaffRecord { get; set; }

        // Constructor
        public ParkingRecord(int recordNumber, DateTime entryDateTime, DateTime exitDateTime, double amountCharged, bool isStaffRecord)
        {
            RecordNumber = recordNumber;
            EntryDateTime = entryDateTime;
            ExitDateTime = exitDateTime;
            IsStaffRecord = isStaffRecord;
            AmountCharged = amountCharged;
        }

        public static ParkingRecord FromString(string line)
        {
            string[] row = line.Split("    ");

            if (row.Length != 5)
            {
                return null;
            }

            int id = Convert.ToInt32(row[0]);
            DateTime startDateTime = DateTime.Parse(row[1]);
            DateTime endDateTime = DateTime.Parse(row[2]);
            double amountCharged = Convert.ToDouble(row[3]);
            bool isStaffRecord = row[4] == "y";

            return new ParkingRecord(id, startDateTime, endDateTime, amountCharged, isStaffRecord);
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

        public string ToString()
        {
            string output = "";

            string recordNumber = RecordNumber.ToString();

            int recordNumberPadding = 9 - recordNumber.Length;

            for (int i = 0; i < recordNumberPadding; i++)
            {
                output += " ";
            }

            output += "#" + recordNumber + " | ";
            output += (IsStaffRecord ? "Staff  " : "Student") + " | ";
            output += EntryDateTime.ToString("dd-MM-yyyy, HH:mm:ss") + " | ";
            output += ExitDateTime.ToString("dd-MM-yyyy, HH:mm:ss") + " | ";
            output += "$" + AmountCharged.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

            return output;
        }
    }
}
