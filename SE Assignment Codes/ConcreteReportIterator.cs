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
        private int month;
        private int year;

        public ConcreteReportIterator(List<ParkingRecord> records)
        {
            this.records = records;

            DateTime currentDate = DateTime.Now;

            month = currentDate.Month;
            year = currentDate.Year;
        }

        public bool HasNext()
        {
            DateTime oldestRecord = records.Min(record => record.EntryDateTime);

            int oldestRecordMonthsSinceYear0 = ((oldestRecord.Year - 1) * 12) + oldestRecord.Month;
            int targetMonthsSinceYear0 = ((year - 1) * 12) + month;

            return oldestRecordMonthsSinceYear0 < targetMonthsSinceYear0;
        }

        public Report Next()
        {
            if (HasNext())
            {
                int targetMonthsSinceYear0 = (((year - 1) * 12) + month) - 1;

                int convertedMonths = targetMonthsSinceYear0 % 12;
                int convertedYears = targetMonthsSinceYear0 / 12;

                return new Report(records, convertedMonths, convertedYears);
            }
            return null;
        }
    }
}
