using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    interface ReportIterator
    {
        bool HasNext();
        object Next();
    }

    class Report
    {

        public User User { get; set; }

        List<ReportFilter> ReportFilters = new List<ReportFilter>();
        string FilterMonth = null;
        string FilterYear = null;


        public Report(User user)
        {
            User = user;
        }

        public void setReportFilters(List<ReportFilter> reportFilters)
        {
            ReportFilters = reportFilters;
        }

        public bool setReportMonth(string input)
        {
            string[] parts = input.Split('/');

            if (parts.Length != 2)
            {
                Console.WriteLine("Invalid input format. Please use 'MM/YYYY' format.");
                return false;
            }


            string month = parts[0];
            string year = parts[1];

            if (month.Length != 2 || year.Length != 4)
            {
                Console.WriteLine("Invalid month or year length. Month should have 2 characters, and year should have 4 characters.");

                return false;
            }

            if (!int.TryParse(month, out int parsedMonth) || parsedMonth < 1 || parsedMonth > 12)
            {
                Console.WriteLine("Invalid month. Month should be a value between 01 and 12.");
                return false;
            }

            if (!int.TryParse(year, out int parsedYear) || parsedYear < 1900 || parsedYear > DateTime.Now.Year)
            {
                Console.WriteLine($"Invalid year. Year should be a value between 1900 and {DateTime.Now.Year}.");
                return false;
            }

            FilterMonth = month;
            FilterYear = year;

            return true;
        }
    }

    enum ReportFilter
    {
        vehiclesOwnedByStaff,
        vehiclesOwnedByStudent
    }
}
