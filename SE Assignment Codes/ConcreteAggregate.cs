using System;
using System.Collections.Generic;
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
            parkingRecords.Add(record);
        }

        public ReportIterator CreateIterator()
        {
            return new ConcreteReportIterator(parkingRecords);
        }
    }
}
