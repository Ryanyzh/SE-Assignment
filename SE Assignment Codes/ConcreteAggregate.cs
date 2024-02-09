using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class ConcreteAggregate : Aggregate
    {
        private List<ParkingRecord> parkingRecords = new List<ParkingRecord>();

        public void AddParkingRecord(ParkingRecord record)
        {
            parkingRecords.Insert(0, record);
        }

        public ReportIterator CreateIterator()
        {
            return new ConcreteReportIterator(parkingRecords);
        }

        public ConcreteAggregate() {
            string filePath = @"parkingrecords.tsv";

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] row = line.Split("    ");

                    if (row.Length != 5)
                    {
                        continue;
                    }

                    int id = Convert.ToInt32(row[0]);
                    DateTime startDateTime = DateTime.Parse(row[1]);
                    DateTime endDateTime = DateTime.Parse(row[2]);
                    double amountCharged = Convert.ToDouble(row[3]);
                    bool isStaffRecord = row[4] == "y";

                    AddParkingRecord(new ParkingRecord(id, startDateTime, endDateTime, amountCharged, isStaffRecord));
                }
                
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static ConcreteAggregate Shared = new ConcreteAggregate();
    }
}
