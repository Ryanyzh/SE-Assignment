using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    class CarPark
    {
        public int CarParkNumber { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int NumOfCarParkingLots { get; set; }
        public int NumOfMotorbikeParkingLots { get; set; }
        public List<ParkingRecord> parkingRecordList = new List<ParkingRecord>();

        // Constructor
        public CarPark(int carParkNumber, string description, string location, int numOfCarParkingLots, int numOfMotorbikeParkingLots)
        {
            CarParkNumber = carParkNumber;
            Description = description;
            Location = location;
            NumOfCarParkingLots = numOfCarParkingLots;
            NumOfMotorbikeParkingLots = numOfMotorbikeParkingLots;
        }

        // Provide description of the car park
        public string ProvideDescription()
        {
            return Description;
        }

        // Determine location of the car park
        public string DetermineLocation()
        {
            return Location;
        }
    }
}
