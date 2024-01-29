using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class ConcreteReportIterator : ReportIterator
    {
        private List<ParkingRecord> records;
        private int position = 0;

        public ConcreteReportIterator(List<ParkingRecord> records)
        {
            this.records = records;
        }

        public bool HasNext()
        {
            return position < records.Count;
        }

        public object Next()
        {
            if (HasNext())
            {
                ParkingRecord record = records[position];
                position++;
                return record;
            }
            return null;
        }
    }
}
