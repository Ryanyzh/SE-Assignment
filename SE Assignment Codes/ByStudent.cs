using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class ByStudent : Aggregate
    {
        private List<ParkingRecord> parkingRecords = new List<ParkingRecord>();

        public void AddParkingRecord(ParkingRecord record)
        {
            parkingRecords.Insert(0, record);
        }

        public ConcreteReportIterator CreateIterator()
        {
            return new ConcreteReportIterator(parkingRecords);
        }

        public ByStudent() {
            string filePath = @"parkingrecords.tsv";

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    ParkingRecord record = ParkingRecord.FromString(line);

                    if (record == null || record.IsStaffRecord)
                    {
                        continue;
                    }
                    
                    AddParkingRecord(record);
                }
                
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
