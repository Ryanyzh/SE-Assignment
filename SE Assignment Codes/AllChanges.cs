using System;
using System.Collections.Generic;
using System.IO;

namespace SE_Assignment_Codes
{
    class AllChanges : Aggregate
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

        public AllChanges()
        {
            string filePath = @"parkingrecords.tsv";

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    ParkingRecord record = ParkingRecord.FromString(line);

                    if (record == null)
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
